using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PickUp : MonoBehaviour
{
     [SerializeField] Items.Type itemType;
     Items item;
     [SerializeField] PlayerMoves playerMove;
     [SerializeField] Slot slots;
  

    private void Start()
    {
        //itemType‚É‰‚¶‚Äitem‚ğ¶¬‚·‚é
        item = ItemGenerater.instance.Spawn(itemType);
        playerMove = GameObject.Find("player").GetComponent<PlayerMoves>();
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (playerMove.itemNumber <= 4)
        {
            if (other.CompareTag("Player"))
            {

                ItemBox.instance.SetItem(item);
                this.gameObject.SetActive(false);
            }
        }
    }
}
