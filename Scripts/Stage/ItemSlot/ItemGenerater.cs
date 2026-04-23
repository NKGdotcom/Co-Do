using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテム生成を行うクラス
/// </summary>
public class ItemGenerater : MonoBehaviour
{
    [Header("アイテムデータリスト")]
    [Tooltip("ここの中にあるデータからアイテムデータを取り出す")]
    [SerializeField] private ItemDatas itemDatas;

    public static ItemGenerater Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// 設定したアイテムのSpriteを取得
    /// </summary>
    /// <param name="_item"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 設定したアイテム名を取得
    /// </summary>
    /// <param name="_item"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 設定したアイテムの説明文を取得
    /// </summary>
    /// <param name="_item"></param>
    /// <returns></returns>
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
