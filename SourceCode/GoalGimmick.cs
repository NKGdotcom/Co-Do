using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGimmick : MonoBehaviour
{
    //アイテムピーチを持っている状態でクリックすると消える
    //・クリック判定
    //・アイテム持ってますよ判定

    [SerializeField] Items.Type breakItem,clearItem,clearItem2;
    [SerializeField] PlayerMoves playerMove;
    public GameObject star;
    SpriteRenderer sr;
    public bool Break;
    public bool finish;
    float transparency = 0.5f;
    public AudioClip sound1;
    AudioSource audioSource1;
    public GameObject comment,comment2;


    private void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            comment.SetActive(true);
            if (Break)
            {
                comment2.SetActive(true);
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            comment.SetActive(false);
            if (Break)
            {
                comment2.SetActive(false);
            }
        }
    }
    public void OnClickObj()
    {
        //特定のアイテムを持っているか
        bool clear = ItemBox.instance.TryUseItem(breakItem);
        if (clear)
        {
            audioSource1.PlayOneShot(sound1);
            playerMove.itemNumber--;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparency);
            Break = true;
            playerMove.spriteRenderer.sprite = playerMove.laugh;
            star.SetActive(true);
            Invoke("BackFace", 1f);
        }
    }
    public void OnClickObj2()
    {
        //特定のアイテムを持っているか
        bool clear1 = ItemBox.instance.TryUseItem(clearItem);
        bool clear2 = ItemBox.instance.TryUseItem(clearItem2);
        if (clear1||clear2)
        {
            audioSource1.PlayOneShot(sound1);
            playerMove.itemNumber--;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
            finish = true;
            playerMove.spriteRenderer.sprite = playerMove.laugh;
            star.SetActive(true);
            Invoke("BackFace2", 1f);
        }
    }

    public void BackFace()
    {
        star.SetActive(false);
        playerMove.spriteRenderer.sprite = playerMove.normal;
        
    }
    public void BackFace2()
    {
        star.SetActive(false);
        playerMove.spriteRenderer.sprite = playerMove.normal;
        this.gameObject.SetActive(false);
    }
}
