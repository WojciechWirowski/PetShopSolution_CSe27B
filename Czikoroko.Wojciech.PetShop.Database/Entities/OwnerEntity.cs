namespace Czikoroko.Wojciech.PetShop.Database.Entities
{
    public class OwnerEntity
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int OwnedPetId { get; set; }
    }
}