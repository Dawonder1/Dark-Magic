using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Store", menuName = "Scriptable Objects/Store")]
public class Store : ScriptableObject
{
    public List<Item> items;

    public void buy(int i)
    {
        items[i].numOwned++;
    }
}
