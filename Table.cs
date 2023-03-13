public class Table
{
    public string Tafel0 = "";
    public bool Beschikbaar;
    public int TafelNummer;
    public int HoeveelPlek;
    public List<Table> tables = new List<Table>();
    public Table(int tafelNummer, int HoeveelPlek)
    {
        this.TafelNummer = tafelNummer;
        this.Beschikbaar = true;
        this.HoeveelPlek = HoeveelPlek;
    }

    // make all the tables and then put them in a list, eight 2-person tables, five 4-person tables and Jake has two tables for groups of 6 people
    public List<Table> CreateTables()
    {
        for (int i = 1; i <= 8; i++)
        {
            tables.Add(new Table(i, 2));
        }
        for (int i = 9; i <= 13; i++)
        {
            tables.Add(new Table(i, 4));
        }
        for (int i = 14; i <= 15; i++)
        {
            tables.Add(new Table(i, 6));
        }
        return tables;
    }

    public string ReserveerTafel(int HoeveelPlek)
    {
        foreach (Table table in tables)
        {
            Console.WriteLine(table.HoeveelPlek);
            if (table.HoeveelPlek == HoeveelPlek && table.Beschikbaar == true)
            {
                table.Beschikbaar = false;
                return $"Uw reserving is gemaakt voor tafel {table.TafelNummer}";
            }

        }
        return "Er zijn geen tafels beschikbaar voor uw groep";
    }

    public void Tafelindeling()
    {
        Console.WriteLine("----- Tafelindeling -----");
        Console.WriteLine("2-persoons tafels:");
        Console.WriteLine("+------+  +------+  +------+  +------+  +------+  +------+  +------+  +------+");

        for (int i = 0; i < 8; i++)
        {
            if (tables[i].Beschikbaar)
            {
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\n+------+  +------+  +------+  +------+  +------+  +------+  +------+  +------+");
        Console.WriteLine();
        Console.WriteLine("4-persoons tafels:");
        Console.WriteLine("+--------+  +--------+  +--------+  +--------+  +--------+");

        for (int i = 8; i < 13; i++)
        {
            if (tables[i].Beschikbaar)
            {
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|   ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\n+--------+  +--------+  +--------+  +--------+  +--------+");
        Console.WriteLine();
        Console.WriteLine("6-persoons tafels:");
        Console.WriteLine("+----------+  +----------+");

        for (int i = 13; i < 15; i++)
        {
            if (tables[i].Beschikbaar)
            {
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|    ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\n+----------+  +----------+");
        Console.WriteLine();
        Console.WriteLine("Overige informatie:");
        Console.WriteLine("- Er zijn in totaal 8 2-persoons tafels, 5 4-persoons tafels en 2 6-persoons tafels.");
        Console.WriteLine("- Tafels worden aangeduid met een uniek ID-nummer van 0 t/m 16.");
    }
}