using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remmove : MonoBehaviour
{
    //アイテムピーチを持っている状態でクリックすると消える
    //・クリック判定
    //・アイテム持ってますよ判定

    [SerializeField] Items.Type item1,item2,item3,item4,item5,item6,item7,item8,item9,item10,item11,item12,item13;
    [SerializeField] PlayerMoves playerMove;
    



    private void Start()
    {
       
    }
   
    public void OnClickObj()
    {
        //特定のアイテムを持っているか
        bool clear1 = ItemBox.instance.TryRemove(item1);
        bool clear2 = ItemBox.instance.TryRemove(item2);
        bool clear3 = ItemBox.instance.TryRemove(item3);
        bool clear4 = ItemBox.instance.TryRemove(item4);
        bool clear5 = ItemBox.instance.TryRemove(item5);
        bool clear6 = ItemBox.instance.TryRemove(item6);
        bool clear7 = ItemBox.instance.TryRemove(item7);
        bool clear8 = ItemBox.instance.TryRemove(item8);
        bool clear9 = ItemBox.instance.TryRemove(item9);
        bool clear10 = ItemBox.instance.TryRemove(item10);
        bool clear11 = ItemBox.instance.TryRemove(item11);
        bool clear12 = ItemBox.instance.TryRemove(item12);
        bool clear13 = ItemBox.instance.TryRemove(item13);
        if (clear1||clear2||clear3||clear4|| clear5 || clear6 || clear7 || clear8 || clear9 || clear10 || clear11 || clear12 ||clear13)
        {  
            playerMove.itemNumber--;
        }
    }
}