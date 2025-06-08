using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    public GameObject volume,volume2;
    //アイテムピーチを持っている状態でクリックすると消える
    //・クリック判定
    //・アイテム持ってますよ判定

    [SerializeField] Items.Type clearItem;
    [SerializeField] PlayerMoves playerMove;
    public GameObject star;
    public AudioClip sound1;
    AudioSource audioSource1;
    public bool on;

    private void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
    }
   
    public void OnClickObj()
    {
        //特定のアイテムを持っているか
        bool clear = ItemBox.instance.TryUseItem(clearItem);
        if (clear)
        {
            audioSource1.PlayOneShot(sound1);
            playerMove.itemNumber--;
            playerMove.spriteRenderer.sprite = playerMove.laugh;
            star.SetActive(true);
            Invoke("BackFace", 1f);
            on = true;
        }
    }

    public void BackFace()
    {
        star.SetActive(false);
        playerMove.spriteRenderer.sprite = playerMove.normal;

    }

}
