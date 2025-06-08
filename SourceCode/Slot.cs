using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   Items item;
    [SerializeField] Image image;
    [SerializeField] GameObject backgroundPanel;
   

    private void Awake()
    {
        //image = GetComponent<Image>();
    }
    private void Start()
    {
        backgroundPanel.SetActive(false);
    }

    public bool IsEmpty()
    {
        if(item == null)
        {
            return true;
        }
        return false;
    }
    public void SetItem(Items item)
    {
        this.item = item;
        UpdateImage(item);
    }
 

    public Items GetItem()
    {
        return item;
    }
 
    //�A�C�e�����󂯎������摜���C���x���g���ɕ\������
    void UpdateImage(Items item)
    {
        if (item==null)
        {
            image.sprite = null;
        }
        else
        {
            image.sprite = item.sprite;
        }
    }
    public bool OnSelected()
    {
        if(item == null)
        {
            return false;
        }
        backgroundPanel.SetActive(true);
        return true;
    }
    public void HideBGPanel()
    {
        backgroundPanel.SetActive(false);
    }
}
