public interface IItemContainer {

    int ItemCount(Items item);
    bool ContainsItems(Items item);
    bool AddItem(Items item);
    bool RemoveItem(Items item);
    bool IsFull();
}