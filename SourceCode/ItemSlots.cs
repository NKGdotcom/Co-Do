using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// �X���b�g�\���̏���
/// </summary>
public class ItemSlots : MonoBehaviour
{
    private Items.ItemType item;
    [Header("�A�C�e����\������摜")]
    [SerializeField] private Image itemImage;
    [Header("���̐^�����ȕ���")]
    [SerializeField] private GameObject backGroundPanel;
    // Start is called before the first frame update
    void Start()
    {
        backGroundPanel.SetActive(false);

        item = null;
    }
    /// <summary>
    /// �X���b�g���܂����܂��ĂȂ����ǂ���
    /// </summary>
    /// <returns>���܂��ĂȂ�������true,���܂��Ă�����false</returns>
    public bool IsEmpty()
    {
        if (item == null) return true;
        else return false;
    }
    /// <summary>
    /// �A�C�e�����l��(���o�I�Ɋl��)
    /// </summary>
    /// <param name="item"></param>
    public void SetItem(Items.ItemType _item)
    {
        item= _item;
        UpdateImage(_item);
    }
    /// <summary>
    /// �X���b�g�̒��ɃA�C�e��������
    /// </summary>
    /// <param name="_item"></param>
    public void UpdateImage(Items.ItemType _item)
    {
        if (item == null || item.itemImage == null) itemImage.sprite = null;
        else itemImage.sprite = item.itemImage;
    }
    /// <summary>
    /// �A�C�e�����l��
    /// </summary>
    /// <returns></returns>
    public Items.ItemType GetItem()
    {
        if(item == null) return null;
        else return item;
    }
    /// <summary>
    /// �X���b�g��I��
    /// </summary>
    /// <returns></returns>
    public bool OnSelectedSlot()
    {
        if(item == null) return false;

        backGroundPanel.SetActive(true);
        return true;
    }
    /// <summary>
    /// �X���b�g�̑I��������
    /// </summary>
    public void HideBackGroundPanel()
    {
        backGroundPanel.SetActive(false);
    }
}
