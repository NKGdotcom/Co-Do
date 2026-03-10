using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemController : MonoBehaviour, IItem
{
    public Item MyItem { get => myItem; }
    [SerializeField] private Item myItem;
}
