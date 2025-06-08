using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


public class SlotsSelect : MonoBehaviour
{
    //コンビネーション
    [SerializeField] Items.Type item1,item2;
    [SerializeField] PlayerMoves playerMove;
    [SerializeField] ItemBox itemBox;
    [SerializeField] Items item;
    [SerializeField] Items.Type comItem1;
    public bool com1,com2;


  

    public void Update()
    {
        if (playerMove.itemNumber<=5)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                Combi();
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Slipper")
        {
            com1 = true;
        }
        if (collision.name == "Toilet")
        {
            com2 = true;
        }
    }

    public void Combi()
    {
        
            bool clear = ItemBox.instance.TryUseItem1(item1, item2);
            if (clear)
            {
                    playerMove.itemNumber--;
                    item = ItemGenerater.instance.Spawn(comItem1);
                    itemBox.SetComItem1(item);
                    com1 = false;
                    com2 = false;
            }
        
    }
}

