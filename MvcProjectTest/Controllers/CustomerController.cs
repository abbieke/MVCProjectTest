using MvcProjectTest.Models;
using MvcProjectTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectTest.Controllers
{
    public class CustomerController : Controller
    {
        public readonly CustomersRepository _repo;
        public CustomerController()
        {
            _repo = new CustomersRepository();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            ViewData["Titlett"] = "會員註冊";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(string CustomerName, string CustomerAccount, string CustomerPassword, string ConfirmPassword, string CustomerEmail, string CustomerPhone, DateTime CustomerBirth, string CustomerAddress)
        {
            if(String.IsNullOrEmpty(ConfirmPassword))
            {
                return Content("未確認密碼");
            }
            else
            {
                if (CustomerAccount == CustomerPassword)
                {
                    return Content("帳號密碼不可相同");
                }
                else
                {
                    if (CustomerPassword == ConfirmPassword)
                    {
                        Customer cust = new Customer { CustomerName = CustomerName, CustomerAddress = CustomerAddress, CustomerAccount = CustomerAccount, CustomerPassword = SHA256(CustomerPassword), CustomerEmail = CustomerEmail, CustomerBirth = CustomerBirth, CustomerPhone = CustomerPhone };
                        _repo.InsertCustomer(cust);
                        return RedirectToAction("Index");
                    }
                    return Content("密碼不符");
                }
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string CustomerAccount, string CustomerPassword)
        {
            return View();
        }

        public static string SHA256(string original)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256
            byte[] source = Encoding.Default.GetBytes(original);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            return result;

        }
    }
}