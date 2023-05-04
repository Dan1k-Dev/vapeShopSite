using System.ComponentModel.DataAnnotations;

namespace VapeShop.ClassesDb
{
    /// <summary>
    /// Модель таблицы товара "Вейпы"
    /// </summary>
    public class Vapes
    {
        [Key]
        public int VapeId { get; set; }
        public string? VapeName { get; set; }
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
        public int Price { get; set; }
    }
}
