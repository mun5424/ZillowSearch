using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZillowSearch.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
    }
}