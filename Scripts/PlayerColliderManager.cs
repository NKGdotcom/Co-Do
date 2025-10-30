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
        if (collision.gameObject.CompareTag("Entrance"))//����
        {
            playerUIManager.NotLeaveHouseComment();
        }
        else if (collision.gameObject.CompareTag("PieceOfGlass"))//�K���X��
        {
            playerUIManager.DangerGlassComment();
        }
        else if (collision.gameObject.CompareTag("Window"))//��
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
        //�A�C�e�����E��
        if (other.gameObject.CompareTag("FallingItem"))
        {
            itemColliderGetInfo = other.gameObject.GetComponent<ItemColliderGetInformation>();
            if (PlayerItemGetInf.Instance.NowHaveItemNum >= PlayerItemGetInf.Instance.MaxHaveItemNum) return; //�A�C�e�����������ő�ɒB���Ă��Ȃ���

            other.gameObject.SetActive(false);
            PlayerItemGetInf.Instance.ColliderGetItem(itemColliderGetInfo.ItemType);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breaker"))//�u���[�J�[
        {
            if(!HouseState.Instance.IsFixBreaker) playerUIManager.TripBreakerComment();
            else playerUIManager.FixBreakerComment();
        }
        else if (collision.gameObject.CompareTag("Radio"))//���W�I
        {
            if (!HouseState.Instance.IsFixRadio) playerUIManager.NotHearRadioComment();
            else playerUIManager.FixRadioComment();
        }
        else if (collision.gameObject.CompareTag("PieceOfGlass"))//�K���X��
        {
            playerUIManager.SafeGlassComment();
        }
        else if (collision.gameObject.CompareTag("Window"))//��
        {
            playerUIManager.LeaveHouseComment();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerUIManager.CommentHidden();
    }
    
}
