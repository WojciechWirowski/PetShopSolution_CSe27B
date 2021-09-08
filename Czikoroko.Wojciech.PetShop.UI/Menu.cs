using System;
using Czikoroko.Wojciech.PetShop.Core.IServices;
using Czikoroko.Wojciech.PetShop.Core.Models;
using Czikoroko.Wojciech.PetShop.UI.StringConstraints;

namespace Czikoroko.Wojciech.PetShop.UI
{
    public class Menu
    {
        private readonly IServicePet _servicePet;
        private readonly IServicePetType _servicePetType;
        private MenuItems _menuItems;

        public Menu(IServicePet servicePet, IServicePetType servicePetType)
        {
            _servicePet = servicePet;
            _servicePetType = servicePetType;
        }
        public void Start()
        {
            CreateMock();
            _menuItems = new MenuItems();
            WriteLine(_menuItems.WelcomeMess);
            DisplayMainMenu();
        }
        
        public void CreateMock()
        {
            _servicePetType.AddPetType(new PetType{Name = "Lion"});
            _servicePetType.AddPetType(new PetType{Name = "Snake"});
            _servicePetType.AddPetType(new PetType{Name = "Dog"});
            _servicePetType.AddPetType(new PetType{Name = "Monkey"});
            _servicePetType.AddPetType(new PetType{Name = "Pig"});

            _servicePet.AddPet(new Pet {Name = "Simba", Birthdate = DateTime.Now, SoldDate = DateTime.Now, Colour = "White", Type = _servicePetType.SearchPetType(1), Price = 42000});
            _servicePet.AddPet(new Pet {Name = "Venom", Birthdate = DateTime.Now, SoldDate = DateTime.Now, Colour = "Black and orange", Type = _servicePetType.SearchPetType(1), Price = 50});
            _servicePet.AddPet(new Pet {Name = "Fluffy happines", Birthdate = DateTime.Now, SoldDate = DateTime.Now, Colour = "Sable", Type = _servicePetType.SearchPetType(1), Price = 200000});
            _servicePet.AddPet(new Pet {Name = "UUAA", Birthdate = DateTime.Now, SoldDate = DateTime.Now, Colour = "Brown", Type = _servicePetType.SearchPetType(1), Price = 3000});
            _servicePet.AddPet(new Pet {Name = "Vin Dieselele", Birthdate = DateTime.Now, SoldDate = DateTime.Now, Colour = "Pink", Type = _servicePetType.SearchPetType(1), Price = 200});

        }

        public void DisplayMainMenu()
        {
            WriteLine("===============================================================================");
            for (int i = 0; i < _menuItems.GetList1().Length; i++)
            {
                WriteLine(i + "." + _menuItems.GetList1()[i]);   
            }
            PickMainMenuItem();
        }

        public void DisplayPetMenu()
        {
            WriteLine("===============================================================================");
            for (int i = 0; i < _menuItems.GetList2().Length; i++)
            {
                WriteLine(i + "." + _menuItems.GetList2()[i]);   
            }
            PickPetMenuItem();
        }

        public void DisplayPetTypeMenu()
        {
            WriteLine("===============================================================================");
            for (int i = 0; i < _menuItems.GetList3().Length; i++)
            {
                WriteLine(i + "." + _menuItems.GetList3()[i]);   
            }
            PickPetTypeMenuItem();
        }

        public void PickMainMenuItem()
        {
            int pick;
            if (int.TryParse(ReadLine(), out pick))
            {
                switch (pick)
                {
                    case 0:
                        Clear();
                        break;
                    case 1:
                        DisplayPetMenu();
                        break;
                    case 2:
                        DisplayPetTypeMenu();
                        break;
                    case > 2:
                        throw new Exception(Exceptions.WrongInputType);
                }
            }
            else
            {
                throw new Exception(Exceptions.WrongInputType);
            }
        }
        
        private void PickPetMenuItem()
        {
            int pick;
            if (int.TryParse(ReadLine(), out pick))
            {
                switch (pick)
                {
                    case 0:
                        DisplayMainMenu();
                        break;
                    case 1:
                        PetList();
                        break;
                    case 2:
                        SearchPet();
                        break;
                    case 3:
                        AddPet();
                        break;
                    case 4:
                        DeletePet();
                        break;
                    case 5:
                        ChipestPets();
                        break;
                    case > 5:
                        throw new Exception(Exceptions.WrongInputType);
                }
            }
            else
            {
                throw new Exception(Exceptions.WrongInputType);
            }
        }

