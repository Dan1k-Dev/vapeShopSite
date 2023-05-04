using System.ComponentModel.DataAnnotations;

namespace VapeShop.ClassesDb
{
    /// <summary>
    /// Модель таблицы товара "Одноразовые испарители" 
    /// </summary>
    public class OnceVapes
    {
        [Key]
        public int OnceVapeId { get; set; }
        public string? OnceVapeName { get; set; }
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
        public int Price { get; set; }
    }
}
