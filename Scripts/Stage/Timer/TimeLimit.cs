using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

/// <summary>
/// 制限時間のパラメータを管理し計算を行うクラス
/// </summary>
public class TimeLimit : MonoBehaviour
{
    [Header("制限時間のパラメータ")]
    [Tooltip("よーいの表示時間")]
    [SerializeField] private float readyWaitTime = 2.0f;
    [Tooltip("スタート！の表示時間")]
    [SerializeField] private float goWaitTime = 2.0f;
    [Tooltip("制限時間")]
    [SerializeField] private float stageTime = 180f;
    public float Timer { get => timer; }
    private float timer = 0;

    //時間切れになった場合
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
    /// 制限時間の計測
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
