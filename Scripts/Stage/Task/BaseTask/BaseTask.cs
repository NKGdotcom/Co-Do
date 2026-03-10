using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Taskとなるものに付ける
/// </summary>
public class BaseTask : MonoBehaviour, ITaskController, IDropHandler
{
    //---タスクに近づいたときに表示するコメント---
    [SerializeField] private BaseTaskView baseTaskView;
    //---Task解決に必要なアイテム---
    public Item[] NeedItems { get => needItems; }
    [SerializeField] private Item[] needItems;
    //---解決する時に使う---
    public event Action OnCompleteTask;
    private bool isComplete;
    private float spriteChangeWaitTime = 0.2f;
    private float waitTime = 2;
    private PlayerController interactingPlayer;

    public void OnDrop(PointerEventData eventData)
    {
        if (interactingPlayer == null) return;

        if (eventData.pointerDrag.TryGetComponent<ItemDragController>(out var _item))
        {
            Item _droppedItem = _item.CurrentItem;
            if (CanExcuteTask(_droppedItem))
            {
                UseItem(_item);
            }
        }
    }

    /// <summary>
    /// タスクをこなすことができるか
    /// </summary>
    /// <param name="_playerHasItem"></param>
    /// <returns></returns>
    public bool CanExcuteTask(Item _playerHasItem)
    {
        foreach(Item _item in needItems)
        {
            Debug.Log(_playerHasItem.ToString());
            Debug.Log(_item.ToString());
            if(_playerHasItem == _item)
            {
                return true;
            }
        }
        return false;
    }

    private void UseItem(ItemDragController _item)
    {
        _item.UseTrashItem();
        ExcuteTask();
    }

    /// <summary>
    /// タスクが完了した
    /// </summary>
    public async virtual void ExcuteTask()
    {
        SpecialExcuteTask();
        TryGetComponent<BoxCollider2D>(out var _collider);
        //コメントの切り替え
        interactingPlayer.NoProbem();
        interactingPlayer.TaskCompleteHappy();
        baseTaskView.SetAfterText();
        //タスクをクリアしたことを伝える
        isComplete = true;
        OnCompleteTask?.Invoke();
        baseTaskView.TaskComplete();
        //Stateが変わるのを遅らせ、Spriteが変わるように
        await UniTask.Delay(TimeSpan.FromSeconds(spriteChangeWaitTime));
        GameState.Instance.SetState(State.HAPPY);
        SoundManager.Instance.PlaySE(SESource.HAPPY);
        //音を鳴らして少し待つ
        await UniTask.Delay(TimeSpan.FromSeconds(waitTime));
        //ゲームに戻る
        GameState.Instance.SetState(State.GAME);
    }

    /// <summary>
    /// タスクが完了したら専用のアクション
    /// </summary>
    public virtual void SpecialExcuteTask()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var _player))
        {
            interactingPlayer = _player;
            baseTaskView.ShowCommentUI();
            if (isComplete) { _player.TaskCompleteHappy(); }
            else { _player.FaceingProblem(); }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var _player))
        {
            interactingPlayer = null;
            baseTaskView.HideCommentUI();
            _player.NoProbem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out var _player))
        {
            interactingPlayer = _player;
            baseTaskView.ShowCommentUI();
            if (isComplete) { _player.TaskCompleteHappy(); }
            else { _player.FaceingProblem(); }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out var _player))
        {
            interactingPlayer = null;
            baseTaskView.HideCommentUI();
            _player.NoProbem();
        }
    }
}
