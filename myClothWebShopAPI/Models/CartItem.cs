using System.ComponentModel.DataAnnotations.Schema;

namespace myClothWebShopAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ShopItemId { get; set; }
        [ForeignKey("ShopItemId")]         // [ForeignKey("ShopItemId")] в вашем коде указывает Entity Framework Core на то, какому свойству в сущности CartItem соответствует внешний ключ, связывающий таблицы в базе данных. В данном случае, он сообщает EF Core, что свойство ShopItemId является внешним ключом, связывающим CartItem с ShopItem
        //  В вашем случае, помимо создания внешнего ключа, [ForeignKey("ShopItemId")] также создает навигационное свойство ShopItem, которое позволяет вам легко получать доступ к связанным данным в таблице ShopItem из объекта CartItem
        public ShopItem ShopItem { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; } // entity сам понимает связь между CartItem и Cart ( по CartId) просто
    }
}
