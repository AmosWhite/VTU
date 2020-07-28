using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amos.VTUCORE3._1.Models.BLL.Interface;
using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Amos.VTUCORE3._1.Controllers
{
    public class ProductController : Controller

    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<UserProfile> userManager;
        private readonly ILogger<ProductController> logger;
        private readonly IProductBussiness _productBussiness;
        private readonly IAirtimeBussiness _airtimeBussiness;

        public ProductController(RoleManager<IdentityRole> roleManager,
                               UserManager<UserProfile> userManager,
                               ILogger<ProductController> logger,
                               IProductBussiness serviceBussiness,
                               IAirtimeBussiness airtimeBussiness)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.logger = logger;
            this._productBussiness = serviceBussiness;
            this._airtimeBussiness = airtimeBussiness;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListProducts()
        {
            IEnumerable<ProductVm> model = _productBussiness.GetAllProducts();
            return View(model);
        }

        [AcceptVerbs("Get","Post")]
        public ActionResult ProductDetails(int id)
        {
            switch (id)
            {
                // for Airtime
                case 1:
                    var model = _airtimeBussiness.GetAirtimeDetails(id);
                    return View("AirtimeDetails", model);

                case 2:
                    ViewBag.ErrorMessage = "Product Not Found";
                    return NotFound("Not Yet Implemented");
                    

                case 3:
                    ViewBag.ErrorMessage = "Product Not Found";
                    return View("NotFound");

                default:
                    ViewBag.ErrorMessage = "Product Not Found";
                    return View("NotFound");
                    
            }
           

        }
        [HttpGet]
        public IActionResult EditAirtimeDetails(int id)
        {
            var model = _airtimeBussiness.GetAirtimeDetailById(id);

            if (model == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            return PartialView("_EditAirtimeDetails", model);
        }
        [HttpPost]
        public ActionResult EditAirtimeDetails(AirtimeDetailsVM model)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("_EditAirtimeDetails", model);
            }
            //retriev service from db
            bool response = _airtimeBussiness.EditAirtimeDetails(model);

            // check if service is empty
            if (response)
            {
                return PartialView("_EditAirtimeDetails", model);
            }
            ModelState.AddModelError("", "An Error occur, please make sure description is unique");
            return View("_EditAirtimeDetails", model);
        }

       
    }
}
