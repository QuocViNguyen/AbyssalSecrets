using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private const int MaxItemSlots = 5;
    private Item[] items = new Item[MaxItemSlots];
    private int slotCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        items[0] = new Meat();
        items[1] = new Shield();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            items[0].Use();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            items[1].Use();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            items[2].Use();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            items[3].Use();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            items[4].Use();
        }
    }

    public void AddItem(Item item)
    {
        if (slotCount < MaxItemSlots)
        {
            items[slotCount++] = item;
        }
        else
        {
            Debug.Log("Already full slots");
        }
    }
}
