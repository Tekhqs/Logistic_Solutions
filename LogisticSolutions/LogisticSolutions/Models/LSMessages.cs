using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticSolutions.Models
{
    public class LSMessages
    {
        public string message { get; set; }
        public bool status { get; set; } = false;
        public bool unknownStatus { get; set; } = false;
        public string unknownMessage { get; set; }
    }
}