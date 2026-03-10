using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ガラス片専用のタスク
/// </summary>
public class GlassTask : BaseTask
{
    private BoxCollider2D glassCollider;
    private SpriteRenderer glassSprite;
    private const float WHITE_COLOR = 1.0f;
    private float spriteAlpah = 120;
    public override void SpecialExcuteTask()
    {
        //---コリジョン---
        TryGetComponent<BoxCollider2D>(out glassCollider);
        glassCollider.isTrigger = true;
        //---スプライト---
        TryGetComponent<SpriteRenderer>(out glassSprite);
        glassSprite.color = new Color(WHITE_COLOR, WHITE_COLOR,WHITE_COLOR, spriteAlpah);
    }
}
