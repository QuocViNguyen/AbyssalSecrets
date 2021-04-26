using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Image[] itemImages;

    private const int MaxItemSlots = 5;
    private static Item[] items = new Item[MaxItemSlots];
    private static int slotCount = 0;
    [SerializeField] SharkFollower shark;

    private void Awake()
    {
        InitSlots();
    }

    private void InitSlots()
    {
        var tempItems = items;
        items = new Item[MaxItemSlots];
        slotCount = 0;
        for (int i = 0; i < MaxItemSlots; i++)
        {
            if (tempItems[i] != null)
            {
                items[slotCount] = tempItems[i];
                itemImages[slotCount].sprite = items[slotCount].ItemSprite;
                itemImages[slotCount].gameObject.SetActive(true);
                slotCount++;
            }
        }

        for (int i = slotCount; i < MaxItemSlots; i++)
            itemImages[i].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GameStarted)
            return;

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
        if (slotIndex < slotCount && itemImages[slotIndex] != null)
        {
            items[slotIndex].Use();
            itemImages[slotIndex].gameObject.SetActive(false);
            if (items[slotIndex] is SmellyBomb)
            {
                shark.ToTheDen();
            }

            items[slotIndex] = null;
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
