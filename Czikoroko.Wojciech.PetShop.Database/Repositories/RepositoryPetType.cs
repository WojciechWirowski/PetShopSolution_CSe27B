using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Database.Repositories
{
    public class RepositoryPetType : IRepositoryPetType

    {
        private List<PetType> _petTypes = new List<PetType>();
        int _id = 1;

        public PetType AddPetType(PetType petType)
        {
            petType.Id = _id++;
            _petTypes.Add(petType );
            return petType;
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypes;
        }

        public PetType SearchPetType(int id)
        {
            PetType petType = _petTypes.Find(petType1 => petType1.Id == id);
            return petType;
        }

        public PetType RemovePetType(int id)
        {
          //  return _petTypes.Remove(SearchPetType(id));
          return new PetType();
        }

        public PetType UpdatePetType(PetType petType)
        {
            return RemovePetType((int) petType.Id);
        }
    }
}