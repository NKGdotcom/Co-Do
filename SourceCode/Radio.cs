using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    /// <summary>
    /// ���W�I�𒼂�
    /// </summary>
    public void FixRadio()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Battery); //�o�b�e���[�ŉ���
    }
}
