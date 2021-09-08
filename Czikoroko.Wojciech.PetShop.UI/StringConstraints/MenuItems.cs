namespace Czikoroko.Wojciech.PetShop.UI.StringConstraints
{
    public class MenuItems
    {
        public readonly string WelcomeMess = "Welcome in my little pet shop";
        private readonly string PetTypesMenu = "==========PET=TYPES==========";
        private readonly string PetMenu = "==========PETS==========";
        private readonly string MainMenu = "==========MAIN MENU";
        
        public string[] GetList1()
        {
            string[] list =
            {
                "Exit",
                "Pets",
                "Pet types"
            };
            
            return list;
        }
        public string[] GetList2()
        {
            string[] list =
            {
                "Main menu",
                "Avilable pets",
                "Search pet",
                "Add pet",
                "Delete pet",
                "Chipest pets"
            };
            
            return list;
        }
        public string[] GetList3()
        {
            string[] list =
            {
                "Main menu",
                "Avilable pet types",
                "Search pet type",
                "Add pet type",
                "Delete pet type"
            };
            
            return list;
        }
    }
}