using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
/// <summary>
/// アイテムと画像を設定
/// </summary>
public class ItemDatas : ScriptableObject
{
    public List<ItemData> ItemDataLists { get => itemDataLists; private set => itemDataLists = value; }
    [Header("アイテムのデータリスト")]
    [Tooltip("アイテムのデータを格納するリスト")]
    [SerializeField] private List<ItemData> itemDataLists = new List<ItemData>();
}

/// <summary>
/// アイテムのデータを格納
/// </summary>
[System.Serializable]
public class ItemData
{
    [Header("アイテムのデータ")]
    [Tooltip("アイテムの種類を設定")]
    public Item item;
    [Tooltip("参照画像の設定")]
    public Sprite itemSprite;
    [Tooltip("アイテムの名前")]
    public string itemName;
    [Tooltip("アイテムの紹介テキスト")]
    public string itemText;
}

/// <summary>
/// アイテムの構造体
/// </summary>
public enum Item
{
    NONE, //何もない
    SLIPPERS, //スリッパ
    TOILET, //トイレ
    DRIVER, //ドライバー
    BLANKET, //ブランケット
    WHISTLE, //ホイッスル
    FLASHLIGHT, //懐中電灯
    WATER, //水
    GLOVE, //軍手
    BATTERY, //電池
    NOODLE, //麺
    PLASTICBAG, //ポリ袋
    STEPPING_STONE, //踏み台
    HAMMER, //ハンマー
    SCISSORS, //ハサミ
    RAINCOAT, //レインコート
    GLASS //ガラス片
}
