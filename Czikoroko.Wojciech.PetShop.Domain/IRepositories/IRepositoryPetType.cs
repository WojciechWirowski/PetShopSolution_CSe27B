using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;

namespace Czikoroko.Wojciech.PetShop.Domain.IRepositories
{
    public interface IRepositoryPetType
    {
        PetType AddPetType(PetType petType);
        List<PetType> GetAllPetTypes();
        PetType SearchPetType(int id);
        PetType RemovePetType(int id);
        PetType UpdatePetType(PetType petType);
    }
}