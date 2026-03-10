using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotHave : MonoBehaviour
{
    public Item NowItem { get; private set; }

    public void GetItem(Item _nowItem)
    {
        NowItem = _nowItem;
    }
}
