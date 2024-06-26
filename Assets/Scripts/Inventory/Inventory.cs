using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    [System.Serializable]
    struct inventoryItems
    {
        public List<Item> items;
    }

    public delegate void onInventoryChanged();
    public event onInventoryChanged inventoryChanged;

    //fields
    [HideInInspector]
    public string inventoryPath;

    [Tooltip("The items in the inventory")]
    public List<Item> items = new List<Item>();

    private void saveInventory()
    {
        string str = JsonUtility.ToJson(items);
        File.WriteAllText(inventoryPath, str);
    }

    private void LoadInventory()
    {
        string str = File.ReadAllText(inventoryPath);
        var inventoryItems = JsonUtility.FromJson<inventoryItems>(str);
        items = inventoryItems.items;
    }

    public void addToInventory(Item item)
    {
        if (items.Contains(item)) { item.numOwned++; }
        else { items.Add(item); }
        if(inventoryChanged != null) inventoryChanged();
    }

    public void removeFromInventory(Item item)
    {
        if (items.Contains(item)) { items.Remove(item); }
        if (inventoryChanged != null) inventoryChanged();
    }

    private void OnEnable()
    {
        inventoryPath = Application.persistentDataPath + "/InventorySave";
        saveInventory();
    }

    private void OnDisable()
    {
        saveInventory();
    }
}
