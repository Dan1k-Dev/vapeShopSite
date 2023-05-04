using System.ComponentModel.DataAnnotations;

namespace VapeShop.ClassesDb
{
    /// <summary>
    /// Модель таблицы товара "Расходники"
    /// </summary>
    public class Consumables
    {
        [Key]
        public int ConsumableId { get; set; }
        public string? ConsumableName { get; set; }
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
        public int Price { get; set; }
    }
}
