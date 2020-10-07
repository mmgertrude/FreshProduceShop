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
    public class ShoppingCartController : Controller
    {
        private readonly IProduceRepository _produceRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProduceRepository produceRepository, ShoppingCart shoppingCart)
        {
            _produceRepository = produceRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int produceId)
        {
            var selectedProduce = _produceRepository.GetAllProduces.FirstOrDefault(f => f.ProduceId == produceId);

            if (selectedProduce != null)
            {
                _shoppingCart.AddToCart(selectedProduce, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int produceId)
        {
            var selectedProduce = _produceRepository.GetAllProduces.FirstOrDefault(f => f.ProduceId == produceId);

            if (selectedProduce != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduce);
            }
            return RedirectToAction("Index");
        }
    }
}
