using System.Collections.Generic;
using System.Linq;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Data.Entities;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Data.Repositories
{
    public class PetRepositoryEF : IRepositoryPet
    {
        private readonly PetApplicationContext _ctx;

        public PetRepositoryEF(PetApplicationContext ctx)
        {
            _ctx = ctx;
        }
        public Pet AddPet(Pet pet)
        {
            PetEntity petEntity = new PetEntity
            {
                Id = pet.Id,
                Birthdate = pet.Birthdate,
                Colour = pet.Colour,
                Name = pet.Name,
                Price = pet.Price,
                SoldDate = pet.SoldDate,
                TypeId = (int) pet.Type.Id
            };
            _ctx.Pets.Add(petEntity);
            _ctx.SaveChanges();
            return pet;
        }

        public List<Pet> GetAllPets()
        {
            return _ctx.Pets.Select(petEntity => new Pet()
            {
                Id = petEntity.Id,
                Birthdate = petEntity.Birthdate,
                Colour = petEntity.Colour,
                Name = petEntity.Name,
                Price = petEntity.Price,
                SoldDate = petEntity.SoldDate,
                Type = new PetType
                {
                    Id = petEntity.TypeId
                }
            }).ToList();
        }

        public Pet SearchPet(int id)
        {
            return _ctx.Pets.Select(petEntity => new Pet
            {
                Id = petEntity.Id,
                Birthdate = petEntity.Birthdate,
                Colour = petEntity.Colour,
                Name = petEntity.Name,
                Price = petEntity.Price,
                SoldDate = petEntity.SoldDate,
                Type = new PetType
                {
                    Id = petEntity.TypeId
                }
            }).FirstOrDefault(p => p.Id == id);
        }

        public Pet RemovePet(int id)
        {
            var entity = _ctx.Pets.Remove(new PetEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = entity.Id,
                Birthdate = entity.Birthdate,
                Colour = entity.Colour,
                Name = entity.Name,
                Price = entity.Price,
                SoldDate = entity.SoldDate,
                Type = new PetType
                {
                    Id = entity.TypeId
                }
            };
        }

        public void UpdatePet(Pet pet)
        {
            var entity = new PetEntity
            {
                Id = pet.Id,
                Birthdate = pet.Birthdate,
                Colour = pet.Colour,
                Name = pet.Name,
                Price = pet.Price,
                SoldDate = pet.SoldDate,
                TypeId = (int) pet.Type.Id
            };
            _ctx.Pets.Update(entity);
            _ctx.SaveChanges();
        }

        public List<Pet> GetChippestPets()
        {
            List<Pet> chippestPets = GetAllPets();
            if (chippestPets != null) 
            chippestPets.Sort(delegate(Pet pet, Pet pet1) {
                if (pet.Price == null && pet1.Price == null) return 0;
                else if (pet.Price == null) return -1;
                else if (pet1.Price == null) return 1;
                else return pet.Price.CompareTo(pet1.Price);
            });
            
            return chippestPets;
        }
    }
}