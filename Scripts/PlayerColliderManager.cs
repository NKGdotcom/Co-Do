using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{
    [SerializeField] private PlayerUIManager playerUIManager;
    [SerializeField] private PlayerItemGetInf playerItemGetInf;
    private ItemColliderGetInformation itemColliderGetInfo;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Entrance"))//入口
        {
            playerUIManager.NotLeaveHouseComment();
        }
        else if (collision.gameObject.CompareTag("PieceOfGlass"))//ガラス片
        {
            playerUIManager.DangerGlassComment();
        }
        else if (collision.gameObject.CompareTag("Window"))//窓
        {
            if (!HouseState.Instance.IsBreakWindow) playerUIManager.NormalWindowComment();
            else playerUIManager.BreakWindowComment();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerUIManager.CommentHidden();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //アイテムを拾う
        if (other.gameObject.CompareTag("FallingItem"))
        {
            itemColliderGetInfo = other.gameObject.GetComponent<ItemColliderGetInformation>();
            if (PlayerItemGetInf.Instance.NowHaveItemNum >= PlayerItemGetInf.Instance.MaxHaveItemNum) return; //アイテム所持数が最大に達していないか

            other.gameObject.SetActive(false);
            PlayerItemGetInf.Instance.ColliderGetItem(itemColliderGetInfo.ItemType);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breaker"))//ブレーカー
        {
            if(!HouseState.Instance.IsFixBreaker) playerUIManager.TripBreakerComment();
            else playerUIManager.FixBreakerComment();
        }
        else if (collision.gameObject.CompareTag("Radio"))//ラジオ
        {
            if (!HouseState.Instance.IsFixRadio) playerUIManager.NotHearRadioComment();
            else playerUIManager.FixRadioComment();
        }
        else if (collision.gameObject.CompareTag("PieceOfGlass"))//ガラス片
        {
            playerUIManager.SafeGlassComment();
        }
        else if (collision.gameObject.CompareTag("Window"))//窓
        {
            playerUIManager.LeaveHouseComment();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerUIManager.CommentHidden();
    }
    
}
