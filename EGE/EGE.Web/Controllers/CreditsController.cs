using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EGE.Data;
using EGE.Data.Repositories;
using EGE.Models;
using EGE.Web.Models;
using Microsoft.AspNet.Identity;

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


        [HttpGet]
        public ActionResult Create()
        {
            return this.View(new CreditInputModel { IsUsed = false });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreditInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newCredit = Mapper.Map<Credit>(model);
            newCredit.OwnerId = User.Identity.GetUserId();
            newCredit.LastUsed = DateTime.Now;
            Data.Credits.Add(newCredit);

            Data.SaveChanges();
            return RedirectToAction("SearchResult");
        }

         public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = this.Data.Credits.GetById(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

       
        public ActionResult DeleteConfirm(int id)
        {
            var product = Data.Credits.GetById(id);
            Data.Credits.Delete(product);
            Data.Credits.SaveChanges();
            return this.RedirectToAction("SearchResult");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var credit = this.Data.Credits
                .All().
                Where(x => x.Id == id)
                .ProjectTo<CreditInputModel>()
                .FirstOrDefault();

            if (credit == null)
            {
               throw new HttpException(404, "Credit not found");
            }
            return this.View(credit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreditInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dbCredit = this.Data.Credits.GetById(model.Id);
            if (dbCredit == null)
            {
                throw new HttpException(404, "Credit not found");
            }

            dbCredit.Barcode = model.Barcode;
            dbCredit.IsUsed = model.IsUsed;
            dbCredit.LastUsed = model.LastUsed;
            dbCredit.OwnerId = model.OwnerId;
            dbCredit.Sum = model.Sum;
            dbCredit.Type = model.Type;

            Data.SaveChanges();
            return RedirectToAction("SearchResult");
        }
    }
    
}