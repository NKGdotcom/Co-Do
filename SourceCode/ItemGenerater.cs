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
        //itemList�̒�����type�ƈ�v�����瓯��item�𐶐����ēn��
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
