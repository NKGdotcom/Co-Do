using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    /// <summary>
    /// �u���[�J�[�𒼂�
    /// </summary>
   public void FixBreaker()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.SteppingStone); //���ݑ�ŉ���
    }
}
