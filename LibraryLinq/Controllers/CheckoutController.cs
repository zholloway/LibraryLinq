using LibraryLinq.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LibraryLinq.Controllers
{
    public class CheckoutController : ApiController
    {
        CheckoutServices checkoutServices = new CheckoutServices();

        // GET: Checkout
        public IHttpActionResult Get(string status = "")
        {
            if(status == "CheckedOut")
            {
                return Ok(checkoutServices.GetCheckedOutBooks());
            }
            else if(status == "Available")
            {
                return Ok(checkoutServices.GetAvailableBooks());
            }
            else
            {
                return Ok("Checkout status of books required.");
            }
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CheckOutBook(int id)
        {
            checkoutServices.CheckOutBook(id);
            return Ok("Checked out.");
        }
    }
}