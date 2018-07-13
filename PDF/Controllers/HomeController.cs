using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PDF.Models;
using iTextSharp.text.pdf;
using System.IO;

using Newtonsoft.Json;

namespace PDF.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult PreviewCertificate()
        {


            using (Certificates context = new Certificates())
            {
                var certificates = context.CertificateSet.ToList();
                return View(certificates);
            }
        }

        public ActionResult ShowCertificate(int id)
        {


            using (Certificates context = new Certificates())
            {

                var certificateitem = context.CertificateSet.Where(m => m.Id == id).FirstOrDefault();
                var certificate = new CertificateModelDTO();
                certificate.NameSurname = certificateitem.NameSurname;
                certificate.Date = certificateitem.Date.ToString("dd/MM/yyyy");
                certificate.Topic = certificateitem.Topic;
                var serializeObject = JsonConvert.SerializeObject(certificate);
                var pdfPath = certificateitem.path;
                var pdfByte = PdfGenerateFromTemplate.PdfGenerateTemplate(serializeObject, pdfPath);
                System.Web.HttpContext.Current.Response.Clear();
                MemoryStream ms = new MemoryStream(pdfByte);
                System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "atteachment;filename="
                + certificate.NameSurname + ".pdf");
                System.Web.HttpContext.Current.Response.Buffer = true;
                ms.WriteTo(System.Web.HttpContext.Current.Response.OutputStream);
                System.Web.HttpContext.Current.Response.End();
                return RedirectToAction("PreviewCertificate", "Home");
            }
        }





        public ActionResult Index()
        {


            return RedirectToAction("PreviewCertificate", "Home");
        }
        private Certificates db = new Certificates();
        public ActionResult AddPeopleForCertificate()
        {
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in db.CertificateTypeIDs.ToList())
            {
                kategoriler.Add(new SelectListItem
                {
                    Text = item.CertificateID.ToString(),
                    Value = item.path
                });
            }
            ViewBag.Kategoriler = kategoriler;
            return View();
        }
       [HttpPost]
        public ActionResult AddPeopleForCertificate(CertificateSet certificate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CertificateSet.Add(certificate);
                    db.SaveChanges();
                }
                     
            }
            catch
            {

            }
            

            

            
            return RedirectToAction("Index", "Home");
        }
        
       
       
        
        public static class PdfGenerateFromTemplate
        {
            public static byte[] PdfGenerateTemplate(string pdfJsonData, string pdfPath)
            {
                PdfReader pdfReader = new PdfReader(pdfPath);
                MemoryStream stream = new MemoryStream();
                PdfStamper stamper = new PdfStamper(pdfReader, stream);
                AcroFields pdfFormFields = stamper.AcroFields;
                var pdfDeserializeJsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(pdfJsonData);
                foreach (var pdfDeserializeJsonDataItem in pdfDeserializeJsonData)
                {
                    pdfFormFields.SetField(pdfDeserializeJsonDataItem.Key, pdfDeserializeJsonDataItem.Value);
                }
                stamper.FormFlattening = true;

                stamper.Close();
                pdfReader.Close();
                
                stream.Flush();
                stream.Close();
                return stream.ToArray();
                

            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}