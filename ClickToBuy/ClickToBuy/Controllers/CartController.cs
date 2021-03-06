﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using ClickToBuy.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class CartController : Controller
    {
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly IProductManager _iProductManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IProductPhotoManager _iProductPhotoManager;
        private readonly ICityManager _iCityManager;
        private readonly IOrderManager _iOrderManager;
        private readonly IOrderDetailsManager _iOrderDetailsManager;
        private readonly ICustomerBillingAddressesManager _iCustomerBillingAddressesManager;
        private readonly IDeliveryChargeManager _iDeliveryChargeManager;

        public CartController(IPurchaseItemManager iPurchaseItemManager, IProductManager iProductManager,
            ICategoryManager iCategoryManager, IProductPhotoManager iProductPhotoManager,
            ICityManager iCityManager, IOrderManager iOrderManager, IOrderDetailsManager iOrderDetailsManager,
            ICustomerBillingAddressesManager iCustomerBillingAddressesManager,
            IDeliveryChargeManager iDeliveryChargeManager)
        {
            _iPurchaseItemManager = iPurchaseItemManager;
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
            _iProductPhotoManager = iProductPhotoManager;
            _iCityManager = iCityManager;
            _iOrderManager = iOrderManager;
            _iOrderDetailsManager = iOrderDetailsManager;
            _iCustomerBillingAddressesManager = iCustomerBillingAddressesManager;
            _iDeliveryChargeManager = iDeliveryChargeManager;
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
            ViewBag.ConditionList = getConditionForShowClinteSiteProduct.Distinct().ToList();
            ViewBag.ProductPhotos = _iProductPhotoManager.GetAll();

            List<SelectListItem> citys = _iCityManager.GetAll()
                .Select(c => new SelectListItem {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            ViewBag.Citys = citys;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                List<AddProductViewModel> addProducts = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");

                if (addProducts == null)
                    addProducts = new List<AddProductViewModel>();

                CommonComponent();
                return View(addProducts);
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult AddProduct(int? id, int? quantity)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                Product selectedProductInfo = _iProductManager.GetById(id);

                if (selectedProductInfo == null)
                    return NotFound();

                AddProductViewModel addProductViewModel = new AddProductViewModel
                {
                    Id = selectedProductInfo.Id,
                    Name = selectedProductInfo.Name,
                    Price = (float)(selectedProductInfo.OfferPrice <= 0 ? selectedProductInfo.RegularPrice : selectedProductInfo.OfferPrice),
                    Quantity = 1
                };

                List<AddProductViewModel>  addProducts = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");

                if (addProducts == null)
                    addProducts = new List<AddProductViewModel>();

                AddProductViewModel existProduct = addProducts.Where(ap => ap.Id == id).FirstOrDefault();

                if (existProduct != null)
                {
                    addProducts.Remove(existProduct);

                    if (quantity == null)
                        existProduct.Quantity += 1;
                    else
                        existProduct.Quantity = existProduct.Quantity + (int)quantity;

                    addProducts.Add(existProduct);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }
                else
                {
                    if (quantity == null)
                        addProductViewModel.Quantity = 1;
                    else
                        addProductViewModel.Quantity = (int)quantity;

                    addProducts.Add(addProductViewModel);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Update(int[] quantity)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                List<AddProductViewModel> addProductList = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");

                for (int i = 0; i < addProductList.Count(); i++)
                {
                    addProductList[i].Quantity = quantity[i];
                }

                HttpContext.Session.Set("AddProducts", addProductList);
                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                List<AddProductViewModel> products = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");
                AddProductViewModel existProduct = products.Where(p => p.Id == id).FirstOrDefault();
                products.Remove(existProduct);
                HttpContext.Session.Set("AddProducts", products);

                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetChargeByCityId(int id)
        {
            DeliveryCharge productDeliveryChardeInfo = _iDeliveryChargeManager.GetAll()
                .Where(dc => dc.CityId == id).FirstOrDefault();
            float deliveryCharge = productDeliveryChardeInfo.Ammount;
            return Json(deliveryCharge);
        }

        [HttpPost]
        public IActionResult Checkout(CustomerBillingAddress customerBillingAddress, DeliveryCharge deliveryCharge)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                int loginCustomerId = Convert.ToInt32(HttpContext.Session.GetString("CustomerId"));
                Order lastOrderInfo = _iOrderManager.GetAll().LastOrDefault();

                if (lastOrderInfo == null)
                {
                    lastOrderInfo = new Order();
                    lastOrderInfo.OrderNo = "10001";
                }

                int conOrderNoInt = Convert.ToInt32(lastOrderInfo.OrderNo);
                conOrderNoInt = conOrderNoInt + 1;

                CustomerBillingAddress customerOrderBillingAddress = new CustomerBillingAddress()
                {
                    CustomerId = loginCustomerId,
                    BillingAddress = customerBillingAddress.BillingAddress,
                };

                bool isSaveCustomerBillingAddress = _iCustomerBillingAddressesManager.Add(customerOrderBillingAddress);
                customerBillingAddress = _iCustomerBillingAddressesManager.GetAll().LastOrDefault();
                Order customerOrder = new Order()
                {
                    OrderNo = conOrderNoInt.ToString(),
                    CustomerId = loginCustomerId,
                    CustomerBillingAddressId = customerBillingAddress.Id,
                    CouponNumber = "Na",
                    DeliveryChargeId = deliveryCharge.CityId,
                    Status = false,
                    OrderDate = DateTime.Now.Date
                };                

                bool isSaveCustomerOrder = _iOrderManager.Add(customerOrder);                
                bool isSaveCustomerOrderDetails = false;

                List<AddProductViewModel> addProducts = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");
                lastOrderInfo = _iOrderManager.GetAll().LastOrDefault();
               
                foreach (AddProductViewModel product in addProducts)
                {
                    OrderDetails customerOrderDetails = new OrderDetails()
                    {
                        OrderId = lastOrderInfo.Id,
                        ProductId = product.Id,
                        Quantity = product.Quantity
                    };

                    isSaveCustomerOrderDetails = _iOrderDetailsManager.Add(customerOrderDetails);
                }

                if (isSaveCustomerOrder && isSaveCustomerOrderDetails && isSaveCustomerBillingAddress)
                {
                    HttpContext.Session.Remove("AddProducts");
                    return RedirectToAction("InvoiceManagement", "Customer");
                }
                else
                {
                    ViewBag.ErrorMessage = "Chack out is failed! Try Again";
                    return View("Index");
                }
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }
    }
}
