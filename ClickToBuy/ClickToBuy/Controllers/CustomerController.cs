﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _iCustomerManager;
        private readonly ICountryManager _iCountryManager;
        private readonly ICityManager _iCityManager;
        private readonly IGenderManager _iGenderManager;
        private IHttpContextAccessor _iAccessor;
        private readonly IProductManager _iProductManager;
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IOrderManager _iOrderManager;
        private readonly IOrderDetailsManager _iOrderDetailsManager;
        private readonly ICustomerBillingAddressesManager _iCustomerBillingAddressesManager;

        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public CustomerController(ICustomerManager iCustomerManager, 
                                  ICountryManager iCountryManager,
                                  ICityManager iCityManager, 
                                  IGenderManager iGenderManager, 
                                  IHostingEnvironment iHostingEnvironment, IHttpContextAccessor iAccessor,
                                  IPurchaseItemManager iPurchaseItemManager, IProductManager iProductManager,
                                  ICategoryManager iCategoryManager,
                                  IOrderManager iOrderManager, IOrderDetailsManager iOrderDetailsManager,
                                  ICustomerBillingAddressesManager iCustomerBillingAddressesManager)
        {
            _iCustomerManager = iCustomerManager;
            _iCountryManager = iCountryManager;
            _iCityManager = iCityManager;
            _iGenderManager = iGenderManager;
            _iHostingEnvironment = iHostingEnvironment;
            _iPurchaseItemManager = iPurchaseItemManager;
            _iProductManager = iProductManager;
            _iAccessor = iAccessor;
            _iCategoryManager = iCategoryManager;
            _iOrderManager = iOrderManager;
            _iOrderDetailsManager = iOrderDetailsManager;
            _iCustomerBillingAddressesManager = iCustomerBillingAddressesManager;
        }

        private Customer LoginCustomerInfo()
        {
            int customerId = Convert.ToInt32(HttpContext.Session.GetString("CustomerId"));
            Customer aLoginCustomerInfo = _iCustomerManager.GetById(customerId);
            return aLoginCustomerInfo;
        }

        private ICollection<Product> ShowClinteSiteProduct()
        {
            ICollection<PurchaseItem> getAllPurchaseItem = _iPurchaseItemManager.GetAll();
            List<Product> storePurchaseProduct = new List<Product>();

            foreach (PurchaseItem item in getAllPurchaseItem)
            {
                Product purchaseProductDetails = _iProductManager.GetById(item.ProductId);
                storePurchaseProduct.Add(purchaseProductDetails);
            }

            List<Product> removeDuplicateProductForPurchaseProduct = storePurchaseProduct.Distinct().ToList();
            return removeDuplicateProductForPurchaseProduct;
        }

        private void CommonComponent()
        {
            ViewBag.ClinteProductList = ShowClinteSiteProduct();
            List<Brand> getBrandForShowClinteSiteProduct = new List<Brand>();
            List<Condition> getConditionForShowClinteSiteProduct = new List<Condition>();

            foreach (Product product in ViewBag.ClinteProductList)
            {
                getBrandForShowClinteSiteProduct.Add(product.Brand);
                getConditionForShowClinteSiteProduct.Add(product.Condition);
            }

            ViewBag.BrandList = getBrandForShowClinteSiteProduct.Distinct().ToList();
            ViewBag.CategoryList = _iCategoryManager.GetCategoryForPurchaseProduct();
            ViewBag.Condition = getConditionForShowClinteSiteProduct.Distinct().ToList();
        }

        private List<SelectListItem> CountryList()
        {
            List<SelectListItem> countryList = _iCountryManager.GetAll()
                                               .Select(c => new SelectListItem
                                               {
                                                   Value = c.Id.ToString(),
                                                   Text = c.Name
                                               }).ToList();
            return countryList;
        }

        private List<SelectListItem> CityList()
        {
            List<SelectListItem> cityList = _iCityManager.GetAll()
                                               .Select(c => new SelectListItem
                                               {
                                                   Value = c.Id.ToString(),
                                                   Text = c.Name
                                               }).ToList();
            return cityList;
        }

        private List<SelectListItem> GenderList()
        {
            List<SelectListItem> genderList = _iGenderManager.GetAll()
                                               .Select(c => new SelectListItem
                                               {
                                                   Value = c.Id.ToString(),
                                                   Text = c.Name
                                               }).ToList();
            return genderList;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                CommonComponent();
                return View();
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.Orders = _iOrderManager.GetAll();
                return View(_iCustomerManager.GetAll());
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.CountryList = CountryList();
                ViewBag.GenderList = GenderList();
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckContact(string contactno)
        {
            Customer checkContact = _iCustomerManager.CheckContact(contactno);

            if (checkContact != null)
                return Json(1);
            else
                return Json(0);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckEmail(string email)
        {
            Customer checkEmail = _iCustomerManager.CheckEmail(email);

            if (checkEmail != null)
                return Json(1);
            else
                return Json(0);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetCityByCountry(int countryId)
        {
            List<City> cityByCountryId = _iCityManager.FindCityByCountryId(countryId);
            return Json(cityByCountryId);
        }

        [Obsolete]
        private bool IsAddCustomer(Customer aCustomerInfo, IFormFile picture)
        {
            aCustomerInfo.CustomerIPAddress = _iAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            aCustomerInfo.JoinDate = DateTime.Now.Date;

            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/customerpicture",
                                                  Path.GetFileName(picture.FileName));
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aCustomerInfo.Pictuer = "customerPicture/" + picture.FileName;
                }

                if (picture == null)
                    aCustomerInfo.Pictuer = "customerpicture/NoImageFound.png";

                return _iCustomerManager.Add(aCustomerInfo);
            }

            return false;
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(Customer aCustomer, IFormFile pictuer)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                bool isAdd = IsAddCustomer(aCustomer, pictuer);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Customer save has been failed!";

                ViewBag.CountryList = CountryList();
                ViewBag.GenderList = GenderList();
                return View(aCustomer);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Registration(Customer aCustomerInfo, IFormFile picture)
        {
            bool isRegister = IsAddCustomer(aCustomerInfo, picture);

            if (isRegister)
                return RedirectToAction("CustomerLogin", "LoginProcess");
            else
                ViewBag.ErrorMessage = "Registration save has been failed!";

            ViewBag.CountryList = CountryList();
            ViewBag.GenderList = GenderList();
            return View(aCustomerInfo);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                Customer loginCustomerInfo = LoginCustomerInfo();
                CommonComponent();
                ViewBag.CountryList = CountryList();
                ViewBag.CityList = CityList();
                ViewBag.GenderList = GenderList();
                return View(loginCustomerInfo);
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(Customer aCustomerInfo, IFormFile photo, string pic)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/customerpicture",
                                                  Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aCustomerInfo.Pictuer = "customerpicture/" + photo.FileName;
                }

                if (photo == null)
                    aCustomerInfo.Pictuer = pic;

                bool isUpdate = _iCustomerManager.Update(aCustomerInfo);

                if (isUpdate)
                {
                    CommonComponent();
                    return RedirectToAction("Profile");
                }
                    
                else
                    ViewBag.ErrorMessage = "Admin update has been failed!";
            }

            CommonComponent();
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Customer aCustomerDetails = _iCustomerManager.GetById(id);

                if (aCustomerDetails == null)
                    return NotFound();

                return View(aCustomerDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(Customer aCustomerDetails)
        {
            bool isRemove = _iCustomerManager.Remove(aCustomerDetails);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Customer remove has been failed!";
        }

        [HttpGet]
        public IActionResult InvoiceManagement()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                ICollection<Order> cutomerOrder = _iOrderManager.GetAll()
                    .Where(o => o.CustomerId == LoginCustomerInfo().Id).ToList();
                CommonComponent();

                return View(cutomerOrder);
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult InvoiceDetails(int? id)
        { 
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                ICollection<OrderDetails> customerOrderDetails = _iOrderDetailsManager.GetAll()
                    .Where(od => od.OrderId == id).ToList();

                Order customerOrderInfo = _iOrderManager.GetById(id);
                CustomerBillingAddress customerBillingAddress = _iCustomerBillingAddressesManager.GetAll()
                    .Where(cba => cba.CustomerId == LoginCustomerInfo().Id).LastOrDefault();

                if (customerBillingAddress == null)
                    customerBillingAddress = new CustomerBillingAddress();

                if (customerOrderInfo == null)
                    return NotFound();

                CommonComponent();
                ViewBag.CustomerInfo = LoginCustomerInfo();
                ViewBag.CustomerOrderInfo = customerOrderInfo;
                ViewBag.CustomerBillingAddress = customerBillingAddress;
                return View(customerOrderDetails);
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }
    }
}