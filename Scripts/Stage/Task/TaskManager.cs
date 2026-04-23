using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ上のタスク全体を管理するクラス
/// </summary>
public class TaskManager : MonoBehaviour
{
    [Header("コンポーネントの参照")]
    [Tooltip("ステージのタスクをまとめたリスト")]
    [SerializeField] private List<BaseTask> taskList = new List<BaseTask>();
    [Tooltip("タスクの数に関するUIの表示")]
    [SerializeField] private TaskUIView taskUIView;
    [Tooltip("全てのタスクが終わったときのゴールの管理")]
    [SerializeField] private GoalController goalController;

    //タスク数の管理
    private int shouldSolutionTaskNum;
    private int nowSolutionTaskNum;

    void Awake()
    {
        if(taskList == null) { Debug.LogError("taskListが参照されていません"); return; }
        if(taskUIView == null) { Debug.LogError("taskUIViewが参照されていません"); return; }
        if(goalController == null) { Debug.LogError("goalControllerが参照されていません"); return; }

        foreach (var _task in taskList)
        {
            _task.OnCompleteTask += OneTaskFinish;
        }

        SearchTask();
    }

    /// <summary>
    /// タスク量を調べ、UIを表示する初期設定
    /// </summary>
    private void SearchTask()
    {
        shouldSolutionTaskNum = taskList.Count;

        nowSolutionTaskNum = 0;
        taskUIView.UpdateTaskView(nowSolutionTaskNum, shouldSolutionTaskNum);
    }

    /// <summary>
    /// 一つのタスクが終了したら、タスク数を更新し、全てのタスクが終わっているか確認する
    /// </summary>
    private void OneTaskFinish()
    {
        nowSolutionTaskNum++;
        taskUIView.UpdateTaskView(nowSolutionTaskNum, shouldSolutionTaskNum);
        if (IsFinishAllTask()) { goalController.AllTaskSoution(); }
    }

    /// <summary>
    /// 全てのタスクが終わっているか
    /// </summary>
    /// <returns></returns>
    private bool IsFinishAllTask()
    {
        return nowSolutionTaskNum <= shouldSolutionTaskNum;
    }
}
