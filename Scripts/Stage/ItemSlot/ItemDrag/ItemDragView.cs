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
    //コンポーネント参照
    //座標移動に関するもの
    private RectTransform rectTransform;
    private Vector2 defaultPos;

    //画像変更に関する処理
    private Image slotItem;
    private float clearValue = 0.5f;
    private const float WHITE_VALUE = 1.0f;

    private void Awake()
    {
        TryGetComponent<RectTransform>(out rectTransform);
        TryGetComponent<Image>(out slotItem);
    }

    /// <summary>
    /// 画像をアイテムに合わせて変更
    /// </summary>
    /// <param name="_changeItem"></param>
    public void ChangeImage(Item _changeItem)
    {
        //取得したアイテムを画像に変換してスロットに表示
        slotItem.sprite = ItemGenerater.Instance.ItemImage(_changeItem);
    }

    /// <summary>
    /// ドラッグを開始したら位置を保存し、画像の色を薄くする
    /// </summary>
    public void DragStart()
    {
        SaveSlotPos();
        ChangeItemPaleColor();
    }

    /// <summary>
    /// ドラッグ中、画像を座標移動
    /// </summary>
    /// <param name="eventData"></param>
    public void WhileDragging(PointerEventData eventData)
    {
        MoveItemUI(eventData);
    }

    /// <summary>
    /// ドラッグを終えたら、保存した位置に戻し、画像の色を元に戻す
    /// </summary>
    public void DragEnd()
    {
        ReturnSlotPos();
        RestoreColor();
    }

    /// <summary>
    /// 画像の色を薄くする
    /// </summary>
    private void ChangeItemPaleColor()
    {
        slotItem.color = new Color(WHITE_VALUE, WHITE_VALUE, WHITE_VALUE, clearValue    );
        slotItem.raycastTarget = false;
    }

    /// <summary>
    /// 画像を座標移動
    /// </summary>
    private void MoveItemUI(PointerEventData eventData)
    {
        rectTransform.Translate(eventData.delta);
    }

    /// <summary>
    /// スロットの位置を取得し保存
    /// </summary>
    private void SaveSlotPos()
    {
        defaultPos = rectTransform.anchoredPosition;
    }

    /// <summary>
    /// 画像の色を元に戻す
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
