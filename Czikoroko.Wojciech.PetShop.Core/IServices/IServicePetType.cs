using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;

namespace Czikoroko.Wojciech.PetShop.Core.IServices
{
    public interface IServicePetType
    {
        PetType AddPetType(PetType petType);
        List<PetType> GetAllPetTypes();
        PetType SearchPetType(int id);
        void RemovePetType(int id);
        void UpdatePetType(PetType petType);
    }
}