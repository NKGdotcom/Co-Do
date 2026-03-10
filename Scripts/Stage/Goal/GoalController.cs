using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゴール判定用のセンサー
/// 全て解放するまではtriggerにならない
/// </summary>
public class GoalController : MonoBehaviour
{
    //---ゴールしたときなどの表示---
    [SerializeField] private GoalUIView goalUIView;
    //---ゴール判定用---
    private BoxCollider2D goalCol;
    //---フェード---
    [SerializeField] private Fade fade;

    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent<BoxCollider2D>(out goalCol);
        if(fade == null) { Debug.LogError("fadeが参照されていません。"); return; }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&GameState.Instance.IsResult())
        {
            fade.FadeOut(this.GetCancellationTokenOnDestroy()).Forget();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var _player))
        {
            goalUIView.NotFinishTaskAsync().Forget();
        }
    }

    /// <summary>
    /// 全てのタスクをクリア
    /// </summary>
    public void AllTaskSoution()
    {
        goalCol.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var _player))
        {
            goalUIView.ClearPerformance();
        }
    }

    /// <summary>
    /// タスクが終わらなかった場合
    /// </summary>
    public void FailedTask()
    {
        goalUIView.FailedPerformance();
    }
}
