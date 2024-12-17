using Maktab.Sample.Blog.Domain.prescription;
using Maktab.Sample.Blog.Service.Users;
using Microsoft.AspNetCore.Mvc;

namespace Maktab.Sample.Blog.Presentation.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionRepository _repository;
        private readonly ILogger<PrescriptionController> _logger;

        public PrescriptionController(IPrescriptionRepository repository, ILogger<PrescriptionController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAllPrescriptions()
        {
            return View();
        }
    }
}
