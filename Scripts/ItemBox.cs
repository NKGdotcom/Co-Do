using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// スロットの中身を取得などの処理
/// </summary>
public class ItemBox : MonoBehaviour
{
    [Header("アイテムスロットの数")]
    [SerializeField] private ItemSlots[] slots;
    [Header("アイテムのデータ")]
    [SerializeField] private Items itemsData;
    //アイテム合体用
    [SerializeField] private ItemSlots oneSelectedSlot = null;
    [SerializeField] private ItemSlots moreSelectedSlot = null;

    public static ItemBox Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        slots = GetComponentsInChildren<ItemSlots>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// アイテムをスロットにセット
    /// </summary>
    /// <param name="_item"></param>
    public void SetItem(Items.ItemType _item)
    {
        foreach (ItemSlots slot in slots)
        {
            if (slot.IsEmpty()) //スロットが空の場合
            {
                slot.SetItem(_item);
                break;
            }
        }
    }
    /// <summary>
    /// アイテムを組み合わせてみる
    /// </summary>
    /// <param name="_oneItem"></param>
    /// <param name="_moreItem"></param>
    public void CombinationItem()
    {
        if (CanCombination(Items.ItemType.ItemTypes.PlasticBag, Items.ItemType.ItemTypes.Scissors))
        {
            SlotRemove(oneSelectedSlot);
            SlotRemove(moreSelectedSlot);
            PlayerItemGetInf.Instance.GetItemInformation(Items.ItemType.ItemTypes.RainCoat);
            PlayerItemGetInf.Instance.Combination();
        }
    }
    private bool CanCombination(Items.ItemType.ItemTypes _oneItem, Items.ItemType.ItemTypes _moreItem)
    {
        if((oneSelectedSlot.GetItem().itemTypes == _oneItem && moreSelectedSlot.GetItem().itemTypes == _moreItem)||
            oneSelectedSlot.GetItem().itemTypes == _moreItem && moreSelectedSlot.GetItem().itemTypes == _oneItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 一つアイテムを選択
    /// </summary>
    /// <param name="slotPos"></param>
    public void OnSelectSlot(int slotPos)
    {
        if(!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            foreach(ItemSlots slot in slots)　//全てのスロットの選択解除
            {
                slot.HideBackGroundPanel();
            }
            if (slots[slotPos].OnSelectedSlot())
            {
                oneSelectedSlot = slots[slotPos];
                moreSelectedSlot = null;
            }
        }
        else//複数アイテムを取得
        {
            if (slots[slotPos].OnSelectedSlot())
            {
                moreSelectedSlot = slots[slotPos];
            }
        }
    }
    /// <summary>
    /// アイテムが使えないかどうか
    /// </summary>
    /// <param name="_type"></param>
    /// <returns></returns>
    public bool TryUseItem(Items.ItemType.ItemTypes _type)
    {
        if (oneSelectedSlot != null && oneSelectedSlot.GetItem() != null)
        {
            if (oneSelectedSlot.GetItem().itemTypes == _type)
            {
                SlotRemove(oneSelectedSlot);
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// アイテムを消す
    /// </summary>
    public void SlotRemove(ItemSlots _itemSlot)
    {
        _itemSlot.SetItem(null);
        _itemSlot.HideBackGroundPanel();
        _itemSlot = null;
    }
    /// <summary>
    /// 外部から消去可能に
    /// </summary>
    public void OneSlotRemove()
    {
        SlotRemove(oneSelectedSlot);
    }
}
