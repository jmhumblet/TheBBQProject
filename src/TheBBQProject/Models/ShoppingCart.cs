using System.Collections.Generic;
using System.Linq;
//C# 6 Demo
//using static System.Math;
namespace TheBBQProject.Models
{
    public class ShoppingCart
    {
        //C# 6 Demo
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        //C# 6 Demo
        //public decimal Total => CartItems.Sum(i => i.ShoppingItem.Price * i.Quantity);
        public decimal Total
        {
            get
            {
                return CartItems.Sum(i => i.ShoppingItem.Price * i.Quantity);
            }
        }

        public void AddItem(ShoppingItem shoppingItem)
        {
            //  //C# 6 Demo
            //  if (shoppingItem == null)
            //      throw new ArgumentNullException(nameof(shoppingItem));
                
            var cartItem = CartItems.FirstOrDefault(i => i.ShoppingItem.Id == shoppingItem.Id);

            if (cartItem == null)
                CartItems.Add(new CartItem { ShoppingItem = shoppingItem, Quantity = 1 });
            else
                cartItem.Quantity++;
        }

        public void RemoveItem(int id)
        {
            var cartItem = CartItems.FirstOrDefault(i => i.ShoppingItem.Id == id);

            if (cartItem?.Quantity == 1)
                CartItems.Remove(cartItem);
            else if (cartItem != null)
                cartItem.Quantity--;
            
            
            //  //C# 6 Demo 
            //  var onItemRemoved = OnItemRemoved;
            //  if (onItemRemoved != null)
            //  {
            //      onItemRemoved(this, id);
            //  }
            //
            //  OnItemRemoved?.Invoke(this, id);
        }
        
        //  //C# 6 Demo
        //  event EventHandler<int> OnItemRemoved;
        
        //C# 6 Demo
        //  public void FilterException()
        //  {
        //      try
        //      {
        //          throw new Exception("CatchMe");
        //      }
        //      catch (System.Exception ex) when(ex.Message = "CatchMe")
        //      {
        //          throw;
        //      }
        //      catch (System.Exception)
        //      {
        //          throw;
        //      }
        //  }
        //  
        //  public void GetMeMin(int a, int b)
        //  {
        //      return Min(a, b)   
        //  }
    }
}
