using System.Collections.Generic;
using System.Linq;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.Data.Entities;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;
namespace Czikoroko.Wojciech.PetShop.Data.Repositories
{
    public class PetTypeRepositoryEF : IRepositoryPetType
    {
        private readonly PetApplicationContext _ctx;

        public PetTypeRepositoryEF(PetApplicationContext ctx)
        {
            _ctx = ctx;
        }
        
        public PetType AddPetType(PetType petType)
        {
            PetTypeEntity petTypeEntity = new PetTypeEntity
            {
                Id = petType.Id,
                Name = petType.Name
            };
            _ctx.PetTypes.Add(petTypeEntity);
            _ctx.SaveChanges();
            return petType; 
        }

        public List<PetType> GetAllPetTypes()
        {
            return _ctx.PetTypes.Select(petType => new PetType()
            {
                Id = petType.Id,
                Name = petType.Name
            })
                .ToList();
    }

        public PetType SearchPetType(int id)
        {
            return _ctx.PetTypes.Select(petType => new PetType()
            {
                Id = petType.Id,
                Name = petType.Name
            }).FirstOrDefault(pt => pt.Id == id);
        }

        public PetType RemovePetType(int id)
        {
            var entity = _ctx.PetTypes.Remove(new PetTypeEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new PetType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public PetType UpdatePetType(PetType petType)
        {
            var entity = new PetTypeEntity
            {
                Id = petType.Id,
                Name = petType.Name
            };
            var savedEntity = _ctx.PetTypes.Update(entity).Entity;
            _ctx.SaveChanges();
            return new PetType
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name
            };
        }
    }
}