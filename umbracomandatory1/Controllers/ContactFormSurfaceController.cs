using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umbracomandatory1.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace umbracomandatory1.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            
            TempData["success"] = true;
            return PartialView("ContactForm", new ViewModels.ContactForm());
        }
    }
}