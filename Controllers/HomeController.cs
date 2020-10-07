using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshProduceShop.Models;
using FreshProduceShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreshProduceShop.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IProduceRepository _produceRepository;

        public HomeController(IProduceRepository produceRepository)
        {
            _produceRepository = produceRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ProducesofTheWeek = _produceRepository.GetAllProducesofTheWeek
            };

            return View(homeViewModel);
        }
    }
}
