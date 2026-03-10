using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIntroduceController : MonoBehaviour
{
    [SerializeField] private ItemIntroduceView itemIntroduceView;
    private Item introduceItem;

    private void Update()
    {
        if(GameState.Instance.IsItemIntroduce() && Input.GetMouseButtonDown(0))
        {
            itemIntroduceView.HideIntroduceUI();
            GameState.Instance.SetState(State.GAME);
        }
    }
    /// <summary>
    /// アイテム情報を取得
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
        itemIntroduceView.ShowIntroduceUI(introduceItem);
    }
}
