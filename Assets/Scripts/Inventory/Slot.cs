using UnityEngine;

[CreateAssetMenu(fileName = "Slot", menuName = "Scriptable Objects/Slot")]
public class Slot : ScriptableObject
{
    public Item slotItem;

    /*
     * Item is a Monobehaviour, as such it is a component.
     * The Item class can also be used to reference
     * a gameobject or prefab in the scene or in the assets.
     * This also allows us to use values from items without bothering
     * where their data is coming from.
    */


    public void emptySlot()
    {
        //to be subscribed to the event that the item...
        //finished in the equipment slot or is returned...
        //or whatever
        slotItem = null;
    }
}