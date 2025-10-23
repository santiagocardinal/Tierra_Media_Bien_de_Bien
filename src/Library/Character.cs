namespace Library;

public abstract class Character
{
    public string Name { get; set; }
    public List<IItem> Element { get; set; }  
    public int AmountLife { get; set; }
    public int InitialLife { get; set; }

    public Character(string name, int amountLife, int initialLife)
    {
        this.Name = name;
        this.Element = new List<IItem>();  
        this.AmountLife = amountLife;
        this.InitialLife = initialLife;
    }
    
    public void AddItem(IItem item)
    {
        Element.Add(item);  
    }

    public void RemoveItem(IItem item)
    {
        Element.Remove(item);  
    }
    
    public void ExchangeItem(IItem e1, IItem e2)
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