using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FreshProduceShop.Models;
using FreshProduceShop.ViewModels;

namespace FreshProduceShop.Controllers
{

    public class ProduceController : Controller
    {
        private readonly IProduceRepository _produceRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProduceController (IProduceRepository produceRepository, ICategoryRepository categoryRepository)
         {
             _produceRepository = produceRepository;
             _categoryRepository = categoryRepository;
         }
         
        


        public ViewResult ProduceList(string category)
        {
            IEnumerable<Produce> produces;
            string currentCategory;
             if (string.IsNullOrEmpty(category))
            {
                produces = _produceRepository.GetAllProduces.OrderBy(p => p.ProduceId);
                currentCategory = "All Produce";
            }
            else
            {
                produces = _produceRepository.GetAllProduces.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.ProduceId);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new ProduceListViewModel
            {
                Produces = produces,
                CurrentCategory = currentCategory
            });
            
        }


        public IActionResult Details(int id)
        {
            var produce = _produceRepository.GetProduceById(id);
            if (produce == null)
            {
                return NotFound();
            }
            return View(produce);
        }

        

    }
}