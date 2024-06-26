using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] Store store;
    [SerializeField] Inventory inventory;

    public void buy(Item item)
    {
        inventory.addToInventory(item);
    }
}
