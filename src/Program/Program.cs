namespace Program;
public class MainProgram
{
    public static void Main(string[] args)
    {
        // Crear ítems
        Item espada = new Item("Espada", 10, 2);
        Item escudo = new Item("Escudo", 2, 10);
        Item arco = new Item("Arco", 7, 3);

        // Crear hechizos
        Spell rayo = new Spell("Rayo", 20);

        // Crear SpellBook
        SpellBook libroHechizos = new SpellBook();
        libroHechizos.AddSpell(rayo);

        // Crear personajes y asignarle items
        Wizard gandalf = new Wizard("Gandalf", libroHechizos);
        gandalf.AddItem(escudo);

        Elf legolas = new Elf("Legolas");
        legolas.AddItem(arco);

        Dwarf gimli = new Dwarf("Gimli");
        gimli.AddItem(espada);

        // Mostrar vida inicial de los personajes creados
        Console.WriteLine($"Vida de {legolas.Name}: {legolas.AmountLife}");
        Console.WriteLine($"Vida de {gimli.Name}: {gimli.AmountLife}");
        Console.WriteLine($"Vida de {gandalf.Name}: {gandalf.AmountLife}");

        // Gandalf ataca con hechizo a Legolas
        gandalf.WizardAttackWithSpell(legolas, rayo);
        Console.WriteLine($"{gandalf.Name} ataca a {legolas.Name} con su poder de Rayo!");
        Console.WriteLine($"Vida de {legolas.Name} después del ataque: {legolas.AmountLife}");

        // Gandalf ataca con hechizo a Gimli
        gandalf.WizardAttackWithSpell(gimli, rayo);
        Console.WriteLine($"{gandalf.Name} ataca a {gimli.Name} con Rayo!");
        Console.WriteLine($"Vida de {gimli.Name} después del ataque: {gimli.AmountLife}");
        
        //Legolas ataca con un arco a Gimli
        gimli.DwarfElf(legolas);
        Console.WriteLine($"{legolas.Name} ataca a {gimli.Name} con arco!");
        Console.WriteLine($"Vida de {gimli.Name} después del ataque: {gimli.AmountLife}");
        
    }
}
