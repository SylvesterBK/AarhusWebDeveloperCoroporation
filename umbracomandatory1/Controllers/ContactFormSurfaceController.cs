using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umbracomandatory1.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using System.Net.Mail;
using umbracomandatory1.Controllers;


namespace umbracomandatory1.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {

            return PartialView("ContactForm", new ContactForm());

        }    
            
            [HttpPost]
            public ActionResult HandleFormSubmit(ContactForm model)
             {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }
            else
            {
                MailMessage message = new MailMessage();
                message.To.Add("eaasykj@students.eaaa.dk");
                message.Subject = model.Subject;
                message.From = new MailAddress(model.Email, model.Name);
                message.Body = model.Message;


                IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Message");
                comment.SetValue("messageName", model.Name);
                comment.SetValue("email", model.Email);
                comment.SetValue("subject", model.Subject);
                comment.SetValue("messageContent", model.Message);
                Services.ContentService.Save(comment);


                //Services.ContentService.SaveAndPublishWithStatus(comment);
                


                TempData["success"] = true;
                return RedirectToCurrentUmbracoPage();
            }
        }
        }
    }
}