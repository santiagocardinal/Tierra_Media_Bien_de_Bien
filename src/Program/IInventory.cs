namespace Program;

public interface IInventory<T> where T : IItem
{
    void AddItem(T item);
    void RemoveItem(T item);
    List<T> GetItems();
    int GetAttackValue();
    int GetDefenseValue();
}