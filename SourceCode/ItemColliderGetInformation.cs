using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColliderGetInformation : MonoBehaviour
{
    public Items.ItemType.ItemTypes ItemType { get => itemType; private set => itemType = value; }

    [Header("G‚ê‚½‚Æ‚«‚Éî•ñ‚ğæ“¾‚·‚é—p")]
    [SerializeField] private Items.ItemType.ItemTypes itemType;
}
