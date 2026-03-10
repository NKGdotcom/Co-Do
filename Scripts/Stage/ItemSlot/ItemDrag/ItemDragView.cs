using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// UIの色の変更や座標移動を行う
/// </summary>
public class ItemDragView : MonoBehaviour
{
    //---座標移動に関するもの---
    private RectTransform rectTransform;
    private Vector2 defaultPos;
    //---画像変更に関するもの---
    private Image slotItem;
    private float clearValue = 0.5f;
    private const float WHITE_VALUE = 1.0f;

    private void Awake()
    {
        TryGetComponent<RectTransform>(out rectTransform);
        TryGetComponent<Image>(out slotItem);
    }

    public void ChangeImage(Item _changeItem)
    {
        slotItem.sprite = ItemGenerater.Instance.ItemImage(_changeItem);
    }

    //---ドラッグ開始関数---
    public void DragStart()
    {
        SaveSlotPos();
        ChangeItemPaleColor();
    }
    /// <summary>
    /// スロットの位置を取得
    /// </summary>
    private void SaveSlotPos()
    {
        defaultPos = rectTransform.anchoredPosition;
    }

    /// <summary>
    /// 画像の色を薄くする
    /// </summary>
    private void ChangeItemPaleColor()
    {
        slotItem.color = new Color(WHITE_VALUE, WHITE_VALUE, WHITE_VALUE, clearValue    );
        slotItem.raycastTarget = false;
    }

    // ---ドラッグ中関数---
    public void WhileDragging(PointerEventData eventData)
    {
        MoveItemUI(eventData);
    }
    /// <summary>
    /// 画像を座標移動
    /// </summary>
    private void MoveItemUI(PointerEventData eventData)
    {
        rectTransform.Translate(eventData.delta);
    }

    // ---ドラッグ終わった関数---
    public void DragEnd()
    {
        RestoreColor();
        ReturnSlotPos();
    }

    /// <summary>
    /// 色を元に戻す
    /// </summary>
    private void RestoreColor()
    {
        slotItem.color = Color.white;
    }
    /// <summary>
    /// 元の位置に戻す
    /// </summary>
    private void ReturnSlotPos()
    {
        rectTransform.anchoredPosition = defaultPos;
        slotItem.raycastTarget = true;
    }
}
