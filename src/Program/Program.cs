namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        // Crear algunos ítems
        Item sword = new Item("Espada", 15, 5);
        Item shield = new Item("Escudo", 5, 20);
        Item axe = new Item("Hacha", 20, 10);
        Item wand = new Item("Varita", 25, 2);
        
        //Hechizos 

        Spell fuego = new Spell("Bola de fuego", 15);
        SpellBook book = new SpellBook();
        book.AddSpell(fuego);

        // Crear personajes
        Elf legolas = new Elf("Legolas");
        Wizard gandalf = new Wizard("Baltazar",book);
        Dwarf gimli = new Dwarf("Gimli");

        Console.WriteLine("\n=== Estado inicial ===\n");
        Console.WriteLine($"Elfo {legolas.Name} -> Vida: {legolas.AmountLife}");
        Console.WriteLine($"Mago -> Vida: {gandalf.AmountLife}");
        Console.WriteLine($"Enano {gimli.Name} -> Vida: {gimli.AmountLife}");

        // Agregar ítems
        legolas.AddItem(shield);
        legolas.AddItem(sword);
        gandalf.AddItem(shield);
        gandalf.AddItem(axe);
        gimli.AddItem(sword);

        Console.WriteLine("\n=== Después de agregar ítems ===\n");
        Console.WriteLine($"Elfo {legolas.Name} -> Vida: {legolas.AmountLife}");
        Console.WriteLine($"Mago -> Vida: {gandalf.AmountLife}");
        Console.WriteLine($"Enano {gimli.Name} -> Vida: {gimli.AmountLife}");

        // Simular daño y curación
        legolas.AmountLife -= 30;
        gimli.AmountLife -= 20;
        Console.WriteLine("\n=== Después de recibir daño ===\n");
        Console.WriteLine($"Elfo {legolas.Name} -> Vida: {legolas.AmountLife}");
        Console.WriteLine($"Enano {gimli.Name} -> Vida: {gimli.AmountLife}");

        legolas.Heal();
        gimli.Heal();
        Console.WriteLine("\n=== Después de curarse ===\n");
        Console.WriteLine($"Elfo {legolas.Name} -> Vida: {legolas.AmountLife}");
        Console.WriteLine($"Enano {gimli.Name} -> Vida: {gimli.AmountLife}");
        
        // Crear hechizos y libro de hechizos
        Spell fireball = new Spell("Bola de fuego", 30);
        Spell ice = new Spell("Hielo", 15);
        SpellBook spellBook = new SpellBook();

        Console.WriteLine("\n=== Hechizos en el libro ===\n");
        Console.WriteLine($"1. {fireball.SpellName} (Poder {fireball.Poder})");
        Console.WriteLine($"2. {ice.SpellName} (Poder {ice.Poder})");

        Console.WriteLine("\nFin de la simulación.\n");
    }
}