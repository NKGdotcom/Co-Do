using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOfGlass : MonoBehaviour
{
    /// <summary>
    /// �K���X�Ђ����S�ɒʂ�
    /// </summary>
    public void SafeGlass()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Slippers); //�X���b�p�ŉ���
    }
}
