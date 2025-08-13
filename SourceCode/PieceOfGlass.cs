using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOfGlass : MonoBehaviour
{
    /// <summary>
    /// ガラス片を安全に通る
    /// </summary>
    public void SafeGlass()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.Slippers); //スリッパで解決
    }
}
