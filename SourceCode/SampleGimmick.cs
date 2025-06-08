using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmick : MonoBehaviour
{
    //アイテムピーチを持っている状態でクリックすると消える
    //・クリック判定
    //・アイテム持ってますよ判定

    [SerializeField] Items.Type clearItem;
    [SerializeField] PlayerMoves playerMove;
    private BoxCollider2D boxCol;
    public GameObject star;
    SpriteRenderer sr;
    float transparency = 0.5f;
    public AudioClip sound1;
    AudioSource audioSource1;
    public GameObject comment;


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
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            comment.SetActive(false);
        }
    }
    public void OnClickObj()
    {
        //特定のアイテムを持っているか
        bool clear = ItemBox.instance.TryUseItem(clearItem);
        if (clear)
        {
            audioSource1.PlayOneShot(sound1);
            playerMove.itemNumber--;
            boxCol = gameObject.GetComponent<BoxCollider2D>();
            boxCol.enabled = false;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparency);
            playerMove.spriteRenderer.sprite = playerMove.laugh;
            star.SetActive(true);
            Invoke("BackFace", 1f);
        }
    }

    public void BackFace()
    {
        star.SetActive(false);
        playerMove.spriteRenderer.sprite = playerMove.normal;

    }
    
}
