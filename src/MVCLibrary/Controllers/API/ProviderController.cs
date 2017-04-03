using ControlActas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Controllers.API
{
    public class ProviderController : Controller
    {
        private ILogger<ProviderController> _logger;
        private ILibraryRepository _repository;

        public ProviderController(ILibraryRepository repository, ILogger<ProviderController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
