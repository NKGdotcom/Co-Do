using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private bool isWindowBreak;
    public bool IsWindowBreak { get => isWindowBreak; }
    /// <summary>
    /// ������
    /// </summary>
    public void BreakWindow()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Hammer); //�n���}�[�ŉ�
        isWindowBreak = true;
    }
    /// <summary>
    /// �J�������
    /// </summary>
    public void AvoidTheRain()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.RainCoat);
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Blanket);
    }
}
