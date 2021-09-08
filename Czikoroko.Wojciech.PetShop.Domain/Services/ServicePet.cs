using System.Collections;
using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.IServices;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Domain.Services
{
    public class ServicePet : IServicePet
    {
        private IRepositoryPet _repo;
        public ServicePet(IRepositoryPet petRepository)
        {
            _repo = petRepository;
        }

        public Pet AddPet(Pet pet)
        {
           return _repo.AddPet(pet);
        }

        public List<Pet> GetAllPets()
        {
           return _repo.GetAllPets();
        }

        public Pet SearchPet(int id)
        {
            return _repo.SearchPet(id);
        }

        public void RemovePet(int id)
        {
            _repo.RemovePet(id);
        }

        public void UpdatePet(Pet pet)
        {
            _repo.UpdatePet(pet);
        }

        public List<Pet> GetChippestPets()
        {
           return _repo.GetChippestPets();
        }
    }
}