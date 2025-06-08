using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    //Slot���󂢂Ă�����A���������Ă���

    [SerializeField] Slot[] slots;
    [SerializeField] Slot selectedSlot = null;
    [SerializeField] Slot selectedSlot2 = null;
    //�ǂ��ł����s�ł���
    public static ItemBox instance;
    public PlayerMoves player;
    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;
            slots = GetComponentsInChildren<Slot>();
        }
    }


    //Player���G�ꂽ��ItemBox�ɓ����
    public void SetItem(Items item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                break;
            }
           
        }
    }
    public void SetKeyItem(Items item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                break;
            }
            
        }
    }
    public void SetComItem1(Items item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                break;
            }
        }
    }

    public void OnselectSlot(int position)
    {
        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            foreach (Slot slot in slots)
            {
                slot.HideBGPanel();
            }
        }

        // �I�����ꂽ�X���b�g�̑I���p�l����\��
        if (slots[position].OnSelected())
        {
            if (selectedSlot != null&&Input.GetKey(KeyCode.LeftShift))
            {
                selectedSlot2 = slots[position];
            }
            else if (selectedSlot != null && Input.GetKey(KeyCode.RightShift))
            {
                selectedSlot2 = slots[position];
            }
            else { 
                selectedSlot = slots[position]; 
            }
            
        }
    }

    public bool TryUseItem(Items.Type type)
    {
        
        if (selectedSlot.GetItem().type == type)
        {
            selectedSlot.SetItem(null);
            selectedSlot.HideBGPanel();
            selectedSlot = null;
            return true;
        }
        return false;
    }
    public bool TryRemove(Items.Type type)
    {
        if (selectedSlot == null )
        {
            return false;
        }
        if (selectedSlot.GetItem().type == type)
        {
            selectedSlot.SetItem(null);
            selectedSlot.HideBGPanel();
            selectedSlot = null;
            Debug.Log("");
            return true;
        }
        
        return false;
    }
    public bool TryUseItem1(Items.Type type,Items.Type type2)
    {
        //�I���X���b�g�����邩�ǂ���
        if (selectedSlot == null ||selectedSlot2 == null)
        {
            return false;
        }
        if (selectedSlot.GetItem().type == type && selectedSlot2.GetItem().type == type2)
        {
            selectedSlot.SetItem(null);
            selectedSlot.HideBGPanel();
            selectedSlot2.SetItem(null);
            selectedSlot2.HideBGPanel();
            selectedSlot = null;
            selectedSlot2 = null;
            Debug.Log("");
            return true;
        }
        else if (selectedSlot.GetItem().type == type2 && selectedSlot2.GetItem().type == type)
        {
            selectedSlot.SetItem(null);
            selectedSlot.HideBGPanel();
            selectedSlot2.SetItem(null);
            selectedSlot2.HideBGPanel();
            selectedSlot = null;
            selectedSlot2 = null;
            Debug.Log("");
            return true;
        }
        return false;
    }
}
