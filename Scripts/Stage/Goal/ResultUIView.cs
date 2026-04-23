using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// リザルトの表示を管理するクラス
/// </summary>
public class ResultUIView : MonoBehaviour
{
    [Header("コンポーネント参照")]
    [Tooltip("タスクが完了していないときに表示")]
    [SerializeField] private TextMeshProUGUI notFinishTaskTMP;
    [Header("ゴール演出")]
    [Tooltip("ゴール演出のUIオブジェクト")]
    [SerializeField] private GameObject clearUIObj;
    [SerializeField] private GameObject failedUIObj;

    private float delayTime = 2f;

    private void Awake()
    {
        if(notFinishTaskTMP == null) { Debug.LogError("notFinishTaskTMPが参照されていません"); return;}
        if(clearUIObj == null) { Debug.LogError("clearUIObjが参照されていません"); return; }
        if(failedUIObj == null) { Debug.LogError("failedUIObjが参照されていません"); return; }
    }

    /// <summary>
    /// ゴール条件がそろっていない場合
    /// </summary>
    /// <returns></returns>
    public async UniTaskVoid NotFinishTaskAsync()
    {
        notFinishTaskTMP.enabled = true;
        await UniTask.Delay(TimeSpan.FromSeconds(delayTime));
        notFinishTaskTMP.enabled = false;
    }

    /// <summary>
    /// クリア演出
    /// </summary>
    public void ClearPerformance()
    {
        clearUIObj.SetActive(true);
        SoundManager.Instance.PlayBGM(BGMSource.GAME_CLEAR_BGM);
        GameState.Instance.SetState(State.RESULT);
    }

    /// <summary>
    /// 失敗演出
    /// </summary>
    public void FailedPerformance()
    {
        failedUIObj.SetActive(true);
        SoundManager.Instance.PlayBGM(BGMSource.GAME_OVER_BGM);
    }
}
