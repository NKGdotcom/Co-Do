using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// アイテムのドラッグ処理の管理
/// </summary>
public class ItemDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    //---アイテムスロットUIの変化---
    [SerializeField] private ItemDragView itemDragView;
    private CanvasGroup canvasGroup;
    //---アイテムの紹介---
    [SerializeField] private ItemIntroduceController itemIntroduceController;

    private bool isHaveItem = false; //アイテムを持っているかどうか
    public Item CurrentItem { get; private set; }
    public event Action<ItemDragController> OnUseItem;
    private void Awake()
    {
        if(itemDragView == null) { Debug.LogError("itemDragViewが参照されていません"); return; }
        canvasGroup = GetComponent<CanvasGroup>();
    }
    /// <summary>
    /// アイテムをゲット
    /// </summary>
    public void HaveItem(Item _getItem)
    {
        isHaveItem = true;
        CurrentItem = _getItem;
        itemDragView.ChangeImage(_getItem);
    }
    /// <summary>
    /// アイテムを使うor捨てる
    /// </summary>
    public void UseTrashItem()
    {
        isHaveItem = false;
        CurrentItem = Item.NONE;
        itemDragView.ChangeImage(Item.NONE);
        OnUseItem?.Invoke(this);
    }
    /// <summary>
    /// ドラッグ開始
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isHaveItem) return;

        GameState.Instance.SetState(State.DRAG);
        canvasGroup.blocksRaycasts = false;
        itemDragView.DragStart();
    }

    /// <summary>
    /// ドラッグ中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        itemDragView.WhileDragging(eventData);
    }
    /// <summary>
    /// ドラッグ終了
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        GameState.Instance.SetState(State.GAME);
        canvasGroup.blocksRaycasts = true;
        itemDragView.DragEnd();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!isHaveItem) return;

        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent<ItemDragController>(out var draggedItem))
        {
            if (draggedItem == this) return;

            Item _itemA = draggedItem.CurrentItem;
            Item _itemB = this.CurrentItem;

            Item resultItem = CheckCombination(_itemA, _itemB);
            if (resultItem != Item.NONE)
            {
                draggedItem.UseTrashItem();
                this.HaveItem(resultItem);
            }
        }
    }
    /// <summary>
    /// 組み合わせを判定する処理
    /// </summary>
    private Item CheckCombination(Item item1, Item item2)
    {
        if (((item1 == Item.PLASTICBAG && item2 == Item.SCISSORS))
            ||(item1 == Item.SCISSORS && item2 == Item.PLASTICBAG))
        {
            return Item.RAINCOAT;
        }

        return Item.NONE;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(CurrentItem == Item.NONE) return;

        itemIntroduceController.GetItemInfo(CurrentItem);
    }
}
