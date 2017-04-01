using ControlActas.Models;
using ControlActas.Services;
using ControlActas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private ILibraryRepository _repository;

        public AppController(IMailService mailService, IConfigurationRoot config, ILibraryRepository repository)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var data = _repository.GetAllUsers();
            return View(data);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {

            if (model.Email.Contains("aol.com")) ModelState.AddModelError("Email", "No support for AOL!");

            if (ModelState.IsValid)
            {
                _mailService.sendMail(_config["MailSettings:ToAddress"], model.Email, "Control de Actas Contacto", model.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent!";
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
