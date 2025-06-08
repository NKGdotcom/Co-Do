using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    [SerializeField] Items.Type breakItem;
    [SerializeField] PlayerMoves playerMove;
    public GameObject star;
    public AudioClip sound1;
    AudioSource audioSource1;
    public bool Ok;
    public GameObject comment, comment2;

    private void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
    }
    public void OnClickObj()
    {
        //ì¡íËÇÃÉAÉCÉeÉÄÇéùÇ¡ÇƒÇ¢ÇÈÇ©
        bool clear = ItemBox.instance.TryUseItem(breakItem);
        if (clear)
        {
            audioSource1.PlayOneShot(sound1);
            playerMove.itemNumber--;
            playerMove.spriteRenderer.sprite = playerMove.laugh;
            star.SetActive(true);
            Invoke("BackFace", 1f);
            Ok = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            comment.SetActive(true);
            if (Ok)
            {
                comment2.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            comment.SetActive(false);
            if (Ok)
            {
                comment2.SetActive(false);
            }
        }
    }
    public void BackFace()
    {
        star.SetActive(false);
        playerMove.spriteRenderer.sprite = playerMove.normal;

    }
}
