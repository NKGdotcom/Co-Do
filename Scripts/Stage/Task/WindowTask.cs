using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 窓専用のタスク
/// </summary>
public class WindowTask : BaseTask
{
    private BoxCollider2D windowCollider;
    public override void SpecialExcuteTask()
    {
        //---コリジョン---
        TryGetComponent<BoxCollider2D>(out windowCollider);
        windowCollider.isTrigger = true;
    }
}
