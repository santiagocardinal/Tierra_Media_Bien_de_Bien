namespace Program;

public interface ICharacter<T>
{
    string Name { get; }
    List<IItem> Element { get; set; }
    int AmountLife { get; set; }
    int InitialLife { get; set; }

    void AddItem(IItem item);
    void RemoveItem(IItem item);
    void ExchangeItem(IItem item);
    void Attack(T opponent, IItem item);
    void Heal();
}

/*
+AddItem (item : Item)
+RemoveItem (item : Item)
+Attack (opponent : T)
+Heal()
*/