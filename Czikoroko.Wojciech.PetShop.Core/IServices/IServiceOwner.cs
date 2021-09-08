using System.Collections.Generic;
using Czikoroko.Wojciech.PetShop.Core.Models;

namespace Czikoroko.Wojciech.PetShop.Core.IServices
{
    public interface IServiceOwner
    {
        Owner AddOwner(Owner owner);
        List<Owner> GetAllOwner();
        Owner SearchOwner(int id);
        void RemoveOwner(int id);
        void UpdateOwner(Owner owner);
    }
}