namespace Library;
public class Cape : IDefenseItem
{
    // Implementación de IItem
    public string Name { get; set; }
    public int DefenseValue { get; set; }


    public Cape(string name, int defenseValue)
    {
        this.Name = name;
        this.DefenseValue = defenseValue;
    }
    
}
