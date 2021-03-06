using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;

namespace Czikoroko.Wojciech.PetShop.Domain.IRepositories
{
    public interface IRepositoryOwner
    {
        Owner AddOwner(Owner owner);
        List<Owner> GetAllOwner();
        Owner SearchOwner(int id);
        Owner RemoveOwner(int id);
        Owner UpdateOwner(Owner owner);
    }
}