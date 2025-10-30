using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    /// <summary>
    /// ラジオを直す
    /// </summary>
    public void FixRadio()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Battery); //バッテリーで解決
    }
}
