using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    public enum State { Ready,GameScene,Result,Happy}

    public State NowState {  get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSource.stageBGM);
    }
    /// <summary>
    /// ゲーム状態を設定
    /// </summary>
    /// <param name="_changeState"></param>
    public void SetState(State _changeState)
    {
        NowState = _changeState;
    }
    /// <summary>
    /// 準備中か
    /// </summary>
    /// <returns></returns>
    public bool IsReady()
    {
        return NowState == State.Ready;
    }
    /// <summary>
    /// ゲームシーン中か
    /// </summary>
    /// <returns></returns>
    public bool IsGameScene()
    {
        return NowState == State.GameScene;
    }
    /// <summary>
    /// リザルト画面中か
    /// </summary>
    /// <returns></returns>
    public bool IsResult()
    {
        return NowState == State.Result;
    }
    public bool IsHappy()
    {
        return NowState == State.Happy;
    }
}
