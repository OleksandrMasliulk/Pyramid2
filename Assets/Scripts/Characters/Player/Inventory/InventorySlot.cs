public class InventorySlot
{
    public Item Item { get; set; }
    public int Count { get; set; }

    public InventorySlot() {
        Item = null;
        Count = 0;
    }
}
