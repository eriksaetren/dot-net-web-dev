using PlanSimplyByCJ.FileHandler;
using PlanSimplyByCJ.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PlanSimplyByCJ.Controllers
{/*
    [RequireHttps]
    public class DIY_WeddingController : Controller
    {

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View("Home");
        }

        [HttpGet]
        public ActionResult About()
        {


            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }


        public ActionResult Gallery1()
        {
            string[] files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Wedding Pics/")));
            List<FileName> list = new List<FileName>();

            var index = files[0].IndexOf("\\Content");
            Hashtable captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/weddingCaptions.txt")));


            foreach (var item in files)
            {
                string tempItem = item.ToString().Substring(index);
                int i = tempItem.IndexOf("Pics\\");
                string head = tempItem.Substring(0, i + 5);
                string tail = tempItem.Substring(i + 5);
                tempItem = head + "Thumbnails\\" + tail;
                //Debug.WriteLine("Head = " + head + ", Tail = " + tail);

                list.Add(new FileName()
                {
                    fileName = item.ToString().Substring(index),
                    thumbnail = tempItem,
                    caption = captionMap[item.ToString().Substring(index)].ToString()
                });
            }



            return View(list);
        }

        public ActionResult Gallery2()
        {
            string[] files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Launch Party/")));
            List<FileName> list = new List<FileName>();

            var index = files[0].IndexOf("\\Content");
            //Hashtable captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/launchCaptions.txt")));


            foreach (var item in files)
            {

                string tempItem = item.ToString().Substring(index);
                int i = tempItem.IndexOf("Party\\");
                string head = tempItem.Substring(0, i + 5);
                string tail = tempItem.Substring(i + 5);
                tempItem = head + "\\Thumbnails" + tail;
                //Debug.WriteLine("Head = " + head + ", Tail = " + tail);
                Debug.WriteLine(item.ToString().Substring(index));

                list.Add(new FileName()
                {
                    fileName = item.ToString().Substring(index),
                    thumbnail = tempItem,
                    //caption = captionMap[item.ToString().Substring(index)].ToString()
                });
            }

            return View(list);
        }


        public ActionResult UpcomingClasses()
        {
            return View();
        }

        public ActionResult Sent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> About(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("plansimplybycj@gmail.com"));
                
                message.From = new MailAddress(HttpUtility.HtmlEncode(model.email));
                message.Subject = "Message from plansimplybycj.com";
                message.Body = HttpUtility.HtmlEncode(string.Format(body, model.name, model.email, model.message));
                message.IsBodyHtml = true;
                
                using (var smtp = new SmtpClient())
                { 
                    var credential = new NetworkCredential
                    {
                        UserName = "plansimplyemailservice@gmail.com",
                        Password = "ALFAxomail#29A12"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    try { 
                        await smtp.SendMailAsync(message);
                    }
                    catch
                    {
                        try
                        {  // Try with a different port
                            smtp.Port = 465;
                            await smtp.SendMailAsync(message);
                        }
                        catch
                        {
                            try
                            {  // try with a different smtp provider
                                smtp.Host = "smtp-mail.outlook.com";
                                credential = new NetworkCredential
                                {
                                    UserName = "erik_dawg@hotmail.com",
                                    Password = "BROKEN4life"
                                };
                                smtp.Credentials = credential;
                                await smtp.SendMailAsync(message);
                            }
                            catch
                            {   // Something went wrong - send user back to about page with same model and error message
                                ViewBag.Success = false;
                                ViewBag.Error = "Send failed - please try again";
                                return View("About", model);
                            }
                        }
                    }
                    
                }
                ViewBag.Success = true;
                ViewBag.Message = "Your message was sent";
                ModelState.Clear();
            }
            

            return View("About", new EmailForm()
            {
                email = "",
                message = "",
                name = ""
            });
        }
    }*/
}