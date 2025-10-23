namespace Program;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("CASO DE PRUEBA 1: 1 Heroe vs 2 Villanos");
        Console.WriteLine("==============================================\n");
        CasoDePrueba1();
        
        Console.WriteLine("\n==============================================");
        Console.WriteLine("CASO DE PRUEBA 2: 4 Heroes vs 3 Villanos");
        Console.WriteLine("==============================================\n");
        CasoDePrueba2();
        
        Console.WriteLine("\n==============================================");
        Console.WriteLine("CASO DE PRUEBA 3: 2 Heroes vs 4 Villanos");
        Console.WriteLine("==============================================\n");
        CasoDePrueba3();
    }

    static void CasoDePrueba1()
    {
        CharacterRegistry registry = new CharacterRegistry();

        // Crear 1 heroe
        Dwarf aragorn = new Dwarf("Aragorn", 100, 100);
        Sword excalibur = new Sword("Excalibur", 25, 10);
        Cape capa = new Cape("Capa Protectora", 5);
        aragorn.AddItem(excalibur);
        aragorn.AddItem(capa);

        // Crear 2 villanos
        Ogre shrek = new Ogre("Shrek", 80, 80, 3);
        Stick palo = new Stick("Palo Grande", 15);
        shrek.AddItem(palo);

        Vampire dracula = new Vampire("Dracula", 70, 70, 2);
        Bow arco = new Bow("Arco Oscuro", 20);
        dracula.AddItem(arco);

        // Registrar personajes
        registry.ArrangeCharacters(aragorn);
        registry.ArrangeCharacters(shrek);
        registry.ArrangeCharacters(dracula);

        Console.WriteLine("Personajes registrados:");
        Console.WriteLine($"Heroe: {aragorn.Name} - Vida: {aragorn.AmountLife}");
        Console.WriteLine($"Villano: {shrek.Name} - Vida: {shrek.AmountLife}");
        Console.WriteLine($"Villano: {dracula.Name} - Vida: {dracula.AmountLife}\n");

        // Crear encuentro y ejecutar batalla
        Encounter encuentro = new Encounter(registry);
        encuentro.DoEncounter();

        Console.WriteLine("\nEstado final:");
        if (aragorn.IsAlive())
        {
            Console.WriteLine($"{aragorn.Name} sobrevivio con {aragorn.AmountLife} puntos de vida y {aragorn.VP} VP");
        }
    }

    static void CasoDePrueba2()
    {
        CharacterRegistry registry = new CharacterRegistry();

        // Crear 4 heroes
        Elf legolas = new Elf("Legolas", 90, 90);
        Bow arcoElfico = new Bow("Arco Elfico", 22);
        legolas.AddItem(arcoElfico);

        Dwarf gimli = new Dwarf("Gimli", 110, 110);
        Sword hacha = new Sword("Hacha de Guerra", 20, 12);
        gimli.AddItem(hacha);

        Wizard gandalf = new Wizard("Gandalf", 85, 85);
        SpellBook libroGandalf = new SpellBook("Grimorio Blanco");
        Attack bolaDeFuego = new Attack("Bola de Fuego", 30);
        Defense escudoMagico = new Defense("Escudo Magico", 15);
        libroGandalf.AddSpell(bolaDeFuego);
        libroGandalf.AddSpell(escudoMagico);
        gandalf.AddSpellBook(libroGandalf);
        Stick baston = new Stick("Baston de Poder", 18);
        gandalf.AddItem(baston);

        Elf arwen = new Elf("Arwen", 80, 80);
        Sword espadaElfica = new Sword("Espada Elfica", 19, 8);
        arwen.AddItem(espadaElfica);

        // Crear 3 villanos
        Ogre grendel = new Ogre("Grendel", 95, 95, 4);
        Stick maza = new Stick("Maza Pesada", 23);
        grendel.AddItem(maza);

        Vampire nosferatu = new Vampire("Nosferatu", 75, 75, 3);
        Bow ballesta = new Bow("Ballesta", 18);
        Cape capaNegra = new Cape("Capa Negra", 6);
        nosferatu.AddItem(ballesta);
        nosferatu.AddItem(capaNegra);

        Witch morgana = new Witch("Morgana", 70, 70, 3);
        SpellBook libroOscuro = new SpellBook("Grimorio Oscuro");
        Attack rayoNegro = new Attack("Rayo Negro", 28);
        libroOscuro.AddSpell(rayoNegro);
        morgana.AddSpellBook(libroOscuro);
        Stick cetro = new Stick("Cetro Maldito", 16);
        morgana.AddItem(cetro);

        // Registrar personajes
        registry.ArrangeCharacters(legolas);
        registry.ArrangeCharacters(gimli);
        registry.ArrangeCharacters(gandalf);
        registry.ArrangeCharacters(arwen);
        registry.ArrangeCharacters(grendel);
        registry.ArrangeCharacters(nosferatu);
        registry.ArrangeCharacters(morgana);

        Console.WriteLine("Personajes registrados:");
        Console.WriteLine($"Heroe: {legolas.Name} - Vida: {legolas.AmountLife}");
        Console.WriteLine($"Heroe: {gimli.Name} - Vida: {gimli.AmountLife}");
        Console.WriteLine($"Heroe: {gandalf.Name} - Vida: {gandalf.AmountLife}");
        Console.WriteLine($"Heroe: {arwen.Name} - Vida: {arwen.AmountLife}");
        Console.WriteLine($"Villano: {grendel.Name} - Vida: {grendel.AmountLife}");
        Console.WriteLine($"Villano: {nosferatu.Name} - Vida: {nosferatu.AmountLife}");
        Console.WriteLine($"Villano: {morgana.Name} - Vida: {morgana.AmountLife}\n");

        // Crear encuentro y ejecutar batalla
        Encounter encuentro = new Encounter(registry);
        encuentro.DoEncounter();

        Console.WriteLine("\nEstado final de los heroes:");
        foreach (var heroe in registry.GoodGuys)
        {
            Console.WriteLine($"{heroe.Name} - Vida: {heroe.AmountLife} - VP: {heroe.VP}");
        }
    }

    static void CasoDePrueba3()
    {
        CharacterRegistry registry = new CharacterRegistry();

        // Crear 2 heroes
        Dwarf thorin = new Dwarf("Thorin", 120, 120);
        Sword espadaEnana = new Sword("Espada Enana", 24, 14);
        Cape capaPesada = new Cape("Capa Pesada", 10);
        thorin.AddItem(espadaEnana);
        thorin.AddItem(capaPesada);

        Wizard merlin = new Wizard("Merlin", 95, 95);
        SpellBook libroMerlin = new SpellBook("Grimorio Ancestral");
        Attack llamarada = new Attack("Llamarada", 32);
        Defense barrera = new Defense("Barrera Arcana", 18);
        libroMerlin.AddSpell(llamarada);
        libroMerlin.AddSpell(barrera);
        merlin.AddSpellBook(libroMerlin);
        Stick vara = new Stick("Vara Magica", 20);
        merlin.AddItem(vara);

        // Crear 4 villanos
        Ogre trolloc = new Ogre("Trolloc", 100, 100, 5);
        Stick garrote = new Stick("Garrote", 26);
        trolloc.AddItem(garrote);

        Vampire carmilla = new Vampire("Carmilla", 85, 85, 4);
        Bow arcoDeSombras = new Bow("Arco de Sombras", 21);
        Cape mantoDeSangre = new Cape("Manto de Sangre", 8);
        carmilla.AddItem(arcoDeSombras);
        carmilla.AddItem(mantoDeSangre);

        Witch bellatrix = new Witch("Bellatrix", 75, 75, 3);
        SpellBook libroMalvado = new SpellBook("Libro Prohibido");
        Attack maldicion = new Attack("Maldicion Mortal", 29);
        libroMalvado.AddSpell(maldicion);
        bellatrix.AddSpellBook(libroMalvado);
        Stick varitaMaldita = new Stick("Varita Maldita", 17);
        bellatrix.AddItem(varitaMaldita);

        Ogre azog = new Ogre("Azog", 105, 105, 4);
        Sword espadaOscura = new Sword("Espada Oscura", 22, 7);
        azog.AddItem(espadaOscura);

        // Registrar personajes
        registry.ArrangeCharacters(thorin);
        registry.ArrangeCharacters(merlin);
        registry.ArrangeCharacters(trolloc);
        registry.ArrangeCharacters(carmilla);
        registry.ArrangeCharacters(bellatrix);
        registry.ArrangeCharacters(azog);

        Console.WriteLine("Personajes registrados:");
        Console.WriteLine($"Heroe: {thorin.Name} - Vida: {thorin.AmountLife}");
        Console.WriteLine($"Heroe: {merlin.Name} - Vida: {merlin.AmountLife}");
        Console.WriteLine($"Villano: {trolloc.Name} - Vida: {trolloc.AmountLife}");
        Console.WriteLine($"Villano: {carmilla.Name} - Vida: {carmilla.AmountLife}");
        Console.WriteLine($"Villano: {bellatrix.Name} - Vida: {bellatrix.AmountLife}");
        Console.WriteLine($"Villano: {azog.Name} - Vida: {azog.AmountLife}\n");

        // Crear encuentro y ejecutar batalla
        Encounter encuentro = new Encounter(registry);
        encuentro.DoEncounter();

        Console.WriteLine("\nEstado final:");
        if (registry.GoodGuys.Count > 0)
        {
            Console.WriteLine("Heroes sobrevivientes:");
            foreach (var heroe in registry.GoodGuys)
            {
                Console.WriteLine($"{heroe.Name} - Vida: {heroe.AmountLife} - VP: {heroe.VP}");
            }
        }
        if (registry.BadGuys.Count > 0)
        {
            Console.WriteLine("Villanos sobrevivientes:");
            foreach (var villano in registry.BadGuys)
            {
                Console.WriteLine($"{villano.Name} - Vida: {villano.AmountLife}");
            }
        }
    }
}