using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using AutoMapper;
using MalweeCodeChallenge.Controllers.Filters;
using MalweeCodeChallenge.Core.Contracts.DataObjects;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Entities;
using MalweeCodeChallenge.Core.Helper;
using MalweeCodeChallenge.Core.Infra.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MalweeCodeChallenge.Controllers
{
    [System.Web.Mvc.Authorize]
    public class ServiceProvidedsController : Controller
    {
        private readonly IServiceProvidedService _serviceProvidedService;

        public ServiceProvidedsController(IServiceProvidedService supplierService)
        {
            _serviceProvidedService = supplierService;
        }
        // GET: ServiceProvideds
        public ActionResult Index()
        {
            var filterTypeEnumData = from FilterTypeEnum e in Enum.GetValues(typeof(FilterTypeEnum))
                select new
                {
                    ID = e.GetHashCode(),
                    Name = e.GetDescription()
                };
            ViewBag.FilterTypeEnum = new SelectList(filterTypeEnumData, "ID", "Name");


            ViewBag.SericesProvieds = _serviceProvidedService.GetAllServicesProvieds();
            return View(_serviceProvidedService.GetAllServicesProvieds().ToList());
        }

        // POST: ServiceProvideds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ErrorHandler]
        public ActionResult  Filter(FilterServicesDto filterDto)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    var filteredList = _serviceProvidedService.ServicesFiltered(filterDto.FilterType,filterDto.FilterValue).ToList();
                    return
                        PartialView("_Grid",filteredList);
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Erro: "+e.Message);
                }
            }

            throw new ApplicationException("Preencha os campos corretamente.");


        }

        // GET: ServiceProvideds/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ServiceProvided serviceProvided = db.ServiceProvideds.Find(id);
        //    if (serviceProvided == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(serviceProvided);
        //}

        // GET: ServiceProvideds/Create
        public ActionResult Create()
        {
            var servicesEnumData = from ServiceEnum e in Enum.GetValues(typeof(ServiceEnum))
                select new
                {
                    ID = e.GetHashCode(),
                    Name = e.GetDescription()
                };
            ViewBag.ServicesEnum = new SelectList(servicesEnumData, "ID", "Name");

            return View();
        }

        // POST: ServiceProvideds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ErrorHandler]
        [ValidateAntiForgeryToken]
        public ActionResult  Create(ServiceProvidedDto serviceProvided)
        {
            if (ModelState.IsValid)
            {
                serviceProvided.UpdateDate = DateTime.Now;
                serviceProvided.UpdateUser = User.Identity.GetUserName();
                serviceProvided.ServiceProvidedClientId = User.Identity.GetUserId<string>();

                try
                {
                  
                    _serviceProvidedService.Insert(serviceProvided);
                    return Json(new { success = true });
                }
                catch (Exception e)
                {   
                    throw new ApplicationException("Erro: "+e.Message);
                }
            }

            throw new ApplicationException("Preencha os campos corretamente.");


        }

        //// GET: ServiceProvideds/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ServiceProvided serviceProvided = db.ServiceProvideds.Find(id);
        //    if (serviceProvided == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(serviceProvided);
        //}

        //// POST: ServiceProvideds/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Description,DateOfService,Value,Service,UpdateDate,UpdateUser")] ServiceProvided serviceProvided)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(serviceProvided).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(serviceProvided);
        //}

        //// GET: ServiceProvideds/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ServiceProvided serviceProvided = db.ServiceProvideds.Find(id);
        //    if (serviceProvided == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(serviceProvided);
        //}

        //// POST: ServiceProvideds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    ServiceProvided serviceProvided = db.ServiceProvideds.Find(id);
        //    db.ServiceProvideds.Remove(serviceProvided);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _supplierService.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
