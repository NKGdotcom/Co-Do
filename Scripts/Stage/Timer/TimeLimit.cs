using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimeLimit : MonoBehaviour
{
    //---制限時間用---
    [Header("「よーい」表示時間")]
    [SerializeField] private float readyWaitTime = 2.0f;
    [Header("「スタート！」表示時間")]
    [SerializeField] private float goWaitTime = 2.0f;
    [Header("制限時間")]
    [SerializeField] private float stageTime = 180f;
    public float Timer { get => timer; }
    private float timer = 0;
    //---時間終了したとき---
    private bool isTimeUp;
    public event Action OnTimeUp;

    private void Awake()
    {
        timer = stageTime;
    }

    /// <summary>
    /// よーいの待ち時間
    /// </summary>
    /// <returns></returns>
    public async UniTask ReadyAsync(CancellationToken _token)
    {
        _token = this.GetCancellationTokenOnDestroy();
        await UniTask.Delay(System.TimeSpan.FromSeconds(readyWaitTime), cancellationToken: _token);
    }

    /// <summary>
    /// スタート！の待ち時間
    /// </summary>
    /// <returns></returns>
    public async UniTask GoAsync(CancellationToken _token)
    {
        _token = this.GetCancellationTokenOnDestroy();
        await UniTask.Delay(System.TimeSpan.FromSeconds(goWaitTime), cancellationToken: _token);
    }

    /// <summary>
    /// 時間制限の計測
    /// </summary>
    public void TimeLimitCalculation()
    {
        if (isTimeUp) return;

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            isTimeUp = true;
            OnTimeUp?.Invoke();
        }
    }
}
