using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// タスクの解決すべき問題のUIを表示
/// </summary>
public class TaskUIView : MonoBehaviour
{
    //---解決すべき問題のUI---
    [SerializeField] private TextMeshProUGUI taskTMP;

    void Awake()
    {
        if(taskTMP == null) { Debug.LogError("taskTMPが参照されていません。"); return; }
    }

    /// <summary>
    /// 解決すべき問題のテキストを更新
    /// </summary>
    public void UpdateTaskView(int _nowSolution, int _shouldSolution)
    {
        taskTMP.text = $"解決すべき問題：{_nowSolution}/{_shouldSolution}";
    }
}
