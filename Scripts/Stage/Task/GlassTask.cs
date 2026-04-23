using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ガラス片のタスクの管理
/// </summary>
public class GlassTask : BaseTask
{
    //コンポーネントの参照
    private BoxCollider2D glassCollider;
    private SpriteRenderer glassSprite;

    //色を変更するパラメータ
    private const float WHITE_COLOR = 1.0f;
    private float spriteAlpah = 120;
    private void Awake()
    {
        TryGetComponent<BoxCollider2D>(out glassCollider);
        TryGetComponent<SpriteRenderer>(out glassSprite);
    }
    
    /// <summary>
    /// タスクを解決したら、ガラス片のコリジョンを消し、スプライトの色を薄くする
    /// </summary>
    public override void SpecialExcuteTask()
    {
        //コリジョンをTriggerにして、プレイヤーが通り抜けられるようにする
        glassCollider.isTrigger = true;

        //スプライトの色を薄くし、通れるようになったことを分かりやすくする
        glassSprite.color = new Color(WHITE_COLOR, WHITE_COLOR,WHITE_COLOR, spriteAlpah);
    }
}
