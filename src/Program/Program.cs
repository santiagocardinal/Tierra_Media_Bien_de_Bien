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

            if (gandalf.AmountLife > 0 && legolas.AmountLife > 0)
            {
                Console.WriteLine($"{gandalf.Name} ataca con Rayo a {legolas.Name}");
                gandalf.WizardAttackWithSpell(legolas, rayo);
                Console.WriteLine($"Vida de {legolas.Name}: {legolas.AmountLife}\n");
            }

            if (legolas.AmountLife <= 0)
            {
                Console.WriteLine($"\n{legolas.Name} ha muerto!");
                Console.WriteLine($"{gandalf.Name} gana con {gandalf.AmountLife} de vida restante.\n");
                continue;
            }

            if (legolas.AmountLife > 0 && gandalf.AmountLife > 0)
            {
                Console.WriteLine($"{legolas.Name} contraataca con su Arco!");
                legolas.Attack(gandalf);
                Console.WriteLine($"Vida de {gandalf.Name}: {gandalf.AmountLife}\n");
            }

            if (gandalf.AmountLife <= 0)
            {
                Console.WriteLine($"\n{gandalf.Name} ha muerto!");
                Console.WriteLine($"{legolas.Name} gana con {legolas.AmountLife} de vida restante.\n");
            }
        }

        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");

        Console.WriteLine("\n>>> COMBATE: Gandalf (Mago) VS Legolas (Elfo)\n");

        while (gandalf.AmountLife > 0 && legolas.AmountLife > 0)
        {
            // Turno de Gandalf
            if (gandalf.AmountLife > 0 && legolas.AmountLife > 0)
            {
                Console.WriteLine($"{gandalf.Name} ataca con Rayo a {legolas.Name}");
                gandalf.WizardAttackWithSpell(legolas, rayo);
                Console.WriteLine($"Vida de {legolas.Name}: {legolas.AmountLife}\n");
            }

            if (legolas.AmountLife <= 0)
            {
                Console.WriteLine($"\n{legolas.Name} ha muerto!");
                Console.WriteLine($"{gandalf.Name} gana con {gandalf.AmountLife} de vida restante.\n");
                continue;
            }

            if (legolas.AmountLife > 0 && gandalf.AmountLife > 0)
            {
                Console.WriteLine($"{legolas.Name} contraataca con su Arco!");
                legolas.Attack(gandalf);
                Console.WriteLine($"Vida de {gandalf.Name}: {gandalf.AmountLife}\n");
            }

            if (gandalf.AmountLife <= 0)
            {
                Console.WriteLine($"\n{gandalf.Name} ha muerto!");
                Console.WriteLine($"{legolas.Name} gana con {legolas.AmountLife} de vida restante.\n");
            }
        }
        
        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");

        Console.WriteLine("\n>>> COMBATE: Gandalf (Mago) VS Marzee (Enano)\n");

        while (gandalf.AmountLife > 0 && marzee.AmountLife > 0)
        {

            if (gandalf.AmountLife > 0 && marzee.AmountLife > 0)
            {
                Console.WriteLine($"{gandalf.Name} ataca con Rayo a {marzee.Name}");
                gandalf.WizardAttackWithSpell(marzee, rayo);
                Console.WriteLine($"Vida de {marzee.Name}: {marzee.AmountLife}\n");
            }

            if (marzee.AmountLife <= 0)
            {
                Console.WriteLine($"\n{marzee.Name} ha muerto!");
                Console.WriteLine($"{gandalf.Name} gana con {gandalf.AmountLife} de vida restante.\n");
                continue; 
            }

            if (marzee.AmountLife > 0 && gandalf.AmountLife > 0)
            {
                Console.WriteLine($"{marzee.Name} contraataca con su espada!");
                marzee.Attack(gandalf);
                Console.WriteLine($"Vida de {gandalf.Name}: {gandalf.AmountLife}\n");
            }

            if (gandalf.AmountLife <= 0)
            {
                Console.WriteLine($"\n{gandalf.Name} ha muerto!");
                Console.WriteLine($"{marzee.Name} gana con {marzee.AmountLife} de vida restante.\n");
            }
        }
        
        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");


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

        Console.WriteLine("\n>>> COMBATE: Legolas (Elfo) VS Marzee (Enano)\n");
        marzee.Attack(legolas);

        while (legolas.AmountLife > 0 && marzee.AmountLife > 0)
        {
            // Turno de Legolas
            if (legolas.AmountLife > 0 && marzee.AmountLife > 0)
            {
                Console.WriteLine($"{legolas.Name} ataca a {marzee.Name} con su arco!");
                legolas.Attack(marzee);
                Console.WriteLine($"Vida de {marzee.Name}: {marzee.AmountLife}\n");
            }

            if (marzee.AmountLife <= 0)
            {
                Console.WriteLine($"\n{marzee.Name} ha muerto!");
                Console.WriteLine($"{legolas.Name} gana con {legolas.AmountLife} de vida restante.\n");
                continue;
            }

            if (marzee.AmountLife > 0 && legolas.AmountLife > 0)
            {
                Console.WriteLine($"{marzee.Name} contraataca con su espada!");
                marzee.Attack(legolas);
                Console.WriteLine($"Vida de {legolas.Name}: {legolas.AmountLife}\n");
            }

            if (legolas.AmountLife <= 0)
            {
                Console.WriteLine($"\n{legolas.Name} ha muerto!");
                Console.WriteLine($"{marzee.Name} gana con {marzee.AmountLife} de vida restante.\n");
            }
        }
        
        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");


        Console.WriteLine($"\nLegolas ataca a Gandalf\n");
        gandalf.Attack(legolas);
        Console.WriteLine($"{legolas.Name} ataca a {gandalf.Name} con arco!");
        Console.WriteLine($"Vida de {gandalf.Name} después del ataque: {gandalf.AmountLife}");
        
        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");


        Console.WriteLine("\n>>> COMBATE: Legolas (Elfo) VS Pomodoro (Elfo)\n");

        Item lanza = new Item("Lanza", 5, 0);
        Elf pomodoro = new Elf("Pomodoro");
        pomodoro.AddItem(lanza);
        pomodoro.Attack(legolas);

        while (legolas.AmountLife > 0 && pomodoro.AmountLife > 0)
        {
            if (legolas.AmountLife > 0 && pomodoro.AmountLife > 0)
            {
                Console.WriteLine($"{legolas.Name} ataca a {pomodoro.Name} con su espada!");
                legolas.Attack(pomodoro);
                Console.WriteLine($"Vida de {pomodoro.Name}: {pomodoro.AmountLife}\n");
            }

            if (pomodoro.AmountLife <= 0)
            {
                Console.WriteLine($"\n{pomodoro.Name} ha muerto!");
                Console.WriteLine($"{legolas.Name} gana con {legolas.AmountLife} de vida restante.\n");
                continue;
            }

            if (pomodoro.AmountLife > 0 && legolas.AmountLife > 0)
            {
                Console.WriteLine($"{pomodoro.Name} contraataca con su lanza!");
                pomodoro.Attack(legolas);
                Console.WriteLine($"Vida de {legolas.Name}: {legolas.AmountLife}\n");
            }

            if (legolas.AmountLife <= 0)
            {
                Console.WriteLine($"\n{legolas.Name} ha muerto!");
                Console.WriteLine($"{pomodoro.Name} gana con {pomodoro.AmountLife} de vida restante.\n");
            }
        }
        
        Console.WriteLine("______________________________________________________________");
        Console.WriteLine("CASOS EN EL QUE EL ENANO ATACA");
        Console.WriteLine("______________________________________________________________");


        Console.WriteLine("\nMarzee ataca con una espada a Legolas\n");
        legolas.Attack(marzee);
        Console.WriteLine($"{marzee.Name} ataca a {legolas.Name} con espada!");
        Console.WriteLine($"Vida de {legolas.Name} después del ataque: {legolas.AmountLife}");
        
        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");

        
        Console.WriteLine($"\nMarzee ataca con una espada a Gandalf\n");
        gandalf.Attack(marzee);
        Console.WriteLine($"{marzee.Name} ataca a {gandalf.Name} con espada!");
        Console.WriteLine($"Vida de {gandalf.Name} después del ataque: {gandalf.AmountLife}");
        
        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");

        Console.WriteLine("\n>>> COMBATE: Marzee (Enano) VS Llezram (Enano)\n");
        
        Item piedras = new Item("Piedras", 2, 0);
        Dwarf llezram = new Dwarf("Llezram");
        llezram.AddItem(piedras);
        llezram.Attack(marzee);
        
        while (marzee.AmountLife > 0 && llezram.AmountLife > 0)
        {
            if (marzee.AmountLife > 0 && llezram.AmountLife > 0)
            {
                Console.WriteLine($"{marzee.Name} ataca a {llezram.Name} con espada!");
                marzee.Attack(llezram);
                Console.WriteLine($"Vida de {llezram.Name}: {llezram.AmountLife}\n");
            }

            if (llezram.AmountLife <= 0)
            {
                Console.WriteLine($"\n{llezram.Name} ha muerto!");
                Console.WriteLine($"{marzee.Name} gana con {marzee.AmountLife} de vida restante.\n");
                continue;
            }

            if (llezram.AmountLife > 0 && marzee.AmountLife > 0)
            {
                Console.WriteLine($"{llezram.Name} contraataca con sus piedras!");
                llezram.Attack(marzee);
                Console.WriteLine($"Vida de {marzee.Name}: {marzee.AmountLife}\n");
            }

            if (marzee.AmountLife <= 0)
            {
                Console.WriteLine($"\n{marzee.Name} ha muerto!");
                Console.WriteLine($"{llezram.Name} gana con {llezram.AmountLife} de vida restante.\n");
            }
        }
        
        Console.WriteLine("///////////////////////////////////////////////////////////////////////////");
        
    }
}
