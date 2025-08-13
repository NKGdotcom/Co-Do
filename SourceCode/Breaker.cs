using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    /// <summary>
    /// ブレーカーを直す
    /// </summary>
   public void FixBreaker()
    {
        PlayerItemGetInf.Instance.TryUseItem(Items.ItemType.ItemTypes.SteppingStone); //踏み台で解決
    }
}
