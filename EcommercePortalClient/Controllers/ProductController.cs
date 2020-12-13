using EcommercePortalClient.Models;
using EcommercePortalClient.Models.ViewModels;
using EcommercePortalClient.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortalClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductProvider _provider;
        private log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(ProductController));
        public ProductController(IProductProvider provider)
        {
            this._provider = provider;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult GetId()
        {
            return View();
        }
        public IActionResult GetName()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetProductById(int Id)
        {
            _logger.Info("Products with id-"+Id+" are getting displayed ");
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else 
            {
                Product prod = new Product();
                try
                {
                    var response = await _provider.GetProductById(Id);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var JsonContent = await response.Content.ReadAsStringAsync();
                        prod = JsonConvert.DeserializeObject<Product>(JsonContent);
                        return View(prod);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ViewBag.Message = "No any record Found! Bad Request";
                        return View(prod);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        ViewBag.Message = "Having server issue while adding record";
                        return View(prod);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ViewBag.Message = "No record found in DB for ID :" + Id;
                        return View(prod);
                    }
                }
                catch (Exception e)
                {
                    _logger.Error("Exception occured as :" + e.Message);
                }
                return View(prod);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string Name)
        {
            _logger.Info("Products with name-" + Name + " are getting displayed ");
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                Product prod = new Product();
                try
                {
                    var response = await _provider.GetProductByName(Name);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var JsonContent = await response.Content.ReadAsStringAsync();
                        prod = JsonConvert.DeserializeObject<Product>(JsonContent);
                        return View(prod);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ViewBag.Message = "No any record Found! Bad Request";
                        return View(prod);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        ViewBag.Message = "Having server issue while adding record";
                        return View(prod);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ViewBag.Message = "No record found in DB for Name :" + Name;
                        return View(prod);
                    }
                }
                catch (Exception e)
                {
                    _logger.Error("Exception occured as :" + e.Message);
                }
                return View(prod);
            }
        }

        [HttpGet]
        public IActionResult RateAProduct()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RateAProduct(ProductViewModel model)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else 
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                RatingStatusViewModel status = new RatingStatusViewModel();
                try
                {
                    var response = await _provider.RateAProduct(model);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsoncontent = await response.Content.ReadAsStringAsync();
                        status = JsonConvert.DeserializeObject<RatingStatusViewModel>(jsoncontent);
                        return View("RatingAdded", status);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        ModelState.AddModelError("", "Having server issue while adding rating");
                        return View(model);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", "Invalid model states");
                        return View(model);
                    }
                }
                catch (Exception e)
                {
                    _logger.Error("Exception Occured as : " + e.Message);
                }
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult RatingAdded()
        {
            RatingStatusViewModel model = new RatingStatusViewModel();
            return View(model);
        }
    }
}
