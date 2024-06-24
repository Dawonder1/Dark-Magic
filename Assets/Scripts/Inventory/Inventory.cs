using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    public interface Item
    {

    }

    [System.Serializable]
    public struct BackpackSpace
    {
        public Item item;
    }

    [SerializeField] int maxCapacity;
    [SerializeField]
    List<BackpackSpace> backpack = new List<BackpackSpace>();

    public bool addToInventory(Item itemToAdd)
    {
        if(backpack.Count < maxCapacity) return false;
        //if backpack is not full, create a space for the new item
        BackpackSpace newSpace = new();
        newSpace.item = itemToAdd;

        //add the new item to the backpack
        backpack.Add(newSpace);
        return true;
    }

    public void removeFromInventory(Item itemToRemove)
    {
        BackpackSpace space = new();
        space.item = itemToRemove;
        //if the item to be removed is not in the backpack, return.
        if (!backpack.Contains(space)) return;
        backpack.Remove(space);
    }
}
