using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// タスクのコメントを定義するインタフェース
/// </summary>
public interface ITaskView
{
    GameObject CommentUI { get; } //コメントUI
}
