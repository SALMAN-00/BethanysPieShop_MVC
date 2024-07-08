using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BethanysPieShop.Models
{
    public class OrderRepository: IOrderRepository
    {
        private readonly PieShopDbContext _bethanysPieShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(PieShopDbContext bethanysPieShopDbContext, IShoppingCart shoppingCart)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetail = new List<OrderDetails>();
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetails = new OrderDetails
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price,
                };
                order.OrderDetail.Add(orderDetails);
            }
            _bethanysPieShopDbContext.Orders.Add(order);
            _bethanysPieShopDbContext.SaveChanges();
        }

    }
}
