using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// タスクに関するUIを管理するクラス
/// </summary>
public class BaseTaskView : MonoBehaviour, ITaskView
{
    [Header("タスクに近づいた際に表示するコメント")]
    [Tooltip("タスクに近づいた際に表示するUI全体")]
    [SerializeField] private GameObject commentUI;
    public GameObject CommentUI { get => commentUI; }
    [Tooltip("タスク完了前のコメント")]
    [SerializeField] private TextMeshProUGUI beforeCommentTMP;
    [Tooltip("タスク完了後のコメント")]
    [SerializeField] private TextMeshProUGUI afterCommentTMP;

    [Header("タスクの状態に関する設定")]
    [SerializeField] private bool isEveryDisplay = true;

    private bool isFinishedDisplay = false; //isEveryDisplayがfalseの場合isFinishedDisplayで一回表示したか判断
    private bool isTaskClear = false;
    private void Awake()
    {
        if (commentUI == null) { Debug.LogError("commentUIが参照されていません"); return; }
        if (beforeCommentTMP == null) { Debug.LogError("beforeCommentTMPが参照されていません"); return; }
        if (beforeCommentTMP == null) { Debug.LogError("afterCommentTMPが参照されていません"); return; }
    }

    /// <summary>
    /// コメントを表示
    /// </summary>
    public void ShowCommentUI()
    {
        if (isEveryDisplay) //毎回表示するか
        {
            DisplayEveryTime();
        }
        //1回のみ表示するか
        else if (!isEveryDisplay && !isFinishedDisplay)
        {
            DisplayEveryTime();
        }
    }

    /// <summary>
    /// タスク完了後のテキストセット
    /// </summary>
    public void SetAfterText()
    {
        beforeCommentTMP.enabled = false;
        afterCommentTMP.enabled = true;
    }

    /// <summary>
    /// コメントを隠す
    /// </summary>
    public void HideCommentUI()
    {
        commentUI.gameObject.SetActive(false);
        beforeCommentTMP.enabled = false;
        afterCommentTMP.enabled = false;
    }

    /// <summary>
    /// タスクをクリアしたか
    /// </summary>
    public void TaskComplete()
    {
        isFinishedDisplay = true;
        isTaskClear = true;
    }

    /// <summary>
    /// タスクが終わった後も毎回コメントを表示する
    /// </summary>
    private void DisplayEveryTime()
    {
        commentUI.gameObject.SetActive(true);
        //タスクが解決する前なら前のコメントを、解決しているなら後のコメントを表示する
        if (!isTaskClear) { SetBeforeText(); }
        else { SetAfterText(); }
    }

    /// <summary>
    /// タスク完了前のテキストセット
    /// </summary>
    private void SetBeforeText()
    {
        beforeCommentTMP.enabled = true;
    }
}
