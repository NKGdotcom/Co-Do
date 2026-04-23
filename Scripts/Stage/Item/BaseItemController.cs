using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 落ちているアイテムの処理をつなぐクラス
/// </summary>
public class BaseItemController : MonoBehaviour, IItem
{

    public Item MyItem { get => myItem; }
    [Header("アイテムのデータ")]
    [Tooltip("アイテムのデータを選択してください")]
    [SerializeField] private Item myItem;
}
