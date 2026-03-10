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
    [SerializeField] private List<ItemData> itemDataLists = new List<ItemData>();
}

/// <summary>
/// アイテムのデータを格納
/// </summary>
[System.Serializable]
public class ItemData
{
    [Header("アイテムの種類")]
    public Item item;
    [Header("参照画像")]
    public Sprite itemSprite;
    [Header("アイテム名")]
    public string itemName;
    [Header("紹介テキスト")]
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
