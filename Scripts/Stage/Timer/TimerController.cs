using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 制限時間の計算処理をつなぐ
/// </summary>
public class TimerController : MonoBehaviour
{
    [Header("コンポーネント参照")]
    [Tooltip("ゲームのリザルト処理を行うコンポーネント")]
    [SerializeField] private ResultUIView resultUIView;
    [Tooltip("制限時間の計算")]
    [SerializeField] private TimeLimit timeLimit;
    [Tooltip("制限時間の表示を行うコンポーネント")]
    [SerializeField] private TimerView timerView;

    void Awake()
    {
        if(resultUIView == null) { Debug.LogError("resultUIViewが参照されていません。"); return; }
        if (timeLimit == null) { Debug.LogError("timeLimitが参照されていません。"); return; }
        if (timerView == null) { Debug.LogError("timerViewが参照されていません。"); return; }

        //時間制限の表示や計算の初期化
        TimeSet();
        StartGameSequence().Forget();
        timeLimit.OnTimeUp += TimeUp;
    }

    void Update()
    {
        if (GameState.Instance.IsGame() || GameState.Instance.IsDrag())
        {
            TimeSet();
        }
    }

    /// <summary>
    /// 時間表示や計算を行う
    /// </summary>
    private void TimeSet()
    {
        timeLimit.TimeLimitCalculation();
        timerView.TimerDisplay(timeLimit.Timer);
    }

    /// <summary>
    /// よーいスタートから始まるまでの処理
    /// </summary>
    /// <returns></returns>
    private async UniTaskVoid StartGameSequence()
    {
        //準備テキストの表示
        timerView.ShowReadyTMP();
        //よーいの表示待ち時間
        await timeLimit.ReadyAsync(this.GetCancellationTokenOnDestroy());
        //スタートテキストの表示
        timerView.ShowGoTMP();
        //スタート！の表示待ち時間
        await timeLimit.GoAsync(this.GetCancellationTokenOnDestroy());
        //ゲーム開始
        GameState.Instance.SetState(State.GAME);
        timerView.HideAllTMP();
    }

    /// <summary>
    /// 時間切れ
    /// </summary>
    private void TimeUp()
    {
        GameState.Instance.SetState(State.RESULT);
        resultUIView.FailedPerformance();
    }

    private void OnDestroy()
    {
        timeLimit.OnTimeUp -= TimeUp;
    }
}
