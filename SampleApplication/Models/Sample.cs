using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Models
{
    public class Sample
    {
        public int Id  { get; set; } 
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Mileage { get; set; }

        public string EngineCC { get; set; }
    }
}