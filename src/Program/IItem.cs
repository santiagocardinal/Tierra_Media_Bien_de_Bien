namespace Program;

public interface IItem
{
//List<Item> element;
     void AddItem(IItem item);   //parametro ITEM del tipo IITEM
     void RemoveItem(IItem item);
     void ExchangeItem(IItem item);
     /*
    public List<Item> Element
    {
        get { return element; }
        set { element = value; }
    }
    
    public Item(string nameItem, int attackValue, int defenseValue)
    {
        this.NameItem = nameItem;

    }
    
    public void AddItem(Item element)
    {
        this.Element.Add(element);
    }
    
    public void RemoveItem(Item element)
    {
        this.Element.Remove(element);
    }
    
    public void ExchangeItem(Item e1, Item e2)
    {
        int index = this.Element.IndexOf(e1);
        if (index != -1)
        {
            this.Element[index] = e2;
            
        }
    }*/
}