using System.Diagnostics;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Database.Entities;
using Czikoroko.Wojciech.PetShop.Database.Repositories;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Database.Converters
{
    public class PetConverter
    {
        public Pet Convert(PetEntity entity)
        {
            IRepositoryPetType repository = new RepositoryPetType();

            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = repository.SearchPetType(entity.TypeId),
                Birthdate = entity.Birthdate,
                SoldDate = entity.SoldDate,
                Colour = entity.Colour,
                Price = entity.Price
            };
        }

        public PetEntity Convert(Pet pet)
        {
            Debug.Assert(pet.Type.Id != null, "pet.Type.Id != null");
            return new PetEntity
            {
                Id = pet.Id,
                Name = pet.Name,
                TypeId = (int) pet.Type.Id,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Colour = pet.Colour,
                Price = pet.Price
            };
        }
    }
}
