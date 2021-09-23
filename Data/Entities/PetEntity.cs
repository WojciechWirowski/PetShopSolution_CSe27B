using System;

namespace Czikoroko.Wojciech.PetShop.Data.Entities
{
    public class PetEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }
    }
}