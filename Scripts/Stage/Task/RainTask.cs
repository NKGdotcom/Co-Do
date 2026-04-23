using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 雨のタスクの管理
/// </summary>
public class RainTask : BaseTask
{
    //コンポーネント参照
    private BoxCollider2D rainCollider;
    private SpriteRenderer rainSprite;

    //色を変更するパラメータ
    private const float WHITE_COLOR = 1.0f;
    private float spriteAlpah = 120;

    private void Awake()
    {
        TryGetComponent<BoxCollider2D>(out rainCollider);
        TryGetComponent<SpriteRenderer>(out rainSprite);
    }

    /// <summary>
    /// タスクを解決したら、雨のコリジョンを消し、スプライトの色を薄くする
    /// </summary>
    public override void SpecialExcuteTask()
    {
        //コリジョンをTriggerにして、プレイヤーが通り抜けられるようにする
        rainCollider.isTrigger = true;

        //スプライトの色を消し、通れるようになったことを分かりやすくする
        rainSprite.color = new Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR, spriteAlpah);
    }
}
