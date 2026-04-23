using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテム紹介UIの管理を行うクラス
/// </summary>
public class ItemIntroduceView : MonoBehaviour
{
    [Header("アイテム紹介UI")]
    [Tooltip("UIをひとまとまりとしたオブジェクト")]
    [SerializeField] private GameObject itemIntroduceObject;
    [Tooltip("アイテムの画像を表示するImage")]
    [SerializeField] private Image itemImage;
    [Tooltip("アイテムの名前を表示するTextMeshProUGUI")]
    [SerializeField] private TextMeshProUGUI itemNameTMP;
    [Tooltip("アイテムの説明文を表示するTextMeshProUGUI")]
    [SerializeField] private TextMeshProUGUI itemIntroduceTMP;

    private void Awake()
    {
        if(itemIntroduceObject == null) { Debug.LogError("itemIntroduceObjectが参照されていません"); return; }
        if(itemImage == null) { Debug.LogError("itemImageが参照されていません"); return; }
        if(itemNameTMP == null) { Debug.LogError("itemNameTMPが参照されていません"); return; }
        if(itemIntroduceTMP == null) { Debug.LogError("itemIntroduceTMPが参照されていません"); return; }
    }

    /// <summary>
    /// アイテム紹介をUIで表示
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
        //UIを一つにまとめたオブジェクトを非表示にする
        itemIntroduceObject.SetActive(false);
    }
}