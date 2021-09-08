using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.IServices;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Domain.Services
{
    public class ServicePetType : IServicePetType
    {
        private IRepositoryPetType _repo;
        public ServicePetType(IRepositoryPetType repo)
        {
            _repo = repo;
        }

        public PetType AddPetType(PetType petType)
        {
           return _repo.AddPetType(petType);
        }

        public List<PetType> GetAllPetTypes()
        {
            return _repo.GetAllPetTypes();
        }

        public PetType SearchPetType(int id)
        {
            return _repo.SearchPetType(id);
        }

        public void RemovePetType(int id)
        {
            _repo.RemovePetType(id);
        }

        public void UpdatePetType(PetType petType)
        {
            _repo.UpdatePetType(petType);
        }
    }
}