using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseTaskView : MonoBehaviour, ITaskView
{
    //---近づいた際に表示するコメント---
    public GameObject CommentUI { get => commentUI; private set => commentUI = value; }
    [SerializeField] private GameObject commentUI;
    [SerializeField] private TextMeshProUGUI beforeCommentTMP;
    [SerializeField] private TextMeshProUGUI afterCommentTMP;
    //---タスクが終わったかの判定など---
    [Header("タスク完了後に表示するものを一度のみか何度も見せるか")]
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
        else if(!isEveryDisplay && !isFinishedDisplay)
        {
            DisplayEveryTime();
        }
    }

    /// <summary>
    /// タスクが終わった後も毎回コメントを表示する
    /// </summary>
    private void DisplayEveryTime()
    {
        commentUI.gameObject.SetActive(true);
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
        afterCommentTMP.enabled= false;
    }

    /// <summary>
    /// タスクをクリアしたか
    /// </summary>
    public void TaskComplete()
    {
        isFinishedDisplay = true;
        isTaskClear = true;
    }
}
