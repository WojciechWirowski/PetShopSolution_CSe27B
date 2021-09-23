using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;

namespace Czikoroko.Wojciech.PetShop.Domain.IRepositories
{
    public interface IRepositoryPet
    {
        Pet AddPet(Pet pet);
        List<Pet> GetAllPets();
        Pet SearchPet(int id);
        Pet RemovePet(int id);
        void UpdatePet(Pet pet);
        List<Pet> GetChippestPets();
    }
}