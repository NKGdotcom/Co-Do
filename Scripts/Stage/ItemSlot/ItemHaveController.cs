using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// 現在所有しているアイテムの管理を行うクラス
/// </summary>
public class ItemHaveController : MonoBehaviour
{
    [Header("コンポーネントの参照")]
    [Tooltip("アイテムのスロットリストから現在何個アイテムを持っているかを管理")]
    [SerializeField] private List<ItemDragController> itemDragController;
    //現在の所有アイテム数を管理
    private List<ItemDragController> nowFullSlot = new List<ItemDragController>(); //現在どのくらいアイテムを持っているかのリスト
    //現在のアイテム数
    private int itemMaxCount = 0;
    private int nowItemNum;

    private void Awake()
    {
        if (itemDragController == null) { Debug.LogError("itemDragControllerが参照されていません。"); return; }
        itemMaxCount = itemDragController.Count;

        foreach(var itemSlot in itemDragController)
        {
            itemSlot.OnUseItem += UseItem;
        }
    }

    private void OnDestroy()
    {
        foreach (var itemSlot in itemDragController)
        {
            itemSlot.OnUseItem -= UseItem;
        }
    }

    /// <summary>
    /// アイテムを使用したら
    /// </summary>
    private void UseItem(ItemDragController _usedSlot)
    {
        //所有数を減らす
        nowItemNum--;
        nowItemNum = Mathf.Clamp(nowItemNum, 0, itemMaxCount);

        //使用したindexを取得し、空にする
        int _index = nowFullSlot.IndexOf(_usedSlot);
        if (_index != -1)
        {
            nowFullSlot[_index] = null;
        }
    }

    /// <summary>
    /// スロットの中身に空きがあるかを確認してアイテムを取得
    /// </summary>
    public void GetItemReservation(Item _colItem)
    {
        //アイテムが空であるかどうかを確認
        if (HasEmptySlot())
        {
            GetItem(_colItem);
        }

    }
    /// <summary>
    /// アイテムスロット数がいっぱいか判断
    /// </summary>
    /// <returns></returns>
    private bool HasEmptySlot()
    {
        //現在の所持数がスロット数よりも少ないか
        return nowItemNum < itemMaxCount;
    }

    /// <summary>
    /// アイテムを取得してスロットに入れる
    /// </summary>
    private void GetItem(Item _getItem)
    {
        //nullがあったらそこに追加(一度アイテムを使用して空になったスロットがある場合はそこに入れる)
        if (SlotHaveNull()) 
        {
            //初めに見つけたnullのindexを取得
            int _emptyIndex = NullIndex();
            nowFullSlot[_emptyIndex] = itemDragController[_emptyIndex];
            //アイテムを持たせる
            nowFullSlot[_emptyIndex].HaveItem(_getItem);
        }
        //nullがなければ新たにリストの追加
        else
        {
            nowFullSlot.Add(itemDragController[nowItemNum]);
            nowFullSlot[nowItemNum].HaveItem(_getItem);
        }
        //数字で所持数を増やす
        nowItemNum++;
        nowItemNum = Mathf.Clamp(nowItemNum, 0, itemMaxCount);
    }

    /// <summary>
    /// nowFullSlotにnullが存在するか
    /// </summary>
    /// <returns></returns>
    private bool SlotHaveNull()
    {
        if (NullIndex() != -1) return true; //-1はnullを持っていない
        else return false;
    }

    /// <summary>
    /// nowFullSlotの中でどこがnullか
    /// </summary>
    /// <returns></returns>
    private int NullIndex()
    {
        return nowFullSlot.FindIndex(x => x == null);
    }
}
