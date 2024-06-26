using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item item;
    [SerializeField] Sprite itemImage;
    TextMeshProUGUI numOwnedText;

    private void OnEnable()
    {
        loadItem();
        item.itemUsed += loadItem;
    }

    public void setItem(Item itemToSet)
    {
        item = itemToSet;
        loadItem();
    }

    void loadItem()
    {
        itemImage = item.sprite;
        GetComponent<SpriteRenderer>().sprite = itemImage;
        numOwnedText.text = item.numOwned.ToString();
    }

    private void OnDisable()
    {
        item.itemUsed -= loadItem;
    }
}
