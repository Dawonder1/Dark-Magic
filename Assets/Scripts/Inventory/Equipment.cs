using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Scriptable Objects/Equipment")]
public class Equipment : ScriptableObject
{
    [SerializeField] int maxCapacity; //the maximum number of items that can be used in-game.
    [SerializeField] List<Slot> slots = new List<Slot>(6); 

    public bool isFull()
    {
        foreach (Slot slot in slots)
        {
            if(slot.slotItem == null) return false;
        }
        return true;
    }
}