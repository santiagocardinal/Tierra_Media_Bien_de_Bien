namespace Program;

public abstract class Character
{
    public string Name { get; set; }
    public List<Item> Element { get; set; }  
    public int AmountLife { get; set; }
    public int InitialLife { get; set; }

    public Character(string name, int amountLife, int initialLife)
    {
        this.Name = name;
        this.Element = new List<Item>();  
        this.AmountLife = amountLife;
        this.InitialLife = initialLife;
    }
    
    public void AddItem(Item item)
    {
        Element.Add(item);  
    }

    public void RemoveItem(Item item)
    {
        Element.Remove(item);  
    }
    
    public void ExchangeItem(Item e1, Item e2)
    {
        
        int indice = 0;
        foreach (var i in this.Element)  
        {
            if (i == e1)
            {
                indice = Element.IndexOf(i);  
            }
        }

        this.Element[indice] = e2; 
    }

    public abstract void Attack();

    public void Heal()
    {
        AmountLife = InitialLife;
    }

    public int GetDefense()
    {
        int defensa = 0;
        foreach (var item in Element)  
        {
            if (item is IDefenseItem defenseItem)
            {
                defensa += defenseItem.DefenseValue;
            }
        }
        return defensa;
    }

    public void ReceiveDamage(int damage)
    {
        AmountLife -= damage;
        if (AmountLife < 0)
            AmountLife = 0;
    }

    public bool IsAlive()
    {
        if (AmountLife > 0) 
            return true;
        
        return false;
    }
}