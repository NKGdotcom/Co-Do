using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �X���b�g�̒��g���擾�Ȃǂ̏���
/// </summary>
public class ItemBox : MonoBehaviour
{
    [Header("�A�C�e���X���b�g�̐�")]
    [SerializeField] private ItemSlots[] slots;
    [Header("�A�C�e���̃f�[�^")]
    [SerializeField] private Items itemsData;
    //�A�C�e�����̗p
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
    /// �A�C�e�����X���b�g�ɃZ�b�g
    /// </summary>
    /// <param name="_item"></param>
    public void SetItem(Items.ItemType _item)
    {
        foreach (ItemSlots slot in slots)
        {
            if (slot.IsEmpty()) //�X���b�g����̏ꍇ
            {
                slot.SetItem(_item);
                break;
            }
        }
    }
    /// <summary>
    /// �A�C�e����g�ݍ��킹�Ă݂�
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
    /// ��A�C�e����I��
    /// </summary>
    /// <param name="slotPos"></param>
    public void OnSelectSlot(int slotPos)
    {
        if(!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            foreach(ItemSlots slot in slots)�@//�S�ẴX���b�g�̑I������
            {
                slot.HideBackGroundPanel();
            }
            if (slots[slotPos].OnSelectedSlot())
            {
                oneSelectedSlot = slots[slotPos];
                moreSelectedSlot = null;
            }
        }
        else//�����A�C�e�����擾
        {
            if (slots[slotPos].OnSelectedSlot())
            {
                moreSelectedSlot = slots[slotPos];
            }
        }
    }
    /// <summary>
    /// �A�C�e�����g���Ȃ����ǂ���
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
    /// �A�C�e��������
    /// </summary>
    public void SlotRemove(ItemSlots _itemSlot)
    {
        _itemSlot.SetItem(null);
        _itemSlot.HideBackGroundPanel();
        _itemSlot = null;
    }
    /// <summary>
    /// �O����������\��
    /// </summary>
    public void OneSlotRemove()
    {
        SlotRemove(oneSelectedSlot);
    }
}
