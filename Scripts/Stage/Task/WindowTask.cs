using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 窓のタスクの管理
/// </summary>
public class WindowTask : BaseTask
{
    //コンポーネントの参照
    private BoxCollider2D windowCollider;

    private void Awake()
    {
        TryGetComponent<BoxCollider2D>(out windowCollider);
    }
    
    /// <summary>
    /// タスクを解決したら、窓のコリジョンを消す
    /// </summary>
    public override void SpecialExcuteTask()
    {
        windowCollider.isTrigger = true;
    }
}
