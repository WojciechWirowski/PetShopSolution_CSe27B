using System.Collections.Generic;
using System.Linq;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Data.Entities;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;

namespace Czikoroko.Wojciech.PetShop.Data.Repositories
{
    public class OwnerRepositoryEF : IRepositoryOwner
    {
        private readonly PetApplicationContext _ctx;


        public OwnerRepositoryEF(PetApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public Owner AddOwner(Owner owner)
        {
            OwnerEntity ownerEntity = new OwnerEntity
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                OwnedPetId = (int) owner.OwnedPet.Id,
                SecondName = owner.SecondName
            };
            _ctx.Owners.Add(ownerEntity);
            _ctx.SaveChanges();
            return owner;
        }

        public List<Owner> GetAllOwner()
        {
            return _ctx.Owners
                .Select(ownerEntity => new Owner
                {
                    Id = ownerEntity.Id,
                    FirstName = ownerEntity.FirstName,
                    SecondName = ownerEntity.SecondName,
                    OwnedPet = new Pet
                    {
                        Id = ownerEntity.OwnedPetId
                        
                    }
                })
                .ToList();
        }

        public Owner SearchOwner(int id)
        {
            return _ctx.Owners.Select(ownerEntity => new Owner
            {
                Id = ownerEntity.Id,
                FirstName = ownerEntity.FirstName,
                SecondName = ownerEntity.SecondName,
                OwnedPet = new Pet
                {
                    Id = ownerEntity.OwnedPetId
                }
            }).FirstOrDefault(o => o.Id == id);
        }

        public Owner RemoveOwner(int id)
        {
            var entity = _ctx.Owners.Remove(new OwnerEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Owner
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                OwnedPet = new Pet
                {
                    Id = entity.OwnedPetId
                }
            };
        }

        public Owner UpdateOwner(Owner owner)
        {
            var entity = new OwnerEntity
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                SecondName = owner.SecondName,
                OwnedPetId = (int) owner.OwnedPet.Id
            };
            var savedEntity = _ctx.Owners.Update(entity).Entity;
            _ctx.SaveChanges();
            return new Owner
            {
                Id = savedEntity.Id,
                FirstName = savedEntity.FirstName,
                SecondName = savedEntity.SecondName,
                OwnedPet = new Pet
                {
                    Id = savedEntity.OwnedPetId
                }
            };
        }
    }
}