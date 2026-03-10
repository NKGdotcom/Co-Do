using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タスクに必要な要素
/// </summary>
public interface ITaskController
{
    Item[] NeedItems { get; } //必要なアイテムについて
    bool CanExcuteTask(Item _playerHasItem); //タスクが完了できるかどうか
    void ExcuteTask(); //タスク完了したら

    event Action OnCompleteTask; //タスクが完了したと伝える
}
