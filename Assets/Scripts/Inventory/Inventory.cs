using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    [System.Serializable]
    struct inventoryItems
    {
        public List<Slot> slots;
    }

    //fields
    [HideInInspector]
    public string inventoryPath;
    [Tooltip("The slots in the inventory.")]
    public List<Slot> slots = new List<Slot>();

    private void saveInventory()
    {
        string str = JsonUtility.ToJson(slots);
        File.WriteAllText(inventoryPath, str);
    }

    private void LoadInventory()
    {
        string str = File.ReadAllText(inventoryPath);
        var inventoryItems = JsonUtility.FromJson<inventoryItems>(str);
        slots = inventoryItems.slots;
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
