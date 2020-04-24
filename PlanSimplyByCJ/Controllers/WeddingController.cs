using PlanSimplyByCJ.ActionFilters;
using PlanSimplyByCJ.FileHandler;
using PlanSimplyByCJ.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace PlanSimplyByCJ.Controllers
{
    [RequireHttps]  
    public class WeddingController : Controller
    {


        [OutputCache(Duration = 9999, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Services()
        {
            return View();
        }

        [OutputCache(Duration = 9999, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Home()
        {
            return View("Home");
        }

        [HttpGet]
        [ActionName("contact")]
        [OutputCache(Duration = 9999, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult About()
        {
            return View("about");
        }
        
        [OutputCache(Duration = 9999, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Gallery()
        {
            return View("gallery");
        }
        
        [OutputCache(Duration = 1, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult GalleryAlbum(string albumname)
        {
            // Lists that will get assigned to the model:
            List<string> fileList = new List<string>();
            List<string> captionList = new List<string>();
            List<string> thumbnailList = new List<string>();

            GalleryModel galleryModel = new GalleryModel();
            Hashtable captionMap = new Hashtable();
            string[] files = null;
            string splitTerm = "";
            string descriptions = "";
            string title = "";
            Dictionary<string, string[]> accredits = null;

            switch (albumname)  //      Adding a new gallery page / album? Do it here:
            {
                case "cj-and-eriks-wedding":
                    title = "Rustic & Romantic Fall Wedding";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Wedding Pics/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/weddingCaptions.txt")));
                    descriptions = "cj-and-eriks-wedding";
                    splitTerm = "Pics\\";
                    break;
                case "plansimply-launch-party":
                    title = "PlanSimply Launch Party";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Launch Party/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/launchCaptions.txt")));
                    descriptions = "plansimply-launch-party";
                    splitTerm = "Party\\";
                    break;
                case "beach-themed-party":
                    title = "Birthday Beach Bash";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Beach Party/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/beachpartyCaptions.txt")));
                    descriptions = "cyds-beach-themed-party";
                    splitTerm = "Party\\";
                    break;
                case "behind-the-scenes":
                    title = "Behind The Scenes";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Behind the Scenes/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/btsCaptions.txt")));
                    descriptions = "je-amie-styled-shoot behind-the-scenes";
                    splitTerm = "Scenes\\";
                    accredits = new Dictionary<string, string[]>
                    {
                        { "Photography", new string[] { "La Brisa Photography", "http://www.labrisaphotography.com" } }
                    };
                    break;
                case "je-amie-styled-shoot":
                    title = "Je T'aime Summer Shoot";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Je Amie Styled Shoot/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/styledShootCaptions.txt")));
                    descriptions = "je-amie-styled-shoot";
                    splitTerm = "Shoot\\";
                    accredits = new Dictionary<string, string[]>
                    {
                        { "Planner / Stylist", new string[] { "PlanSimply by CJ", "http://plansimplybycj.com" } },
                        { "Photographer", new string[] { "Amanda Bynum Photography", "http://www.amandabynum.com" } },
                        { "Venue", new string[] { "The Carriage House", "http://carriagehousetucson.com/" } },
                        { "Tuxedos", new string[] { "Top Hat Formal", "http://tophattuxedos.com/" } },
                        { "Cake", new string[] { "Ambrosia Cakes of Tucson", "https://ambrosiaoftucson.com/" } },
                        { "Florals", new string[] { "Alexis Grace Floral", "http://www.alexisgraceflorals.com/" } },
                        { "Invitations", new string[] { "Jona Bustamante", "http://www.jbustamante.com/" } },
                        { "Gown", new string[] { "J Bridal", "http://www.jbridalboutique.com/" } },
                        { "Bridesmaids Dresses", new string[] { "J Bridal", "http://www.jbridalboutique.com/" } },
                        { "Hair and Makeup", new string[] { "The Powder Room", "https://www.powderroombridal.com/" } },
                        { "Macarons", new string[] { "Woops!", "https://bywoops.com/" } }
                    };
                    break;
                case "downtown-summer-engagement":
                    title = "Downtown Summer Engagement";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Downtown Summer Engagement/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/engagementCaptions.txt")));
                    descriptions = "downtown-summer-engagement";
                    splitTerm = "Engagement\\";
                    accredits = new Dictionary<string, string[]>
                    {
                        { "Photography", new string[] { "Amanda Bynum Photography", "http://www.amandabynum.com" } },
                        { "Florals", new string[] { "Alexis Grace Florals", "http://www.alexisgraceflorals.com/" } },
                        { "Hair and Makeup", new string[] { "The Powder Room", "https://www.powderroombridal.com/" } }
                    };
                    break;
                case "farmer-wedding":
                    title = "Farmer Wedding";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Farmer Wedding/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/farmerWeddingCaptions.txt")));
                    descriptions = "Farmer Wedding";
                    splitTerm = "Wedding\\";
                    accredits = new Dictionary<string, string[]>
                    {
                        { "HMUA", new string[] { "Chrissy at Bombshell 7", "http://www.bombshell7.com/" } },
                        { "Cake", new string[] { "Nadines", "http://nadinesweddingcakes.blogspot.com/" } },
                        { "Florist", new string[] { "Posh Petals", "http://www.petalspetalspetals.com/" } },
                        { "Venue", new string[] { "The Stillwell House", "http://www.stillwellhouse.com/" } },
                        { "Planner", new string[] { "PlanSimply by CJ", "https://plansimplybycj.com/" } },
                        { "DJ/Up lighting", new string[] { "Michael Lopez", "https://www.mastermixxaz.com/" } },
                        { "Photographer", new string[] { "Amanda Bynum", "" } }
                    };
                    break;
                case "sonora-southwest":
                    title = "Sonora Southwest";
                    files = Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Images/Sonora Southwest/")));
                    captionMap = CSVHandler.csvToHash(Server.MapPath(Url.Content("~/Content/CSV docs/sonoraSouthwestCaptions.txt")));
                    descriptions = "Sonora Southwest";
                    splitTerm = "Southwest\\";
                    accredits = new Dictionary<string, string[]>
                    {
                        { "Venue", new string[] { "The Stillwell House", "http://www.stillwellhouse.com/" } },
                        { "Wedding Dresses", new string[] { "Martin McCrea", "https://www.martinmccrea.com/" } },
                        { "Florals", new string[] { "Bloom and Blueprint", "http://bloomandblueprint.com/" } },
                        { "Cake", new string[] { "Dessert First by Veronica", "https://www.dessertfirstbyveronica.com/" } },
                        { "Calligraphy", new string[] { "Modern Aquarian", "http://www.modernaquarian.com/" } },
                        { "Tuxedos", new string[] { "Tux on Broadway", "http://tuxedosonbroadwayaz.com/" } },
                        { "Jewelry", new string[] { "Solene Dejean", "http://solenedejean.com/" } },
                        { "Flower Backdrop", new string[] { "Pretty Little Petals", "https://www.etsy.com/shop/paperpetalpeddler" } },
                        { "Hair and Make Up", new string[] { "Antunez Artistry", "https://www.facebook.com/antunez.artistry" } },
                        { "Planner", new string[] { "PlanSimply by CJ", "https://plansimplybycj.com/" } },
                        { "Donkey", new string[] { "@wedding_burro", "" } },
                        { "Photographer", new string[] { "Amanda Bynum", "" } },
                        { "DJ/Up lighting", new string[] { "Michael Lopez", "https://www.mastermixxaz.com/" } },
                        { "Invitation Suite", new string[] { "Beacon Lane", "http://www.beaconln.com/" } },
                        { "Shoes", new string[] { "Rescue flats", "https://www.facebook.com/rescueflats" } }
                    };
                    break;
                default:
                    break;
            }

            var index = files[0].IndexOf("\\Content");  // Get index for substring
            

            foreach (var item in files) // Build the lists!
            {
                string thumbnail = item.ToString().Substring(index);
                int i = thumbnail.IndexOf(splitTerm); // TODO: Continue Here
                int n = splitTerm.Length - 1;  // Needs the -1 for double backslash?

                // Split the string in two
                string head = thumbnail.Substring(0, i + n);
                string tail = thumbnail.Substring(i + n);

                // Add the string 
                thumbnail = head + "\\Thumbnails" + tail;

                // Create fileName and caption
                var fileName = item.ToString().Substring(index);
                var caption = (captionMap[fileName] != null) ? captionMap[fileName].ToString() : "";

                // Add each item to its appropriate list
                fileList.Add(fileName);
                thumbnailList.Add(thumbnail);
                captionList.Add(caption);
            }

            galleryModel.captions = captionList;
            galleryModel.fileNames = fileList;
            galleryModel.thumbnails = thumbnailList;
            galleryModel.descriptions = descriptions;
            galleryModel.accredits = accredits;
            galleryModel.title = title;

            return View("GalleryAlbum", galleryModel);
        }

        [OutputCache(Duration = 99999, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client)]
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
        [ActionName("contact")]
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
                    /*var credential = new NetworkCredential
                    {
                        UserName = "plansimplyemailservice@gmail.com",
                        Password = "ALFAxomail#29A12"
                    };*/
                    //smtp.Credentials = credential;

                    smtp.Credentials = new System.Net.NetworkCredential("3861a9676a171828c73556dbb603ed7a", "607378b698048d297064f44049bc9e3b");
                    smtp.Host = "in.mailjet.com";
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    try
                    {
                        await smtp.SendMailAsync(message);
                    }
                    catch (SmtpException e)
                    {   // Something went wrong - send user back to about page with same model and error message
                        ViewBag.Success = false;
                        ViewBag.Error = "Send failed - please try again: " + e.StatusCode;
                        return View("About", model);
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
    }
}