using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApplication.ViewModel
{
    public class SampleViewModel
    {
        public Sample Sample { get; set; }
        public IEnumerable<SelectListItem> EngineCC { get; set; }
    }
}