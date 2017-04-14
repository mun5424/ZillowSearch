using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Serialization; 
using System.IO;
using System.Web.Mvc;

namespace ZillowSearch.Controllers
{



    [Authorize]
    public class HomeController : Controller
    {

        private const string ZWSID = "X1-ZWz1dyb53fdhjf_6jziz";

        //regex expressions to check address format 
        private const string regexZIP = @"\b\d{5}(?:-\d{4})?\b";
        private const string regexStreetName = @"\d+[ ](?:[A-Za-z0-9.-]+[ ]?)+(?:Avenue|Lane|Road|Boulevard|Drive|Street|Ave|Dr|Rd|Blvd|Ln|St)\.?";
        private const string regexCity = @"(?:[A-Z][a-z.-]+[ ]?)+";
        private const string regexStateFull = "Alabama|Alaska|Arizona|Arkansas|California|Colorado|Connecticut|Delaware|Florida|Georgia|" +
            "Hawaii|Idaho|Illinois|Indiana|Iowa|Kansas|Kentucky|Louisiana|Maine|Maryland|Massachusetts|Michigan|Minnesota|Mississippi|" +
            "Missouri|Montana|Nebraska|Nevada|New[] Hampshire|New[] Jersey|New[] Mexico|New[] York|North[] Carolina|North[] Dakota|Ohio|" +
            "Oklahoma|Oregon|Pennsylvania|Rhode[] Island|South[] Carolina|South[] Dakota|Tennessee|Texas|Utah|Vermont|Virginia|" +
            "Washington|West[] Virginia|Wisconsin|Wyoming";
        private const string regexStateShort = "AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT" +
            "|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY";


        private string checkFullAddress(string address)
        {
            var tokens = address.Split(' ');
            if (tokens.Length < 6)
                return "invalid address format.";

            string streetName = tokens[0] + " " + tokens[1] + " " + tokens[2];
            if (!checkRegex(streetName, regexStreetName))
                return "Invalid Street Name.";

            string city = tokens[3];
            if (!checkRegex(city, regexCity))
                return "Invalid City.";

            string state = tokens[4];
            if (!checkRegex(state, regexStateShort) && !checkRegex(state, regexStateFull))
                return "Invalid State.";

            string ZIP = tokens[5];
            if (!checkRegex(ZIP, regexZIP))
                return "Invalid ZIP Code.";

            return ""; 
        }

        public bool checkRegex(string s, string regexStr)
        {
            Regex regex = new Regex(regexStr);
            Match match = regex.Match(s);
            return match.Success;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchResults()
        {

            string address = Request.Params["SearchString"];

            if (address == null)
            {
                return View(); 
            }

            var tokens = address.Split(' ');
            string streetName = tokens[0] + " " + tokens[1] + " " + tokens[2];
            string city = tokens[3];
            string state = tokens[4];
            string ZIP = tokens[5];

            streetName = WebUtility.UrlEncode(streetName);
            string cityStateZIP = WebUtility.UrlEncode(city + " " + state + " " + ZIP);

            //use these parameters,along with zwsid given in the prompt to make the api call to Zillow's GetSearchResults
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("zws-id", ZWSID);
            webClient.QueryString.Add("address", streetName);
            webClient.QueryString.Add("citystatezip", cityStateZIP);
            string resultXML = webClient.DownloadString("http://www.zillow.com/webservice/GetSearchResults.htm");

            //write xml string to a stream so that it can be deserialized
            MemoryStream stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.Write(resultXML);
            sw.Flush();
            stream.Position = 0;
            XmlSerializer serializer = new XmlSerializer(typeof(searchresults));
            var searchResults = (searchresults)serializer.Deserialize(stream);
            stream.Close();
            return View(searchResults);

        }


    }
}
