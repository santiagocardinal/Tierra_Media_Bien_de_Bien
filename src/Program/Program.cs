using System.ComponentModel;

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
        Spell chorro_de_agua = new Spell("Chorro de agua", 10);


        // Crear SpellBook
        SpellBook libroHechizos = new SpellBook();
        libroHechizos.AddSpell(rayo);
        SpellBook libroHechizos2 = new SpellBook();
        libroHechizos2.AddSpell(chorro_de_agua);
        
        // Crear personajes y asignarle items
        Wizard gandalf = new Wizard("Gandalf", libroHechizos);
        gandalf.AddItem(escudo);

        Elf legolas = new Elf("Legolas");
        legolas.AddItem(arco);

        Dwarf marzee = new Dwarf("Marzee");
        marzee.AddItem(espada);

        Console.WriteLine("______________________________________________________________");
        
        // Mostrar vida inicial de los personajes creados
        Console.WriteLine($"Vida de {legolas.Name}: {legolas.AmountLife}");
        Console.WriteLine($"Vida de {marzee.Name}: {marzee.AmountLife}");
        Console.WriteLine($"Vida de {gandalf.Name}: {gandalf.AmountLife}");
        
        Console.WriteLine("______________________________________________________________");
        
        Console.WriteLine("______________________________________________________________");
        Console.WriteLine("CASOS EN EL QUE EL MAGO ATACA");
        Console.WriteLine("______________________________________________________________");

        while (gandalf.AmountLife > 0 && legolas.AmountLife > 0)
        {
            // Turno de Gandalf
            if (gandalf.AmountLife > 0 && legolas.AmountLife > 0)
            {
                Console.WriteLine($"{gandalf.Name} ataca con Rayo a {legolas.Name}");
                gandalf.WizardAttackWithSpell(legolas, rayo);
                Console.WriteLine($"Vida de {legolas.Name}: {legolas.AmountLife}\n");
            }

            // Chequear si Legolas murió después del ataque
            if (legolas.AmountLife <= 0)
            {
                Console.WriteLine($"\n{legolas.Name} ha muerto!");
                Console.WriteLine($"{gandalf.Name} gana con {gandalf.AmountLife} de vida restante.\n");
                continue; // salta el turno de Legolas
            }

            // Turno de Legolas
            if (legolas.AmountLife > 0 && gandalf.AmountLife > 0)
            {
                Console.WriteLine($"{legolas.Name} contraataca con su Arco!");
                legolas.Attack(gandalf);
                Console.WriteLine($"Vida de {gandalf.Name}: {gandalf.AmountLife}\n");
            }

            // Chequear si Gandalf murió después del contraataque
            if (gandalf.AmountLife <= 0)
            {
                Console.WriteLine($"\n{gandalf.Name} ha muerto!");
                Console.WriteLine($"{legolas.Name} gana con {legolas.AmountLife} de vida restante.\n");
            }
        }
        
       /* 
        Console.WriteLine($"\nGandalf ataca con hechizo a Legolas\n");
        gandalf.WizardAttackWithSpell(legolas, rayo);
        Console.WriteLine($"{gandalf.Name} ataca a {legolas.Name} con su poder de Rayo!");
        Console.WriteLine($"Vida de {legolas.Name} después del ataque: {legolas.AmountLife}");

        Console.WriteLine($"\nGandalf ataca con hechizo a Marzell\n");
        gandalf.WizardAttackWithSpell(marzee, rayo);
        Console.WriteLine($"{gandalf.Name} ataca a {marzee.Name} con Rayo!");
        Console.WriteLine($"Vida de {marzee.Name} después del ataque: {marzee.AmountLife}");

        Console.WriteLine($"\nGandalf ataca a alguien de su especie (Merlin)\n");
        Item baston = new Item("Baston", 6, 4);
        Wizard merlin = new Wizard("Merlin", libroHechizos);
        merlin.AddItem(baston);
        gandalf.WizardAttackWithSpell(merlin, chorro_de_agua);
        Console.WriteLine($"{gandalf.Name} ataca a {marzee.Name} con Rayo!");
        Console.WriteLine($"Vida de {merlin.Name} después del ataque: {merlin.AmountLife}");
      
        
        Console.WriteLine("______________________________________________________________");
        Console.WriteLine("CASOS EN EL QUE EL ELFO ATACA");
        Console.WriteLine("______________________________________________________________");

        Console.WriteLine($"\nLegolas ataca con un arco a Marzee\n");
        marzee.Attack(legolas);
        Console.WriteLine($"{legolas.Name} ataca a {marzee.Name} con arco!");
        Console.WriteLine($"Vida de {marzee.Name} después del ataque: {marzee.AmountLife}");

        Console.WriteLine($"\nLegolas ataca a Gandalf\n");
        gandalf.Attack(legolas);
        Console.WriteLine($"{legolas.Name} ataca a {gandalf.Name} con arco!");
        Console.WriteLine($"Vida de {gandalf.Name} después del ataque: {gandalf.AmountLife}");

        Console.WriteLine($"\nLegolas ataca a alguien de su misma especie (Pomodoro)\n");
        Item lanza = new Item("Lanza", 5, 0);
        Elf pomodoro = new Elf("Pomodoro");
        pomodoro.AddItem(lanza);
        pomodoro.Attack(legolas);
        Console.WriteLine($"Vida de {pomodoro.Name}: {pomodoro.AmountLife}");
        Console.WriteLine($"{legolas.Name} ataca a {pomodoro.Name} con espada!");
        Console.WriteLine($"Vida de {pomodoro.Name} después del ataque: {pomodoro.AmountLife}");
        
        Console.WriteLine("______________________________________________________________");
        Console.WriteLine("CASOS EN EL QUE EL ENANO ATACA");
        Console.WriteLine("______________________________________________________________");


        Console.WriteLine("\nMarzee ataca con una espada a Legolas\n");
        legolas.Attack(marzee);
        Console.WriteLine($"{marzee.Name} ataca a {legolas.Name} con espada!");
        Console.WriteLine($"Vida de {legolas.Name} después del ataque: {legolas.AmountLife}");
        
        Console.WriteLine($"\nMarzee ataca con una espada a Gandalf\n");
        gandalf.Attack(marzee);
        Console.WriteLine($"{marzee.Name} ataca a {gandalf.Name} con espada!");
        Console.WriteLine($"Vida de {gandalf.Name} después del ataque: {gandalf.AmountLife}");
        
        Console.WriteLine($"\nMarzee ataca a alguien de su misma especie (Llezram)\n");
        Item piedras = new Item("Piedras", 2, 0);
        Dwarf llezram = new Dwarf("Llezram");
        llezram.AddItem(piedras);
        llezram.Attack(marzee);
        Console.WriteLine($"Vida de {llezram.Name}: {llezram.AmountLife}");
        Console.WriteLine($"{marzee.Name} ataca a {llezram.Name} con espada!");
        Console.WriteLine($"Vida de {llezram.Name} después del ataque: {llezram.AmountLife}");
        */
        
    }
}
