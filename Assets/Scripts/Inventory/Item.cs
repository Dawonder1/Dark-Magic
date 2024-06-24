using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string _name;
    //the name of an item is used to identify it.
    //when searching for an item, it is advised to search by name.
    public int numOwned;
    public int numEquiped;
    public int price;
    public Sprite icon;
}
