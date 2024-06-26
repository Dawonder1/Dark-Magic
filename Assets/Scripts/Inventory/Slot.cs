using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    [SerializeField] Sprite itemImage;
    [SerializeField] TextMeshProUGUI numOwnedText;

    public void setItem(Item itemToSet)
    {
        item = itemToSet;
        loadItem();
        item.itemUsed += loadItem;
    }

    void loadItem()
    {
        itemImage = item.sprite;
        GetComponent<Image>().sprite = itemImage;
        if(item == null) { return; }
        numOwnedText.text = item.numOwned.ToString();
    }

    private void OnDisable()
    {
        if (item == null) return;
        item.itemUsed -= loadItem;
    }
}
