using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainTask : BaseTask
{
    private BoxCollider2D rainCollider;
    private SpriteRenderer rainSprite;
    private const float WHITE_COLOR = 1.0f;
    private float spriteAlpah = 120;
    public override void SpecialExcuteTask()
    {
        //---コリジョン---
        TryGetComponent<BoxCollider2D>(out rainCollider);
        rainCollider.isTrigger = true;
        //---スプライト---
        TryGetComponent<SpriteRenderer>(out rainSprite);
        rainSprite.enabled = false;
    }
}
