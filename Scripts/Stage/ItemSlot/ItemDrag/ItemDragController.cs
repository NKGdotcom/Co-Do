using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// スロットUIのドラッグ処理
/// </summary>
public class ItemDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    //---アイテムスロットUIの変化---
    [Header("コンポーネント参照")]
    [Tooltip("アイテムドラッグの見た目の変化を表示")]
    [SerializeField] private ItemDragView itemDragView;
    [Tooltip("アイテム紹介の表示をする処理の管理")]
    [SerializeField] private ItemIntroduceController itemIntroduceController;
    
    //現在手元にあるアイテム
    public Item CurrentItem { get; private set; }
    //アイテムを使ったかどうか
    public event Action<ItemDragController> OnUseItem;

    private CanvasGroup canvasGroup;
    private bool isHaveItem = false; 

    private void Awake()
    {
        if(itemDragView == null) { Debug.LogError("itemDragViewが参照されていません"); return; }
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// ドラッグ開始
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //アイテムを今手元に持っていなければドラッグできない
        if (!isHaveItem) return;

        //ドラッグ中はゲームの状態をドラッグ中にする
        GameState.Instance.SetState(State.DRAG);

        //ドラッグ中はアイテムスロットUIがrayを受け取らないようにする
        canvasGroup.blocksRaycasts = false;

        //アイテムドラッグ開始
        itemDragView.DragStart();
    }

    /// <summary>
    /// ドラッグ中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //ドラッグ中に残されたアイテムの色を薄くする
        itemDragView.WhileDragging(eventData);
    }

    /// <summary>
    /// ドラッグ終了
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        //ドラッグ終了後はゲームの状態をゲーム中にする
        GameState.Instance.SetState(State.GAME);
        //ドラッグ終了後はアイテムスロットUIがrayを受け取るようにする
        canvasGroup.blocksRaycasts = true;
        itemDragView.DragEnd();
    }

    /// <summary>
    /// ドロップしたときの処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        if (!isHaveItem) return;

        //ドロップされた先にアイテムがあれば組み合わせの判定をする
        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent<ItemDragController>(out var draggedItem))
        {
            if (draggedItem == this) return;

            //ドロップされた先とドロップしたアイテムの組み合わせを判定する
            Item _itemA = draggedItem.CurrentItem;
            Item _itemB = this.CurrentItem;

            //組み合わせの結果を受け取る
            Item resultItem = CheckCombination(_itemA, _itemB);
            //組み合わせの結果がNoneでなければ、アイテムの合体
            if (resultItem != Item.NONE)
            {
                //ドロップされた先とドロップしたアイテムを消去し、新しいアイテムをゲットする
                draggedItem.UseTrashItem();
                this.HaveItem(resultItem);
            }
        }
    }

    /// <summary>
    /// その場でクリックしたらアイテムの情報を取得し、UIの表示をする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CurrentItem == Item.NONE) return;

        itemIntroduceController.GetItemInfo(CurrentItem);
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
        //アイテムを使うor捨てるとき、アイテムスロットUIの見た目を変更
        isHaveItem = false;
        CurrentItem = Item.NONE;
        itemDragView.ChangeImage(Item.NONE);
        //イベントで知らせる
        OnUseItem?.Invoke(this);
    }
    
    /// <summary>
    /// 特定のアイテムで同士であれば、合体新しいアイテムを返す
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
}
