using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// スロット表示の処理
/// </summary>
public class ItemSlots : MonoBehaviour
{
    private Items.ItemType item;
    [Header("アイテムを表示する画像")]
    [SerializeField] private Image itemImage;
    [Header("後ろの真っ黒な部分")]
    [SerializeField] private GameObject backGroundPanel;
    // Start is called before the first frame update
    void Start()
    {
        backGroundPanel.SetActive(false);

        item = null;
    }
    /// <summary>
    /// スロットがまだ埋まってないかどうか
    /// </summary>
    /// <returns>埋まってなかったらtrue,埋まっていたらfalse</returns>
    public bool IsEmpty()
    {
        if (item == null) return true;
        else return false;
    }
    /// <summary>
    /// アイテムを獲得(視覚的に獲得)
    /// </summary>
    /// <param name="item"></param>
    public void SetItem(Items.ItemType _item)
    {
        item= _item;
        UpdateImage(_item);
    }
    /// <summary>
    /// スロットの中にアイテムを入れる
    /// </summary>
    /// <param name="_item"></param>
    public void UpdateImage(Items.ItemType _item)
    {
        if (item == null || item.itemImage == null) itemImage.sprite = null;
        else itemImage.sprite = item.itemImage;
    }
    /// <summary>
    /// アイテムを獲得
    /// </summary>
    /// <returns></returns>
    public Items.ItemType GetItem()
    {
        if(item == null) return null;
        else return item;
    }
    /// <summary>
    /// スロットを選択
    /// </summary>
    /// <returns></returns>
    public bool OnSelectedSlot()
    {
        if(item == null) return false;

        backGroundPanel.SetActive(true);
        return true;
    }
    /// <summary>
    /// スロットの選択を解除
    /// </summary>
    public void HideBackGroundPanel()
    {
        backGroundPanel.SetActive(false);
    }
}
