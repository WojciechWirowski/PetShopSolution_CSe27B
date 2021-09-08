namespace Czikoroko.Wojciech.PetShop.Core.Models
{
    public class Owner
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Pet OwnedPet { get; set; }
    }
}