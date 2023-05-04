using System.ComponentModel.DataAnnotations;

namespace DragonVapeShopAPI.Database
{
    public class Vapess
    {
        [Key]
        public int VapeId { get; set; }
        public string? VapeName { get; set; }
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
        public int Price { get; set; }
    }
}