using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タスクの管理
/// </summary>
public class TaskManager : MonoBehaviour
{
    //---タスクの数---
    [SerializeField] private List<BaseTask> taskList = new List<BaseTask>();
    private int shouldSolutionTaskNum;
    private int nowSolutionTaskNum;
    //---タスク数のUI---
    [SerializeField] private TaskUIView taskUIView;
    //---ゴール(リザルト表示)---
    [SerializeField] private GoalController goalController;

    void Awake()
    {
        if(taskList == null) { Debug.LogError("taskListが参照されていません"); return; }

        foreach(var _task in taskList)
        {
            _task.OnCompleteTask += OneTaskFinish;
        }
        SearchTask();
    }

    /// <summary>
    /// タスク量を調べる
    /// </summary>
    private void SearchTask()
    {
        Debug.Log($"現在の taskList の数: {taskList.Count}");
        shouldSolutionTaskNum = taskList.Count;

        nowSolutionTaskNum = 0;
        taskUIView.UpdateTaskView(nowSolutionTaskNum, shouldSolutionTaskNum);
    }

    /// <summary>
    /// 一つのタスクが終了
    /// </summary>
    private void OneTaskFinish()
    {
        nowSolutionTaskNum++;
        taskUIView.UpdateTaskView(nowSolutionTaskNum, shouldSolutionTaskNum);
        if (FinishAllTask()) { goalController.AllTaskSoution(); }
    }

    /// <summary>
    /// 全てのタスクが終わっているか
    /// </summary>
    /// <returns></returns>
    private bool FinishAllTask()
    {
        return nowSolutionTaskNum <= shouldSolutionTaskNum;
    }
}
