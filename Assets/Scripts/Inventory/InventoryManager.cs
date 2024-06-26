using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Slot[] slot;

    private void Awake()
    {
        displayInventory();
        inventory.inventoryChanged += displayInventory;
    }

    public void displayInventory()
    {
        int i = 0;
        foreach (Item item in inventory.items)
        {
            slot[i++].setItem(item);
        }
    }


}
