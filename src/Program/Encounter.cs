namespace Program;

public class Encounter
{
    private CharacterRegistry registry;
    
    public Encounter(CharacterRegistry registry)
    {
        this.registry = registry;
    }
    
    
    public void DoEncounter()
    {
        List<GoodGuy> good = registry.GoodGuys;
        List<BadGuy> bad = registry.BadGuys;

        int largoGood = good.Count;
        int largoBad = bad.Count;
        
        if (largoGood==1 && largoBad>1)
        {
            OneHeroe(good, bad);
        }
        else if (largoBad > 1 && largoGood>1)
        {
            Battle(good, bad);
        }
        else
        {
            Console.WriteLine("No hay suficientes enemigos para la batalla");
        }
    }

    public void OneHeroe(List<GoodGuy> good, List<BadGuy> bad)
    {
        GoodGuy heroe = good[0];
        int i = 0;

        // Mientras el héroe siga vivo y queden villanos
        while (heroe.IsAlive() && i < bad.Count)
        {
            BadGuy villan = bad[i];
            villan.Attack(heroe);

            if (!heroe.IsAlive())
            {
                Console.WriteLine($"{heroe.Name} ha muerto en combate.");
                good.Remove(heroe);
                return; // termina naturalmente
            }

            // Pasamos al siguiente villano
            i++;
        }

        // Si termina el bucle y el héroe sigue vivo
        if (heroe.IsAlive())
        {
            Console.WriteLine($"{heroe.Name} ha sobrevivido a todos los villanos!");
        }
    }

    public void Battle(List<GoodGuy> heroes, List<BadGuy> villanos)
    {
        // Mientras ambos bandos tengan combatientes
        while (heroes.Count > 0 && villanos.Count > 0)
        {
            int cantidad = Math.Max(heroes.Count, villanos.Count);

            for (int i = 0; i < cantidad; i++)
            {
                // Rotar índices con módulo
                GoodGuy hero = heroes[i % heroes.Count];
                BadGuy villain = villanos[i % villanos.Count];

                // Ataques
                villain.Attack(hero);
                hero.Attack(villain);

                // Verificar si alguno murió y eliminarlo
                if (!hero.IsAlive())
                {
                    Console.WriteLine($"{hero.Name} ha muerto!");
                    heroes.Remove(hero);
                    if (heroes.Count == 0) break; // Termina si no quedan héroes
                }

                if (!villain.IsAlive())
                {
                    Console.WriteLine($"{villain.Name} ha muerto!");
                    villanos.Remove(villain);
                    if (villanos.Count == 0) break; // Termina si no quedan villanos
                }
            }
        }

        // Determinar ganador
        if (heroes.Count == 0 && villanos.Count == 0)
            Console.WriteLine("Ambos bandos cayeron...");
        else if (heroes.Count == 0)
            Console.WriteLine("¡Los villanos ganan!");
        else
            Console.WriteLine("¡Los héroes ganan!");
    }

}