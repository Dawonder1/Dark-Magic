using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string _name;
    public int value;
    public Sprite sprite;
    public GameObject prefab;
    public int numOwned;
    public delegate void onItemUsed();
    public event onItemUsed itemUsed;

    public void use()
    {
        numOwned = numOwned > 0 ? numOwned-- : numOwned;
        itemUsed();
    }
}
