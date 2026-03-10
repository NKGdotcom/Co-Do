using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 時間に関するUI表示
/// </summary>
public class TimerView : MonoBehaviour
{
    //---よーいどんテキスト---
    [SerializeField] private TextMeshProUGUI readyTMP;
    [SerializeField] private TextMeshProUGUI goTMP;
    //---時間制限テキスト---
    [SerializeField] private TextMeshProUGUI timerTMP;

    public void Awake()
    {
        if(readyTMP == null){ Debug.LogError("readyTMPが参照されていません"); return; }
        if(goTMP == null) { Debug.LogError("goTMPが参照されていません"); return; }
        if(timerTMP == null) { Debug.LogError("timerTMPが参照されていません"); return; }
    }

    /// <summary>
    /// Readyのテキストを表示
    /// </summary>
    public void ShowReadyTMP()
    {
        HideAllTMP();
        ShowTMP(readyTMP);
    }

    /// <summary>
    /// テキストをすべて非表示
    /// </summary>
    public void HideAllTMP()
    {
        readyTMP.enabled = false;
        goTMP.enabled = false;
    }

    /// <summary>
    /// TMPを表示
    /// </summary>
    private void ShowTMP(TextMeshProUGUI _tmp)
    {
        _tmp.enabled = true;
    }

    /// <summary>
    /// スタートのTMPを表示
    /// </summary>
    public void ShowGoTMP()
    {
        HideAllTMP();
        ShowTMP(goTMP);
    }
    
    /// <summary>
    /// UIで制限時間を表示
    /// </summary>
    /// <param name="_timer"></param>
    public void TimerDisplay(float _timer)
    {
        int _minutes = Mathf.FloorToInt(_timer / 60);
        int _seconds = Mathf.FloorToInt(_timer % 60);
        timerTMP.text = string.Format("{0}:{1:00}", _minutes, _seconds);
    }
}
