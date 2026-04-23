using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// タスクとなるものに付ける
/// </summary>
public class BaseTask : MonoBehaviour, ITaskController, IDropHandler
{
    [Header("コンポーネント参照")]
    [Tooltip("タスクに触れたら表示するコメント")]
    [SerializeField] private BaseTaskView baseTaskView;

    [Header("タスクの種類")]
    [Tooltip("タスクを解決するために必要なアイテムが一つでもあれば良い")]
    [SerializeField] private Item[] needItems;
    public Item[] NeedItems { get => needItems; }
    
    //解決する時に使う
    public event Action OnCompleteTask;
    
    //現在解決しているか
    private bool isComplete;

    //タスクを解決した際の演出
    private float spriteChangeWaitTime = 0.2f;
    private float waitTime = 2;
    private PlayerController interactingPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ガラス片や窓のタスクはColliderがTriggerになっていないため、Collisionで判定する
        if (collision.gameObject.TryGetComponent<PlayerController>(out var _player))
        {
            interactingPlayer = _player;
            //専用コメントを表示
            baseTaskView.ShowCommentUI();
            //タスクが完了しているかどうかで星か汗を表示
            if (isComplete) { _player.TaskCompleteHappy(); }
            else { _player.FaceingProblem(); }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var _player))
        {
            interactingPlayer = null;
            //コメントを隠し、星と汗を非表示
            baseTaskView.HideCommentUI();
            _player.NoProbem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //基本のタスクはColliderがTriggerになっているため、Triggerで判定する
        if (collision.TryGetComponent<PlayerController>(out var _player))
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

    /// <summary>
    /// タスクの上にアイテムをドロップしたときの処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        //プレイヤーが実際にタスクの上に立っているとき
        if (interactingPlayer == null) return;

        if (eventData.pointerDrag.TryGetComponent<ItemDragController>(out var _item))
        {
            //ドロップされたアイテムがタスクをこなすことができるアイテムか
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
            if(_playerHasItem == _item)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// タスクが完了した
    /// </summary>
    public async virtual UniTaskVoid ExcuteTaskAsync()
    {
        //タスクごとの専用の処理を呼び出す
        SpecialExcuteTask();
        TryGetComponent<BoxCollider2D>(out var _collider);

        //コメントの切り替え
        interactingPlayer.NoProbem();
        interactingPlayer.TaskCompleteHappy();
        baseTaskView.SetAfterText();

        //タスクをクリアしたことを伝える
        isComplete = true;
        OnCompleteTask?.Invoke();

        //コメントを切り替える
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

    /// <summary>
    /// アイテムを使用したら消費し、スロットを空けておく
    /// </summary>
    /// <param name="_item"></param>
    private void UseItem(ItemDragController _item)
    {
        _item.UseTrashItem();
        ExcuteTaskAsync().Forget();
    }
}
