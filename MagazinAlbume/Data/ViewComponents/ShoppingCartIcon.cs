using MagazinAlbume.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace MagazinAlbume.Data.ViewComponents
{
    public class ShoppingCartIcon : ViewComponent

    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartIcon(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}