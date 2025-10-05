namespace Program;

public interface ICharacter : IItem
{
    string Name { get; }
    List<IItem> Element { get; set; }
    int AmountLife { get; set; }
    int InitialLife { get; set; }

    void AddItem(IItem item);
    void RemoveItem(IItem e1);
    void ExchangeItem(IItem e1, IItem e2);
    void Attack(ICharacter opponent, IItem item);
    void Heal();
    int GetDefense();
}

/*
+AddItem (item : Item)
+RemoveItem (item : Item)
+Attack (opponent : T)
+Heal()
*/