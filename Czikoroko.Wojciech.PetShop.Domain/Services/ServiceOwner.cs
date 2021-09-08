using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.IServices;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Domain.Services
{
    public class ServiceOwner : IServiceOwner
    {
        private IRepositoryOwner _repo;
        
        public ServiceOwner(IRepositoryOwner ownerRepository)
        {
            _repo = ownerRepository;
        }
        
        public Owner AddOwner(Owner owner)
        {
            return _repo.AddOwner(owner);
        }

        public List<Owner> GetAllOwner()
        {
            return _repo.GetAllOwner();
        }

        public Owner SearchOwner(int id)
        {
            return _repo.SearchOwner(id);
        }

        public void RemoveOwner(int id)
        {
            _repo.RemoveOwner(id);
        }

        public void UpdateOwner(Owner owner)
        {
            _repo.UpdateOwner(owner);
        }
    }
}