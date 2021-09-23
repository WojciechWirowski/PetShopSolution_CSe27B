using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Database.Entities;

namespace Czikoroko.Wojciech.PetShop.Database.Converters
{
    public class PetConverter
    {
        public Pet Convert(PetEntity entity)
        {
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Birthdate = entity.Birthdate,
                SoldDate = entity.SoldDate,
                Colour = entity.Colour,
                Price = entity.Price
            };
        }

        public PetEntity Convert(Pet pet)
        {
            return new PetEntity
            {
                Id = pet.Id,
                Name = pet.Name,
                TypeId = (int) (pet.Type != null ? pet.Type.Id : 0),
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Colour = pet.Colour,
                Price = pet.Price
            };
        }
    }
}
