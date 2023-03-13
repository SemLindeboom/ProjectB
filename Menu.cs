using Newtonsoft.Json;
public class Menu
{
    public List<Menu> listOfObjects;
    public List<Item> Voorgerecht;
    public List<Item> Hoofdgerecht;
    public List<Item> Nagerecht;
    public List<Item> Koffie_Thee;
    public List<Item> Fris_Sappen;
    public List<Item> BierOpTap;
    public List<Item> Wijn;


    public Menu()
    {
        Voorgerecht = new List<Item>();
        Hoofdgerecht = new List<Item>();
        Nagerecht = new List<Item>();
        Koffie_Thee = new List<Item>();
        Fris_Sappen = new List<Item>();
        BierOpTap = new List<Item>();
        Wijn = new List<Item>();
    }

    public void load_data()
    {
        StreamReader reader = new("Data.json");
        string File2Json = reader.ReadToEnd();
        listOfObjects = JsonConvert.DeserializeObject<List<Menu>>(File2Json)!;
        reader.Close();
    }

    public void save_data()
    {
        StreamWriter writer = new("Data.json");
        string List2Json = JsonConvert.SerializeObject(listOfObjects);
        writer.Write(List2Json);
        writer.Close();
    }

    public void print_menu()
    {
        foreach (Menu item in listOfObjects)
        {
            Console.WriteLine("\nVoorgerechten:\n");
            foreach (Item i in item.Voorgerecht)
            {
                Console.WriteLine($"{i.Name}  Kosten: {i.Price}");
            }
            Console.WriteLine("\nHoofdgerechten\n");
            foreach (Item i in item.Hoofdgerecht)
            {
                Console.WriteLine($"{i.Name}  Kosten: {i.Price}");
            }
            Console.WriteLine("\nNagerechten\n");
            foreach (Item i in item.Nagerecht)
            {
                Console.WriteLine($"{i.Name}  Kosten: {i.Price}");
            }
            Console.WriteLine("\nKoffie & Thee\n");
            foreach (Item i in item.Koffie_Thee)
            {
                Console.WriteLine($"{i.Name}  Kosten: {i.Price}");
            }
            Console.WriteLine("\nFris & Sappen\n");
            foreach (Item i in item.Fris_Sappen)
            {
                Console.WriteLine($"{i.Name}  Kosten: {i.Price}");
            }
            Console.WriteLine("\nBier op tap\n");
            foreach (Item i in item.BierOpTap)
            {
                Console.WriteLine($"{i.Name}  Kosten: {i.Price}");
            }
            Console.WriteLine("\nWijn\n");
            foreach (Item i in item.Wijn)
            {
                Console.WriteLine($"{i.Name}  Kosten: {i.Price}");
            }
        }
    }

    public void add_item(Item item, string locatie)
    {
        switch (locatie)
        {
            case "Voorgerecht":
                listOfObjects[0].Voorgerecht.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            case "Hoofdgerecht":
                listOfObjects[0].Hoofdgerecht.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }

    public void remove_item(string naam, string locatie)
    {
        bool Completed = false;
        switch (locatie)
        {
            case "Voorgerecht":
                foreach (Menu item in listOfObjects)
                {
                    foreach (Item i in item.Voorgerecht)
                    {
                        if (i.Name == naam)
                        {
                            item.Voorgerecht.Remove(i);
                            Completed = true;
                            save_data();
                        }
                    }
                }
                if (Completed is true)
                {
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            case "Hoofdgerecht":
                foreach (Menu item in listOfObjects)
                {
                    foreach (Item i in item.Voorgerecht)
                    {
                        if (i.Name == naam)
                        {
                            item.Voorgerecht.Remove(i);
                            save_data();
                        }
                    }
                }
                if (Completed is true)
                {
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }   
    }
}