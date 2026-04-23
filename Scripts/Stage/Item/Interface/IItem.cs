using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムを定義するインタフェース
/// </summary>
public interface IItem 
{
    /// <summary>
    /// 自分の現在持っているアイテムを返すプロパティ
    /// </summary>
    Item MyItem {  get; }
}
