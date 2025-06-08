using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTrigger : MonoBehaviour
{
    [SerializeField] Radio radio;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            radio.volume.SetActive(true);
            if (radio.on)
            {
                radio.volume2.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            radio.volume.SetActive(false);
            if (radio.on)
            {
                radio.volume2.SetActive(false);
            }
        }
    }
}
