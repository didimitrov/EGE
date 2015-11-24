using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGE.Data;
using EGE.Data.Repositories;
using EGE.Models;
using EGE.Web.Models;

namespace EGE.Web.Controllers
{
    public class CreditsController : BaseController
    {
        private readonly IRepository<Credit> _credits;

        public CreditsController(IRepository<Credit> credits)
        {
            _credits = credits;
        }

        //
        // GET: /Credits/
        public ActionResult Index()
        {
            return RedirectToAction("SearchResult");
        }

        [HttpGet]
        public ActionResult SearchResult(CreditSearchModel model)
        {
          
            model.Credits = _credits.All()
                    .Where(x => model.Barcode == null || x.Barcode.Contains(model.Barcode))                                          
                    .ToList();  
              

            // total records for paging
            model.TotalRecords = _credits.All()
                .Count(x =>
                    (model.Barcode == null || x.Barcode.Contains(model.Barcode)));

            return View(model);
        }
    }
}