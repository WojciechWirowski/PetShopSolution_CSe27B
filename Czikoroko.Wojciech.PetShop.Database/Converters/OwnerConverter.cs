using System.Diagnostics;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Database.Entities;
using Czikoroko.Wojciech.PetShop.Database.Repositories;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Database.Converters
{
    public class OwnerConverter
    {
        public Owner Convert(OwnerEntity entity)
        {
            IRepositoryPet repository = new RepositoryPet();

            return new Owner
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                OwnedPet = repository.SearchPet(entity.OwnedPetId)
            };
        }

        public OwnerEntity Convert(Owner owner)
        {
            Debug.Assert(owner.OwnedPet.Id != null, "owner.OwnedPet.Id != null");
            return new OwnerEntity
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                SecondName = owner.SecondName,
                OwnedPetId = (int) owner.OwnedPet.Id
            };
        }
    }
}