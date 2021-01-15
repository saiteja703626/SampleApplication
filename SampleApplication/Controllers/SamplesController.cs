using SampleApplication.Models;
using SampleApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApplication.Controllers
{
    public class SamplesController : Controller
    {

            private ApplicationDbContext dbContext = null;

            public SamplesController()
            {
                dbContext = new ApplicationDbContext();
            }

            protected override void Dispose(bool disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }
                base.Dispose(disposing);
            }
            

        public ActionResult Index()
        {
            List<Sample> samples = GetSamples();
            return View(samples);
        }

        public List<Sample> GetSamples()
        {
            return dbContext.Samples.ToList();
        }


        [HttpGet]
            public ActionResult Details(int? id)
            {
                Sample sample = new Sample();
                SampleViewModel viewModel = new SampleViewModel
                {
                    Sample = sample,
                    EngineCC = GetEngineCC()
                };
                return View("Details", viewModel);
            }

            [HttpPost]
            public ActionResult Details(Sample sample)
            {
                if (!ModelState.IsValid)
                {
                    var ViewModel = new SampleViewModel
                    {
                        Sample = new Sample(),
                        EngineCC = GetEngineCC()
                    };
                    return View("Details", ViewModel);
                }
                dbContext.Samples.Add(sample);
                dbContext.SaveChanges();
                return RedirectToAction("Details", "Samples");
            }

            public IEnumerable<SelectListItem> GetEngineCC()
            {
                return new List<SelectListItem>
             {
                new SelectListItem{Text="--Select CC--",Disabled=true},
                new SelectListItem{Text="650",Value="650"},
                new SelectListItem{Text="350",Value="350"}
             };
            }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sample = dbContext.Samples.SingleOrDefault(x => x.Id == id);
            if (sample != null)
            {
                var ViewModel = new SampleViewModel
                {
                    Sample = sample,
                };
                return View(ViewModel);
            }
            return HttpNotFound("Sample Id Dosen't Exists");
        }

        [HttpPost]
        public ActionResult Edit(int id, Sample sample)
        {
            var SampleInDb = dbContext.Samples.SingleOrDefault(x => x.Id == id);
            if (SampleInDb != null)
            {
                SampleInDb.Brand = sample.Brand;
                SampleInDb.Model = sample.Model;
                SampleInDb.DeliveryDate = sample.DeliveryDate;
                SampleInDb.Mileage = sample.Mileage;
                SampleInDb.EngineCC = sample.EngineCC;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Samples");
            }
            return HttpNotFound();
        }

    }
}