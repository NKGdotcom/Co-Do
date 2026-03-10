using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    READY, //よーいスタートの間
    GAME, //ゲーム中
    DRAG, //ドラッグ中
    HAPPY, //タスクをクリアして演出の間
    ITEM, //アイテム確認時
    RESULT, //リザルト時
}

/// <summary>
/// ゲームのステートを確認
/// </summary>
public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    public State NowState {  get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        SetState(State.READY);
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
        return NowState == State.READY;
    }
    /// <summary>
    /// ゲームシーン中か
    /// </summary>
    /// <returns></returns>
    public bool IsGame()
    {
        return NowState == State.GAME;
    }
    /// <summary>
    /// ドラッグ中か
    /// </summary>
    /// <returns></returns>
    public bool IsDrag()
    {
        return NowState == State.DRAG;
    }
    /// <summary>
    /// リザルト画面中か
    /// </summary>
    /// <returns></returns>
    public bool IsResult()
    {
        return NowState == State.RESULT;
    }

    public bool IsItemIntroduce()
    {
        return NowState == State.ITEM;
    }
}
