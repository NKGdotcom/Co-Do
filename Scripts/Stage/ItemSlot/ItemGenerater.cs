using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGenerater : MonoBehaviour
{
    //---アイテムのデータ---
    [SerializeField] private ItemDatas itemDatas;

    public static ItemGenerater Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Sprite ItemImage(Item _item)
    {
        foreach(var _data in itemDatas.ItemDataLists)
        {
            if(_item == _data.item)
            {
                return _data.itemSprite;
            }
        }
        return null;
    }

    public string ItemName(Item _item)
    {
        foreach (var _data in itemDatas.ItemDataLists)
        {
            if (_item == _data.item)
            {
                return _data.itemName;
            }
        }
        return null;
    }

    public string ItemIntroduce(Item _item)
    {
        foreach (var _data in itemDatas.ItemDataLists)
        {
            if (_item == _data.item)
            {
                return _data.itemText;
            }
        }
        return null;
    }
}
