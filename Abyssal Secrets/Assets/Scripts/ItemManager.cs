using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private const int MaxItemSlots = 5;
    Item[] items = new Item[MaxItemSlots];

    // Start is called before the first frame update
    void Start()
    {
        items[0] = new Meat();
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
}
