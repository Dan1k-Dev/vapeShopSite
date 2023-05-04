using System.ComponentModel.DataAnnotations;

namespace VapeShop.ClassesDb
{
    /// <summary>
    /// Модель таблицы товара "Жидкости"
    /// </summary>
    public class Liquids
    {
        [Key]
        public int LiquidId { get; set; }
        public string? LiquidName { get; set; }
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
        public int Price { get; set; }
    }
}
