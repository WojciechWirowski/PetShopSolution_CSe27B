using System.Collections.Generic;
using System.Linq;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Database.Converters;
using Czikoroko.Wojciech.PetShop.Database.Entities;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Database.Repositories
{
    public class RepositoryPet : IRepositoryPet
    {
        private readonly PetConverter _converter;
        private List<PetEntity> _pets = new List<PetEntity>();
        int _id = 1;

        public RepositoryPet()
        {
            _converter = new PetConverter();
        }
        
        
        
        public Pet AddPet(Pet pet)
        {
            var petEntity = _converter.Convert(pet);
            pet.Id = _id++;
            _pets.Add(petEntity);
            return _converter.Convert(petEntity);
        }

        public List<Pet> GetAllPets()
        {
            var petList = new List<Pet>();
            foreach (var petEntity in _pets)
            {
                petList.Add(_converter.Convert(petEntity));
            }

            return petList;
        }

        public Pet SearchPet(int id)
        {
            PetEntity petEntity = _pets.Find(pet1 => pet1.Id == id);
            return _converter.Convert(petEntity);
        }

        public void RemovePet(int id)
        {
            _pets.Remove(_converter.Convert(SearchPet(id)));
        }

        public void UpdatePet(Pet pet)
        {
            if (pet.Id != null) RemovePet((int) pet.Id);
            AddPet(pet);
        }

        public List<Pet> GetChippestPets()
        {
            List<Pet> pets = GetAllPets();
            List<Pet> sortedPets = pets.OrderBy(o=>o.Price).ToList();

            return sortedPets;
        }
    }
}