using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreshProduceShop.Models
{
    public class ShoppingCart
    {
        private readonly ProduceDbContext _produceDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(ProduceDbContext fruitDbContext)
        {
            _produceDbContext = fruitDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ProduceDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Produce produce, int Quantity)
        {
            var shoppingCartItem =
                    _produceDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Produce.ProduceId == produce.ProduceId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Produce = produce,
                    Quantity = 1
                };

                _produceDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _produceDbContext.SaveChanges();
        }

        public int RemoveFromCart(Produce produce)
        {
            var shoppingCartItem =
                    _produceDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Produce.ProduceId == produce.ProduceId && s.ShoppingCartId == ShoppingCartId);

            var localQty = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQty = shoppingCartItem.Quantity;
                }
                else
                {
                    _produceDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _produceDbContext.SaveChanges();

            return localQty;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                   _produceDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(p => p.Produce)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _produceDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _produceDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _produceDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _produceDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Produce.Price * c.Quantity).Sum();
            return total;
        }
    }
}
