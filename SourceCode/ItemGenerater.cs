using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [SerializeField] ItemListEntity itemListEntity;

    public static ItemGenerater instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public Items Spawn(Items.Type type)
    {
        //itemListの中からtypeと一致したら同じitemを生成して渡す
        foreach (Items item in itemListEntity.itemList)
        {
            if(item.type == type)
            {
                return new Items(item.type, item.sprite);
            }
        }
        return null;
    }
}
