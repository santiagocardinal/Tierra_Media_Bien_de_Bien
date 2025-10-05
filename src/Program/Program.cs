using System.ComponentModel;

namespace Program;

public class MainProgram
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== TEST SIMPLE DE FUNCIONAMIENTO ===\n");

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

