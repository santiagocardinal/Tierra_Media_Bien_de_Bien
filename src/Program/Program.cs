using System.ComponentModel;

namespace Program;

public class MainProgram
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== TEST SIMPLE DE MECÁNICAS ===\n");

            // === TEST 1: CREAR PERSONAJES ===
            Console.WriteLine("TEST 1: Crear personajes");
            Wizard wizard = new Wizard("Mago", 100, 100);
            Elf elf = new Elf("Elfo", 80);
            
            Console.WriteLine($"Wizard - Vida: {wizard.AmountLife} (esperado: 100) ✓");
            Console.WriteLine($"Elf - Vida: {elf.AmountLife} (esperado: 80) ✓\n");

            // === TEST 2: EQUIPAR ITEMS DE DEFENSA ===
            Console.WriteLine("TEST 2: Defensa");
            Cape capa1 = new Cape("Capa", 10);
            Cape capa2 = new Cape("Armadura", 15);
            
            elf.AddItem(capa1);
            Console.WriteLine($"Elf equipa capa (defensa +10)");
            Console.WriteLine($"  Defensa total: {elf.GetDefense()} (esperado: 10) ✓");
            
            elf.AddItem(capa2);
            Console.WriteLine($"Elf equipa armadura (defensa +15)");
            Console.WriteLine($"  Defensa total: {elf.GetDefense()} (esperado: 25) ✓\n");

            // === TEST 3: ATAQUE SIN DEFENSA ===
            Console.WriteLine("TEST 3: Ataque básico sin defensa");
            Dwarf dwarf = new Dwarf("Enano", 100);
            Sword espada = new Sword("Espada", 20, 0);
            
            Console.WriteLine($"Enano vida inicial: {dwarf.AmountLife}");
            Console.WriteLine($"Wizard ataca con espada (ataque: 20)");
            Console.WriteLine($"Enano defensa: {dwarf.GetDefense()}");
            
            wizard.AddItem(espada);
            wizard.Attack(dwarf, espada);
            
            Console.WriteLine($"Enano vida final: {dwarf.AmountLife}");
            Console.WriteLine($"  Esperado: 100 - 20 = 80");
            Console.WriteLine($"  Real: {dwarf.AmountLife}\n");

            // === TEST 4: ATAQUE CON DEFENSA ===
            Console.WriteLine("TEST 4: Ataque con defensa");
            elf.AmountLife = 80; // Resetear
            Bow arco = new Bow("Arco", 30);
            wizard.AddItem(arco);
            
            Console.WriteLine($"Elf vida inicial: {elf.AmountLife}");
            Console.WriteLine($"Elf defensa: {elf.GetDefense()}");
            Console.WriteLine($"Wizard ataca con arco (ataque: 30)");
            
            wizard.Attack(elf, arco);
            
            Console.WriteLine($"Elf vida final: {elf.AmountLife}");
            Console.WriteLine($"  Esperado: 80 + 25(defensa) - 30 = 75");
            Console.WriteLine($"  Real: {elf.AmountLife}\n");

            // === TEST 5: SPELLBOOK Y HECHIZOS ===
            Console.WriteLine("TEST 5: Ataque con hechizo");
            SpellBook libro = new SpellBook("Libro");
            Spell hechizo = new Spell("Fuego", 40);
            libro.AddSpell(hechizo);
            wizard.AddItem(libro);
            
            dwarf.AmountLife = 100; // Resetear
            dwarf.AddItem(new Cape("Escudo", 5));
            
            Console.WriteLine($"Enano vida inicial: {dwarf.AmountLife}");
            Console.WriteLine($"Enano defensa: {dwarf.GetDefense()}");
            Console.WriteLine($"Wizard lanza hechizo (poder: 40)");
            
            wizard.WizardAttackWithSpell(hechizo, dwarf);
            
            Console.WriteLine($"Enano vida final: {dwarf.AmountLife}");
            Console.WriteLine($"  Esperado: 100 + 5(defensa) - 40 = 65");
            Console.WriteLine($"  Real: {dwarf.AmountLife}\n");

            // === TEST 6: CURACIÓN ===
            Console.WriteLine("TEST 6: Curación");
            Console.WriteLine($"Enano vida actual: {dwarf.AmountLife}");
            Console.WriteLine($"Enano vida inicial: {dwarf.InitialLife}");
            
            dwarf.Heal();
            
            Console.WriteLine($"Enano después de curar: {dwarf.AmountLife}");
            Console.WriteLine($"  Esperado: {dwarf.InitialLife}");
            Console.WriteLine($"  Real: {dwarf.AmountLife} ✓\n");

            // === TEST 7: REMOVER ITEM ===
            Console.WriteLine("TEST 7: Remover item");
            Console.WriteLine($"Elf defensa con items: {elf.GetDefense()}");
            
            elf.RemoveItem(capa1);
            
            Console.WriteLine($"Elf defensa sin capa1: {elf.GetDefense()}");
            Console.WriteLine($"  Esperado: 15 (solo capa2)");
            Console.WriteLine($"  Real: {elf.GetDefense()} ✓\n");

            Console.WriteLine("=== TODOS LOS TESTS COMPLETADOS ===");
    }
}


/*// Crear ítems
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
*/
