using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// プレイヤーの処理をここでまとめる
/// </summary>
public class PlayerController : MonoBehaviour
{
    //---プレイヤーのデータ---
    [SerializeField] private PlayerData playerData;
    //---プレイヤーの挙動---
    [SerializeField] private PlayerMovement playerMovement;
    private float touchThreshold = 0.1f;
    private const float RIGHT_DIRECTION = 1;
    private const float LEFT_DIRECTION = -1;
    [SerializeField] private PlayerSpriteView playerSpriteView;
    //---プレイヤーが持っているアイテムの管理---
    [SerializeField] private ItemHaveController itemHaveController;
    //---コメントに触れたときタスクをクリアしたかしていないか---
    private bool isFaceProblem = false;
    private bool isHappy = false;
    //---移動で無視するレイヤー
    [SerializeField] private LayerMask ignoreUILayer;
    private void Awake()
    {
        if(playerMovement == null) { Debug.LogError("playerMovementが参照されていません。"); return; }
        if(playerSpriteView == null) { Debug.LogError("playerSpriteViewが参照されていません。"); return; }

        playerMovement.SetUp(playerData);
        playerSpriteView.SetUp(playerData);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.Instance.IsGame()) return;
        float _horizontalInput = 0f;
        bool isOverUI = false;
        if (Input.touchCount > 0)
        {
            isOverUI = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }
        else
        {
            isOverUI = EventSystem.current.IsPointerOverGameObject();
        }
        if (isOverUI)
        {
            Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
            UnityEngine.EventSystems.PointerEventData pointerData = new UnityEngine.EventSystems.PointerEventData(EventSystem.current);
            pointerData.position = inputPosition;

            System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> results = new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            isOverUI = false;

            foreach (var result in results)
            {
                if (((1 << result.gameObject.layer) & ignoreUILayer) == 0)
                {
                    isOverUI = true;
                    break;
                }
            }
        }
        if (Input.GetMouseButton(0)&& !isOverUI)
        {
            Vector3 _touchWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float _distanceX = _touchWorldPos.x - transform.position.x;

            if (TouchRight(_distanceX))
            {
                _horizontalInput = RIGHT_DIRECTION;
            }
            else if (TouchLeft(_distanceX))
            {
                _horizontalInput = LEFT_DIRECTION;
            }
        }
        else
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        playerMovement.PlayerMoveMovement(_horizontalInput);
        playerSpriteView.UpdateSpriteByInput(_horizontalInput, isFaceProblem, isHappy);
    }

    private bool TouchRight(float _directionX)
    {
        return _directionX > touchThreshold;
    }

    private bool TouchLeft(float _directionX)
    {
        return _directionX < touchThreshold;
    }
    /// <summary>
    /// タスクが終わってハッピー
    /// </summary>
    public void TaskCompleteHappy()
    {
        isFaceProblem = false;
        isHappy = true;
        playerSpriteView.ShowHappyStarUI();
    }
    /// <summary>
    /// タスクに直面
    /// </summary>
    public void FaceingProblem()
    {
        isFaceProblem = true;
        playerSpriteView.ShowTroubleSweatUI();
    }

    /// <summary>
    /// タスクに直面していない
    /// </summary>
    public void NoProbem()
    {
        isFaceProblem = false;
        isHappy = false;
        playerSpriteView.HideTroubleSweatUI();
        playerSpriteView.HideHappyStartUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IItem>(out var _colItem))
        {
            itemHaveController.GetItemReservation(_colItem.MyItem);
            Destroy(collision.gameObject);
        }
    }
}
