using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerLimited : MonoBehaviour
{
    [Header("「よーい」表示時間")]
    [SerializeField] private float readyWaitTime = 2.0f;
    [Header("「スタート！」表示時間")]
    [SerializeField] private float goWaitTime = 2.0f;
    [Header("制限時間")]
    [SerializeField] private float stageTime = 180f;
    [Header("ReadyGoのテキスト")]
    [SerializeField] private TextMeshProUGUI readygoText;
    [Header("制限時間のテキスト")]
    [SerializeField] private TextMeshProUGUI timerText;

    private float minute = 60;
    private float second = 60;

    // Start is called before the first frame update
    void Start()
    {
        TimerDisplay(stageTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.Instance.IsReady())
        {
            if(readyWaitTime > 0)
            {
                readyWaitTime -= Time.deltaTime;
                readygoText.text = "よーい";
            }
            else
            {
                goWaitTime -= Time.deltaTime;
                readygoText.text = "スタート!";
                if(goWaitTime <= 0)
                {
                    GameState.Instance.SetState(GameState.State.GameScene);
                    readygoText.text = "";
                }
            }
        }
        else if(GameState.Instance.IsGameScene())
        {
            if (stageTime > 0)
            {
                stageTime -= Time.deltaTime;
                TimerDisplay(stageTime);
            }
            else if(stageTime < 0)
            {
                stageTime = 0;
                TimerDisplay(stageTime);
                GameResult.Instance.GameFailed();
            }
        }
    }
    /// <summary>
    /// 時間をテキストに設定
    /// </summary>
    /// <param name="_time">時間</param>
    private void TimerDisplay(float _time)
    {
        int _minutes = Mathf.FloorToInt(_time / minute);
        int _seconds = Mathf.FloorToInt(_time % second);
        timerText.text = string.Format("{0}:{1:00}", _minutes, _seconds);
    }
}
