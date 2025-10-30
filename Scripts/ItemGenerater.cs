using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [SerializeField] private Items _items;

    public static ItemGenerater Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public Items.ItemType GetItemInformation(Items.ItemType.ItemTypes type)
    {
        foreach(Items.ItemType item in _items.itemsList)
        {
            if (item.itemTypes == type)
            {
                return new Items.ItemType(item.itemTypes, item.itemImage);
            }
        }
        return null;
    }
   
}
