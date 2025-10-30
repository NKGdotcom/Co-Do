using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private bool isWindowBreak;
    public bool IsWindowBreak { get => isWindowBreak; }
    /// <summary>
    /// ‘‹‚ğ‰ó‚·
    /// </summary>
    public void BreakWindow()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Hammer); //ƒnƒ“ƒ}[‚Å‰ó‚·
        isWindowBreak = true;
    }
    /// <summary>
    /// ‰J‚ğ”ğ‚¯‚é
    /// </summary>
    public void AvoidTheRain()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.RainCoat);
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Blanket);
    }
}
