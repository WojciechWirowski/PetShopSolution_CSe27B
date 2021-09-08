using System;
using Czikoroko.Wojciech.PetShop.Core.IServices;
using Czikoroko.Wojciech.PetShop.Database.Repositories;
using Czikoroko.Wojciech.PetShop.Domain.IRepositories;
using Czikoroko.Wojciech.PetShop.Domain.Services;

namespace Czikoroko.Wojciech.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositoryPet petRepository = new RepositoryPet();
            IRepositoryPetType petTypeRepository = new RepositoryPetType();
            IServicePet servicePet = new ServicePet(petRepository);
            IServicePetType servicePetType = new ServicePetType(petTypeRepository);
            
            Menu menu = new Menu(servicePet, servicePetType);
            menu.Start();
        }
    }
}