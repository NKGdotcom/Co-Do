using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゴールの衝突処理のスクリプト
/// </summary>
public class GoalController : MonoBehaviour
{
    [Header("コンポーネントの参照")]
    [Tooltip("ゴールの演出を表示するUI")]
    [SerializeField] private ResultUIView goalUIView;
    [Tooltip("フェードアウトをして遷移を行う")]
    [SerializeField] private Fade fade;
    
    //ゴール判定用
    private BoxCollider2D goalCol;

    void Awake()
    {
        if(goalUIView == null) { Debug.LogError("goalUIViewが参照されていません。"); return; }
        if (fade == null) { Debug.LogError("fadeが参照されていません。"); return; }
    }

    private void Update()
    {
        //リザルト画面が表示しているときにクリックしたらフェードアウトして遷移
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var _player))
        {
            goalUIView.ClearPerformance();
        }
    }

    /// <summary>
    /// 全てのタスクをクリア
    /// </summary>
    public void AllTaskSoution()
    {
        goalCol.isTrigger = true;
    }
}
