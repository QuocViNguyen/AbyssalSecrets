using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Image[] itemImages;

    private const int MaxItemSlots = 5;
    private Item[] items = new Item[MaxItemSlots];
    private int slotCount = 0;
    [SerializeField] Follower shark;

    private void Awake()
    {
        foreach (Image itemImage in itemImages)
            itemImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UseItem(4);
        }
    }

    private void UseItem(int slotIndex)
    {
        if (slotIndex < slotCount && itemImages[slotIndex].gameObject.activeSelf)
        {
            items[slotIndex].Use();
            itemImages[slotIndex].gameObject.SetActive(false);
        }
    }

    public bool AddItem(Item item)
    {
        if (slotCount < MaxItemSlots)
        {
            items[slotCount] = item;
            itemImages[slotCount].sprite = item.ItemSprite;
            itemImages[slotCount++].gameObject.SetActive(true);
            return true;
        }

        Debug.Log("Already full slots");
        return false;
    }
}
