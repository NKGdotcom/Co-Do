using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIntroduceView : MonoBehaviour
{
    [SerializeField] private GameObject itemIntroduceObject;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameTMP;
    [SerializeField] private TextMeshProUGUI itemIntroduceTMP;

    private void Awake()
    {
        if(itemIntroduceObject == null) { Debug.LogError("itemIntroduceObjectが参照されていません"); return; }
        if(itemImage == null) { Debug.LogError("itemImageが参照されていません"); return; }
        if(itemNameTMP == null) { Debug.LogError("itemNameTMPが参照されていません"); return; }
        if(itemIntroduceTMP == null) { Debug.LogError("itemIntroduceTMPが参照されていません"); return; }
    }

    /// <summary>
    /// アイテム紹介を表示
    /// </summary>
    /// <param name="_item"></param>
    public void ShowIntroduceUI(Item _item)
    {
        itemIntroduceObject.SetActive(true);
        itemImage.sprite = ItemGenerater.Instance.ItemImage(_item);
        itemNameTMP.text = ItemGenerater.Instance.ItemName(_item);
        itemIntroduceTMP.text = ItemGenerater.Instance.ItemIntroduce(_item);
    }

    /// <summary>
    /// アイテム紹介UIを非表示
    /// </summary>
    public void HideIntroduceUI()
    {
        itemIntroduceObject.SetActive(false);
    }
}
