using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using umbracomandatory1.ViewModels;
using Umbraco.Core.Services;

namespace umbracomandatory1.Controllers
{
    public class HandleFormSubmitController : Controller
    {
        // GET: HandleFormSubmit
        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }
            MailMessage message = new MailMessage();
            message.To.Add("eaasykj@students.eaaa.dk");
            message.Subject = model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;

            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Comment");
            comment.SetValue("name", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);
            Services.ContentServices.Save(comment);
            return RedirectToCurrentUmbracoPage();
        }
        //using{SmtpClient smtp = new stmpClient())
        //    {
        //        stmp.DeliveryMethod = StmpDeliveryMethod.Network;
        //        stmp.UseDefaultCredentials = false;
        //        stmp.EnableSsl = true;
        //        stmp.Host = "stmp.gmail.com";
        //        stmp.Port = 587;
        //        stmp.Credentials = new System.Net.NetworkCredential(")

        //        stmp.Send(message);
        //comment for git

    }
}