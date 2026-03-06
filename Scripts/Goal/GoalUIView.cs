using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ゴールに関連するUIを表示
/// </summary>
public class GoalUIView : MonoBehaviour
{
    //---タスクが終わっていない場合の表示---
    [SerializeField] private TextMeshProUGUI notFinishTaskTMP;
    private float delayTime = 2f;
    //---リザルトの表示---
    [SerializeField] private GameObject clearUIObj;
    [SerializeField] private GameObject failedUIObj;

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
        //音
        GameState.Instance.SetState(State.RESULT);
    }

    /// <summary>
    /// 失敗演出
    /// </summary>
    public void FailedPerformance()
    {
        failedUIObj.SetActive(true);
        //音
        GameState.Instance.SetState(State.RESULT);
    }
}
