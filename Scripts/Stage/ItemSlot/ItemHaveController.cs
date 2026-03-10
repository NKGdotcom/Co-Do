using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// アイテムの手持ちを管理
/// </summary>
public class ItemHaveController : MonoBehaviour
{
    //---アイテムスロット数に関すること---
    [SerializeField] private List<ItemDragController> itemDragController;
    private int itemMaxCount = 0;
    //---現在登録しているアイテム数について---
    private List<ItemDragController> nowFullSlot = new List<ItemDragController>(); //現在どのくらいアイテムを持っているかのリスト
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

    // ---アイテム使用について---
    /// <summary>
    /// アイテムを使ったと判定したら
    /// </summary>
    private void UseItem(ItemDragController _usedSlot)
    {
        nowItemNum--;
        nowItemNum = Mathf.Clamp(nowItemNum, 0, itemMaxCount);

        int _index = nowFullSlot.IndexOf(_usedSlot);
        if (_index != -1)
        {
            nowFullSlot[_index] = null;
        }
    }

    // ---アイテム取得について---
    /// <summary>
    /// アイテムを取得予定
    /// </summary>
    public void GetItemReservation(Item _colItem)
    {
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
        return nowItemNum < itemMaxCount;
    }

    /// <summary>
    /// アイテムを取得
    /// </summary>
    private void GetItem(Item _getItem)
    {
        if (SlotHaveNull()) //nullがあったらそこに追加
        {
            int _emptyIndex = NullIndex();
            nowFullSlot[_emptyIndex] = itemDragController[_emptyIndex];
            nowFullSlot[_emptyIndex].HaveItem(_getItem);
        }
        else //nullがなければ新たにリストの追加
        {
            nowFullSlot.Add(itemDragController[nowItemNum]);
            nowFullSlot[nowItemNum].HaveItem(_getItem);
        }
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

   
    public void OnDestroy()
    {
        foreach (var itemSlot in itemDragController)
        {
            itemSlot.OnUseItem -= UseItem;
        }
    }
}
