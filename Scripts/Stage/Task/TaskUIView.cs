using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// タスク数に関するUIを表示
/// </summary>
public class TaskUIView : MonoBehaviour
{
    [Header("コンポーネント参照")]
    [Tooltip("解決すべき問題の数を表示")]
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
        //現在の解決数と、解決すべき問題の数を表示
        taskTMP.text = $"解決すべき問題：{_nowSolution}/{_shouldSolution}";
    }
}