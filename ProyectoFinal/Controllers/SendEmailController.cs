using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Net.Mail;

namespace ProyectoFinal.Controllers
{
    [Authorize(Roles = "admin")]
    public class SendEmailController : Controller
    {
        // GET: SendEmailController

        private readonly IEmailSender _emailSender;

        public SendEmailController(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }


        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmail emailData)
        {



            await _emailSender.SendEmailAsync(emailData.email, emailData.subject, emailData.htmlMessage);
            TempData[DS.Exitosa] = "Correo enviado Exitosamente";
            return RedirectToAction("SendEmail");
        }

        public IActionResult SentEmail()
        {
            ViewData["Success"] = "Email has been sent successfully!";
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: SendEmailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SendEmailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SendEmailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SendEmailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SendEmailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SendEmailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SendEmailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
