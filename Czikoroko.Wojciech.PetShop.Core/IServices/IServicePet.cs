using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;

namespace Czikoroko.Wojciech.PetShop.Core.IServices
{
    public interface IServicePet
    {
        Pet AddPet(Pet pet);
        List<Pet> GetAllPets();
        Pet SearchPet(int id);
        void RemovePet(int id);
        void UpdatePet(Pet pet);
        List<Pet> GetChippestPets();
    }
}