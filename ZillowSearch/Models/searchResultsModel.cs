using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace ZillowSearch.Models
{
    [XmlRoot(ElementName = "searchresults", Namespace = "http://www.zillow.com/static/xsd/SearchResults.xsd")]
    public class Searchresults
    {
        [XmlElement(ElementName = "request")]
        public Request Request { get; set; }

        [XmlElement(ElementName = "message")]
        public Message Message { get; set; }

        [XmlElement(ElementName = "response")]
        public Response Response { get; set; }

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "SearchResults", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string SearchResults { get; set; }
    }

    [XmlRoot(ElementName = "request")]
    public class Request
    {
        [XmlElement(ElementName = "address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "citystatezip")]
        public string Citystatezip { get; set; }
    }

    [XmlRoot(ElementName = "message")]
    public class Message
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        public string errorSolution(string errorCode)
        {
            int errorNum = Convert.ToInt32(errorCode);
            switch (errorNum)
            {
                case 1:
                    return "Check to see if your url is properly formed: delimiters, character cases, etc.";
                case 2:
                    return "Check if you have provided a ZWSID in your API call. If yes, check if the ZWSID is keyed in correctly. If it still doesn't work, contact Zillow to get help on fixing your ZWSID.";
                case 3:
                    return "The Zillow Web Service is currently not available. Please come back later and try again.";
                case 4:
                    return "The Zillow Web Service is currently not available. Please come back later and try again.";
                case 500:
                    return "Check if the input address matches the format specified in the input parameters table. When inputting a city name, include the state too. A city name alone will not result in a valid address.";
                case 501:
                    return "Check if the input address matches the format specified in the input parameters table. When inputting a city name, include the state too. A city name alone will not result in a valid address.";
                case 502:
                    return "Sorry, the address you provided is not found in Zillow's property database.";
                case 503:
                    return "Please check to see if the city/state you entered is valid. If you provided a ZIP code, check to see if it is valid.";
                case 504:
                    return "The specified area is not covered by the Zillow property database. Click to see our <a href=\"https://www.zillow.com/zestimate/#acc\">property coverage tables</a>.";
                case 505:
                    return "Your request timed out. The server could be busy or unavailable. Try again later.";
                case 506:
                    return "If address is valid, try using abbreviations.";
                case 507:
                    return "Verify that the given address is correct.";
                default:
                    return "Request successfully processed";
            }
        }
    }

    [XmlRoot(ElementName = "links")]
    public class Links
    {
        [XmlElement(ElementName = "homedetails")]
        public string Homedetails { get; set; }
        [XmlElement(ElementName = "graphsanddata")]
        public string Graphsanddata { get; set; }
        [XmlElement(ElementName = "mapthishome")]
        public string Mapthishome { get; set; }
        [XmlElement(ElementName = "comparables")]
        public string Comparables { get; set; }
        [XmlElement(ElementName = "overview")]
        public string Overview { get; set; }
        [XmlElement(ElementName = "forSaleByOwner")]
        public string ForSaleByOwner { get; set; }
        [XmlElement(ElementName = "forSale")]
        public string ForSale { get; set; }
    }

    [XmlRoot(ElementName = "address")]
    public class Address
    {
        [XmlElement(ElementName = "street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "zipcode")]
        public string Zipcode { get; set; }
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "state")]
        public string State { get; set; }
        [XmlElement(ElementName = "latitude")]
        public string Latitude { get; set; }
        [XmlElement(ElementName = "longitude")]
        public string Longitude { get; set; }
    }

    [XmlRoot(ElementName = "amount")]
    public class Amount
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "oneWeekChange")]
    public class OneWeekChange
    {
        [XmlAttribute(AttributeName = "deprecated")]
        public string Deprecated { get; set; }
    }

    [XmlRoot(ElementName = "valueChange")]
    public class ValueChange
    {
        [XmlAttribute(AttributeName = "duration")]
        public string Duration { get; set; }
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "low")]
    public class Low
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "high")]
    public class High
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "valuationRange")]
    public class ValuationRange
    {
        [XmlElement(ElementName = "low")]
        public Low Low { get; set; }
        [XmlElement(ElementName = "high")]
        public High High { get; set; }
    }

    [XmlRoot(ElementName = "zestimate")]
    public class Zestimate
    {
        [XmlElement(ElementName = "amount")]
        public Amount Amount { get; set; }
        [XmlElement(ElementName = "last-updated")]
        public string Lastupdated { get; set; }
        [XmlElement(ElementName = "oneWeekChange")]
        public OneWeekChange OneWeekChange { get; set; }
        [XmlElement(ElementName = "valueChange")]
        public ValueChange ValueChange { get; set; }
        [XmlElement(ElementName = "valuationRange")]
        public ValuationRange ValuationRange { get; set; }
        [XmlElement(ElementName = "percentile")]
        public string Percentile { get; set; }
    }

    [XmlRoot(ElementName = "region")]
    public class Region
    {
        [XmlElement(ElementName = "zindexValue")]
        public string ZindexValue { get; set; }
        [XmlElement(ElementName = "links")]
        public Links Links { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "localRealEstate")]
    public class LocalRealEstate
    {
        [XmlElement(ElementName = "region")]
        public Region Region { get; set; }
    }

    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlElement(ElementName = "zpid")]
        public string Zpid { get; set; }
        [XmlElement(ElementName = "links")]
        public Links Links { get; set; }
        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "zestimate")]
        public Zestimate Zestimate { get; set; }
        [XmlElement(ElementName = "localRealEstate")]
        public LocalRealEstate LocalRealEstate { get; set; }
    }

    [XmlRoot(ElementName = "results")]
    public class Results
    {
        [XmlElement(ElementName = "result")]
        public Result Result { get; set; }
    }

    [XmlRoot(ElementName = "response")]
    public class Response
    {
        [XmlElement(ElementName = "results")]
        public Results Results { get; set; }
    }



}