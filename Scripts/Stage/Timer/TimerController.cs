using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 制限時間を設定
/// </summary>
public class TimerController : MonoBehaviour
{
    //---制限時間が経った際の処理---
    [SerializeField] private GoalController goalController;
    //---時間制限の処理---
    [SerializeField] private TimeLimit timeLimit;
    [SerializeField] private TimerView timerView;

    void Awake()
    {
        if(timeLimit == null) { Debug.LogError("timeLimitが参照されていません。"); return; }
        if (timerView == null) { Debug.LogError("timerViewが参照されていません。"); return; }

        TimeSet();
        StartGameSequence().Forget();
        timeLimit.OnTimeUp += TimeUp;
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
        timerView.ShowReadyTMP();
        await timeLimit.ReadyAsync(this.GetCancellationTokenOnDestroy());
        timerView.ShowGoTMP();
        await timeLimit.GoAsync(this.GetCancellationTokenOnDestroy());
        GameState.Instance.SetState(State.GAME);
        timerView.HideAllTMP();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.IsGame() || GameState.Instance.IsDrag())
        {
            TimeSet();
        }
    }

    /// <summary>
    /// 終了
    /// </summary>
    private void TimeUp()
    {
        GameState.Instance.SetState(State.RESULT);
        goalController.FailedTask();
    }

    private void OnDestroy()
    {
        timeLimit.OnTimeUp -= TimeUp;
    }
}
