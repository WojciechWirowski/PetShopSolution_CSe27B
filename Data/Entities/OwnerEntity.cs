namespace Czikoroko.Wojciech.PetShop.Data.Entities
{
    public class OwnerEntity
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int OwnedPetId { get; set; }
    }
}