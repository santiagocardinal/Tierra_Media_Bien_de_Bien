using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BATALLA ÉPICA: HÉROES VS HORDA DE VILLANOS ===\n");

            // Crear personajes buenos (MENOS)
            Dwarf gimli = new Dwarf("Gimli", 120, 120, 150);
            Elf legolas = new Elf("Legolas", 100, 100, 120);
            Wizard gandalf = new Wizard("Gandalf", 90, 90, 200);

            // Crear personajes malos (MÁS)
            Ogre shrek = new Ogre("Shrek Malvado", 150, 150, 200);
            Ogre fiona = new Ogre("Fiona Ogresa", 140, 140, 180);
            Vampire dracula = new Vampire("Drácula", 110, 110, 180);
            Vampire nosferatu = new Vampire("Nosferatu", 100, 100, 160);
            Witch morgana = new Witch("Morgana", 85, 85, 150);
            Witch bellatrix = new Witch("Bellatrix", 80, 80, 140);

            // Crear armas de ataque
            Sword excalibur = new Sword("Excalibur", 35, 15);
            Bow arcoElfico = new Bow("Arco Élfico", 28);
            Stick bastonGandalf = new Stick("Bastón de Gandalf", 40);
            Stick bastonOscuro = new Stick("Bastón Oscuro", 25);
            Stick varitaMaldita = new Stick("Varita Maldita", 30);
            Sword espadaOscura = new Sword("Espada Oscura", 32, 10);

            // Crear items de defensa
            Cape capaElfica = new Cape("Capa Élfica", 20);
            Cape escudo = new Cape("Capa de Invisibilidad", 25);
            Cape capaMago = new Cape("Capa de Mago", 22);
            Bow arcooscuro = new Bow("Arco Maldito", 18);

            // Equipar a los HÉROES (3 héroes)
            Console.WriteLine("--- EQUIPANDO A LOS 3 HÉROES ---");
            gimli.AddItem(excalibur);
            gimli.AddItem(escudo);
            Console.WriteLine($"⚔️ {gimli.Name} equipado con {excalibur.Name} y {escudo.Name}");

            legolas.AddItem(arcoElfico);
            legolas.AddItem(capaElfica);
            Console.WriteLine($" {legolas.Name} equipado con {arcoElfico.Name} y {capaElfica.Name}");

            gandalf.AddItem(bastonGandalf);
            gandalf.AddItem(capaMago);
            Console.WriteLine($" {gandalf.Name} equipado con {bastonGandalf.Name} y {capaMago.Name}");

            // Equipar a los VILLANOS (6 villanos)
            Console.WriteLine("\n--- EQUIPANDO A LOS 6 VILLANOS ---");
            shrek.AddItem(new Stick("Garrote de Ogro", 30));
            shrek.AddItem(arcooscuro);
            Console.WriteLine($" {shrek.Name} equipado con Garrote y Escudo");

            fiona.AddItem(espadaOscura);
            Console.WriteLine($"{fiona.Name} equipada con {espadaOscura.Name}");

            dracula.AddItem(new Stick("Colmillos Afilados", 35));
            Console.WriteLine($" {dracula.Name} equipado con sus Colmillos Afilados");

            nosferatu.AddItem(new Stick("Garras Vampíricas", 32));
            Console.WriteLine($" {nosferatu.Name} equipado con Garras Vampíricas");

            morgana.AddItem(bastonOscuro);
            Console.WriteLine($"️ {morgana.Name} equipada con {bastonOscuro.Name}");

            bellatrix.AddItem(varitaMaldita);
            Console.WriteLine($" {bellatrix.Name} equipada con {varitaMaldita.Name}");

            // Simular combate épico
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║  ¡COMIENZA LA BATALLA DESIGUAL!       ║");
            Console.WriteLine("║  3 HÉROES vs 6 VILLANOS                ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            // Estado inicial
            Console.WriteLine("--- ESTADO INICIAL ---");
            Console.WriteLine($"🛡️ Héroes: {gimli.Name}({gimli.AmountLife}/{gimli.InitialLife}) | {legolas.Name}({legolas.AmountLife}/{legolas.InitialLife}) | {gandalf.Name}({gandalf.AmountLife}/{gandalf.InitialLife})");
            Console.WriteLine($"⚔️ Villanos: {shrek.Name}({shrek.AmountLife}/{shrek.InitialLife}) | {fiona.Name}({fiona.AmountLife}/{fiona.InitialLife}) | {dracula.Name}({dracula.AmountLife}/{dracula.InitialLife}) | {nosferatu.Name}({nosferatu.AmountLife}/{nosferatu.InitialLife}) | {morgana.Name}({morgana.AmountLife}/{morgana.InitialLife}) | {bellatrix.Name}({bellatrix.AmountLife}/{bellatrix.InitialLife})");
            Console.WriteLine();

            // RONDA 1
            Console.WriteLine("--- RONDA 1: Primera Oleada ---");
            gimli.Attack(shrek);
            legolas.Attack(dracula);
            gandalf.Attack(morgana);
            
            Console.WriteLine($"\n📊 Vida después de Ronda 1:");
            Console.WriteLine($"🛡️ Héroes: {gimli.Name}({gimli.AmountLife}/{gimli.InitialLife}) | {legolas.Name}({legolas.AmountLife}/{legolas.InitialLife}) | {gandalf.Name}({gandalf.AmountLife}/{gandalf.InitialLife})");
            Console.WriteLine($"⚔️ Villanos: {shrek.Name}({shrek.AmountLife}/{shrek.InitialLife}) | {fiona.Name}({fiona.AmountLife}/{fiona.InitialLife}) | {dracula.Name}({dracula.AmountLife}/{dracula.InitialLife}) | {nosferatu.Name}({nosferatu.AmountLife}/{nosferatu.InitialLife}) | {morgana.Name}({morgana.AmountLife}/{morgana.InitialLife}) | {bellatrix.Name}({bellatrix.AmountLife}/{bellatrix.InitialLife})");
            Console.WriteLine();

            // RONDA 2: Contraataque villanos
            Console.WriteLine("\n--- RONDA 2: Contraataque Villano ---");
            shrek.Attack(gimli);
            dracula.Attack(legolas);
            morgana.Attack(gandalf);
            fiona.Attack(gimli);

            Console.WriteLine($"\n📊 Vida después de Ronda 2:");
            Console.WriteLine($"🛡️ Héroes: {gimli.Name}({gimli.AmountLife}/{gimli.InitialLife}) | {legolas.Name}({legolas.AmountLife}/{legolas.InitialLife}) | {gandalf.Name}({gandalf.AmountLife}/{gandalf.InitialLife})");
            Console.WriteLine($"⚔️ Villanos: {shrek.Name}({shrek.AmountLife}/{shrek.InitialLife}) | {fiona.Name}({fiona.AmountLife}/{fiona.InitialLife}) | {dracula.Name}({dracula.AmountLife}/{dracula.InitialLife}) | {nosferatu.Name}({nosferatu.AmountLife}/{nosferatu.InitialLife}) | {morgana.Name}({morgana.AmountLife}/{morgana.InitialLife}) | {bellatrix.Name}({bellatrix.AmountLife}/{bellatrix.InitialLife})");
            Console.WriteLine();

            // RONDA 3
            Console.WriteLine("\n--- RONDA 3: Los Héroes Resisten ---");
            gimli.Attack(fiona);
            legolas.Attack(nosferatu);
            gandalf.Attack(bellatrix);

            Console.WriteLine($"\n📊 Vida después de Ronda 3:");
            Console.WriteLine($"🛡️ Héroes: {gimli.Name}({gimli.AmountLife}/{gimli.InitialLife}) | {legolas.Name}({legolas.AmountLife}/{legolas.InitialLife}) | {gandalf.Name}({gandalf.AmountLife}/{gandalf.InitialLife})");
            Console.WriteLine($"⚔️ Villanos: {shrek.Name}({shrek.AmountLife}/{shrek.InitialLife}) | {fiona.Name}({fiona.AmountLife}/{fiona.InitialLife}) | {dracula.Name}({dracula.AmountLife}/{dracula.InitialLife}) | {nosferatu.Name}({nosferatu.AmountLife}/{nosferatu.InitialLife}) | {morgana.Name}({morgana.AmountLife}/{morgana.InitialLife}) | {bellatrix.Name}({bellatrix.AmountLife}/{bellatrix.InitialLife})");
            Console.WriteLine();

            // RONDA 4: Asalto total
            Console.WriteLine("\n--- RONDA 4: ¡ASALTO TOTAL DE VILLANOS! ---");
            nosferatu.Attack(legolas);
            bellatrix.Attack(gandalf);
            shrek.Attack(gimli);
            dracula.Attack(legolas);

            Console.WriteLine($"\n📊 Vida después de Ronda 4:");
            Console.WriteLine($"🛡️ Héroes: {gimli.Name}({gimli.AmountLife}/{gimli.InitialLife}) | {legolas.Name}({legolas.AmountLife}/{legolas.InitialLife}) | {gandalf.Name}({gandalf.AmountLife}/{gandalf.InitialLife})");
            Console.WriteLine($"⚔️ Villanos: {shrek.Name}({shrek.AmountLife}/{shrek.InitialLife}) | {fiona.Name}({fiona.AmountLife}/{fiona.InitialLife}) | {dracula.Name}({dracula.AmountLife}/{dracula.InitialLife}) | {nosferatu.Name}({nosferatu.AmountLife}/{nosferatu.InitialLife}) | {morgana.Name}({morgana.AmountLife}/{morgana.InitialLife}) | {bellatrix.Name}({bellatrix.AmountLife}/{bellatrix.InitialLife})");
            Console.WriteLine();

            // RONDA 5: Ataque desesperado
            Console.WriteLine("\n--- RONDA 5: Ataque Desesperado de Héroes ---");
            if (gandalf.IsAlive()) gandalf.Attack(dracula);
            if (gimli.IsAlive()) gimli.Attack(shrek);
            if (legolas.IsAlive()) legolas.Attack(morgana);

            Console.WriteLine($"\n📊 Vida después de Ronda 5:");
            Console.WriteLine($"🛡️ Héroes: {gimli.Name}({gimli.AmountLife}/{gimli.InitialLife}) | {legolas.Name}({legolas.AmountLife}/{legolas.InitialLife}) | {gandalf.Name}({gandalf.AmountLife}/{gandalf.InitialLife})");
            Console.WriteLine($"⚔️ Villanos: {shrek.Name}({shrek.AmountLife}/{shrek.InitialLife}) | {fiona.Name}({fiona.AmountLife}/{fiona.InitialLife}) | {dracula.Name}({dracula.AmountLife}/{dracula.InitialLife}) | {nosferatu.Name}({nosferatu.AmountLife}/{nosferatu.InitialLife}) | {morgana.Name}({morgana.AmountLife}/{morgana.InitialLife}) | {bellatrix.Name}({bellatrix.AmountLife}/{bellatrix.InitialLife})");
            Console.WriteLine();

            // RONDA 6: Final
            Console.WriteLine("\n--- RONDA 6: Batalla Final ---");
            if (shrek.IsAlive()) shrek.Attack(gandalf);
            if (fiona.IsAlive()) fiona.Attack(gimli);
            if (morgana.IsAlive()) morgana.Attack(legolas);
            if (bellatrix.IsAlive()) bellatrix.Attack(gandalf);

            Console.WriteLine($"\n📊 Vida después de Ronda 6:");
            Console.WriteLine($"🛡️ Héroes: {gimli.Name}({gimli.AmountLife}/{gimli.InitialLife}) | {legolas.Name}({legolas.AmountLife}/{legolas.InitialLife}) | {gandalf.Name}({gandalf.AmountLife}/{gandalf.InitialLife})");
            Console.WriteLine($"⚔️ Villanos: {shrek.Name}({shrek.AmountLife}/{shrek.InitialLife}) | {fiona.Name}({fiona.AmountLife}/{fiona.InitialLife}) | {dracula.Name}({dracula.AmountLife}/{dracula.InitialLife}) | {nosferatu.Name}({nosferatu.AmountLife}/{nosferatu.InitialLife}) | {morgana.Name}({morgana.AmountLife}/{morgana.InitialLife}) | {bellatrix.Name}({bellatrix.AmountLife}/{bellatrix.InitialLife})");
            Console.WriteLine();

            // Resultado final
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║         RESULTADO FINAL                ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            int heroesVivos = 0;
            int villanosVivos = 0;

            if (gimli.IsAlive()) heroesVivos++;
            else Console.WriteLine($"💀 {gimli.Name} ha caído en batalla");

            if (legolas.IsAlive()) heroesVivos++;
            else Console.WriteLine($"💀 {legolas.Name} ha caído en batalla");

            if (gandalf.IsAlive()) heroesVivos++;
            else Console.WriteLine($"💀 {gandalf.Name} ha caído en batalla");

            if (shrek.IsAlive()) villanosVivos++;
            else Console.WriteLine($"💀 {shrek.Name} ha sido derrotado");

            if (fiona.IsAlive()) villanosVivos++;
            else Console.WriteLine($"💀 {fiona.Name} ha sido derrotada");

            if (dracula.IsAlive()) villanosVivos++;
            else Console.WriteLine($"💀 {dracula.Name} ha sido derrotado");

            if (nosferatu.IsAlive()) villanosVivos++;
            else Console.WriteLine($"💀 {nosferatu.Name} ha sido derrotado");

            if (morgana.IsAlive()) villanosVivos++;
            else Console.WriteLine($"💀 {morgana.Name} ha sido derrotada");

            if (bellatrix.IsAlive()) villanosVivos++;
            else Console.WriteLine($"💀 {bellatrix.Name} ha sido derrotada");

            Console.WriteLine($"\n🛡️ Héroes supervivientes: {heroesVivos}/3");
            Console.WriteLine($"⚔️ Villanos supervivientes: {villanosVivos}/6");

            if (heroesVivos > villanosVivos)
                Console.WriteLine("\n✨ ¡LOS HÉROES TRIUNFAN CONTRA TODO PRONÓSTICO! ✨");
            else if (villanosVivos > heroesVivos)
                Console.WriteLine("\n🌑 ¡LA OSCURIDAD PREVALECE! LOS VILLANOS GANAN 🌑");
            else
                Console.WriteLine("\n⚖️ ¡EMPATE ÉPICO! AMBOS BANDOS HAN LUCHADO VALIENTEMENTE ⚖️");
        }
    }
}