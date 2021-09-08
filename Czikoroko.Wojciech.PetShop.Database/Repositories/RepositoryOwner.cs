using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Database.Converters;
using Czikoroko.Wojciech.PetShop.Database.Entities;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Database.Repositories
{
    public class RepositoryOwner : IRepositoryOwner
    {

        
        private readonly OwnerConverter _converter;
        private List<OwnerEntity> _owners = new List<OwnerEntity>();
        int _id = 1;
        
        public RepositoryOwner()
        {
            _converter = new OwnerConverter();
        }
        public Owner AddOwner(Owner owner)
        {
            var ownerEntity = _converter.Convert(owner);
            owner.Id = _id++;
            _owners.Add(ownerEntity);
            return _converter.Convert(ownerEntity);        }

        public List<Owner> GetAllOwner()
        {
            var ownersList = new List<Owner>();
            foreach (var ownerEntity in _owners)
            {
                ownersList.Add(_converter.Convert(ownerEntity));
            }

            return ownersList;
        }

        public Owner SearchOwner(int id)
        {
            OwnerEntity ownerEntity = _owners.Find(owner1 => owner1.Id == id);
            return _converter.Convert(ownerEntity);        }

        public void RemoveOwner(int id)
        {
            _owners.Remove(_converter.Convert(SearchOwner(id)));
        }

        public void UpdateOwner(Owner owner)
        {
            if (owner.Id != null) RemoveOwner((int) owner.Id);
            AddOwner(owner);        }
    }
}