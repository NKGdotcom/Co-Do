using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム紹介の動作を行うクラス
/// </summary>
public class ItemIntroduceController : MonoBehaviour
{
    [Header("コンポーネント参照")]
    [Tooltip("アイテムの紹介をUIで表示する")]
    [SerializeField] private ItemIntroduceView itemIntroduceView;
    private Item introduceItem;

    private void Update()
    {
        //アイテム紹介中に画面をタップしたらアイテム紹介UIを消す
        if(GameState.Instance.IsItemIntroduce() && Input.GetMouseButtonDown(0))
        {
            itemIntroduceView.HideIntroduceUI();
            GameState.Instance.SetState(State.GAME);
        }
    }

    /// <summary>
    /// 紹介したいアイテムの情報を取得
    /// </summary>
    /// <param name="_item"></param>
    public void GetItemInfo(Item _item)
    {
        introduceItem = _item;
        ItemIntroduce();
    } 

    /// <summary>
    /// アイテム紹介
    /// </summary>
    private void ItemIntroduce()
    {
        GameState.Instance.SetState(State.ITEM);
        //UIにアイテムを反映させて表示
        itemIntroduceView.ShowIntroduceUI(introduceItem);
    }
}
