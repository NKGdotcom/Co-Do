using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColliderGetInformation : MonoBehaviour
{
    public Items.ItemType.ItemTypes ItemType { get => itemType; private set => itemType = value; }

    [Header("�G�ꂽ�Ƃ��ɏ����擾����p")]
    [SerializeField] private Items.ItemType.ItemTypes itemType;
}