        //Pet options//
        private void ChipestPets()
        {
            WriteLine("===============================================================================");
            foreach (Pet pet in _servicePet.GetChippestPets())
            {
                WriteLine(pet.Id + "." + pet.Name + "=" + pet.Price);
            }
            DisplayPetMenu();
        }

        private void DeletePet()
        {  
            WriteLine("===============================================================================");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Pet pet = _servicePet.SearchPet(id);
                _servicePet.RemovePet(id);
                WriteLine(pet.Id + "." + pet.Name + " " + pet.Type.Name + " " + pet.Price + " " + pet.Birthdate + " " + pet.Colour + " " + pet.SoldDate);
            }
            else
            {
                throw new Exception(Exceptions.WrongInputType);
            }
            DisplayPetMenu();
        }

        private void AddPet()
        {
            WriteLine("===============================================================================");
            if (int.TryParse(Console.ReadLine(), out _))
            {
                string name = ReadLine();
                int type = Convert.ToInt32(ReadLine());
                Pet pet = new Pet{Name = name, Type = _servicePetType.SearchPetType(type)};
                WriteLine(pet.Id + "." + pet.Name + " " + pet.Type.Name + " " + pet.Price + " " + pet.Birthdate + " " + pet.Colour + " " + pet.SoldDate);
            }
            else
            {
                throw new ArgumentException(Exceptions.WrongInputType);
            }
            DisplayPetMenu();
        }

        private void SearchPet()
        {
            WriteLine("===============================================================================");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Pet pet = _servicePet.SearchPet(id);
                WriteLine(pet.Id + "." + pet.Name + " " + pet.Type.Name + " " + pet.Price + " " + pet.Birthdate + " " + pet.Colour + " " + pet.SoldDate);
            }
            else
            {
                throw new Exception(Exceptions.WrongInputType);
            }
            DisplayPetMenu();
        }

        private void PetList()
        {
            WriteLine("===============================================================================");
            foreach (var pet in _servicePet.GetAllPets())
            {
                WriteLine(pet.Id + "." + pet.Name + " " + pet.Type.Name + " " + pet.Price);
            }
            DisplayPetMenu();
        }
        
        //Pet type options//
        private void DeletePetType()
        {  
            WriteLine("===============================================================================");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                PetType petType = _servicePetType.SearchPetType(id);
                _servicePetType.RemovePetType(id);
                WriteLine(petType.Id + "." + petType.Name + "deleted");
            }
            else
            {
                throw new Exception(Exceptions.WrongInputType);
            }
            DisplayPetMenu();
        }

        private void AddPetType()
        {
            WriteLine("===============================================================================");
            string name = ReadLine();
                PetType petType = new PetType{Name = name};
                _servicePetType.AddPetType(petType);
                WriteLine(petType.Id + "." + petType.Name + "added");
                
                DisplayPetTypeMenu();
        }

        private void SearchPetType()
        {
            WriteLine("===============================================================================");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                PetType petType = _servicePetType.SearchPetType(id);
                WriteLine(petType.Id + "." + petType.Name);
            }
            else
            {
                throw new Exception(Exceptions.WrongInputType);
            }
            DisplayPetTypeMenu();
        }

        private void PetTypeList()
        {
            WriteLine("===============================================================================");
            foreach (var petType in _servicePetType.GetAllPetTypes())
            {
                WriteLine(petType.Id + "." + petType.Name);
            }
            DisplayPetTypeMenu();
        }
        

        private void PickPetTypeMenuItem()
        {
            int pick;
            if (int.TryParse(ReadLine(), out pick))
            {
                switch (pick)
                {
                    case 0: 
                        DisplayMainMenu();
                        break;
                    case 1:
                        PetTypeList();
                        break;
                    case 2:
                        SearchPetType();
                        break;
                    case 3:
                        AddPetType();
                        break;
                    case 4:
                        DeletePetType();
                        break;
                    case > 4:
                        throw new Exception(Exceptions.WrongInputType);
                }
            }
            else
            {
                throw new Exception(Exceptions.WrongInputType);
            }
        }

        private void Clear()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
           string line = Console.ReadLine();
           return line;
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}