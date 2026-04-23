using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグ用
/// 想定では現実のものと一致させるようにする
/// </summary>
public class ItemKeyInput : MonoBehaviour
{
    [Header("コンポーネントの参照")]
    [Tooltip("アイテムの所持を管理するコンポーネント")]
    [SerializeField] private ItemHaveController itemHaveController;

    private void Awake()
    {
        if(itemHaveController == null) { Debug.LogError("itemHaveController"); return; }
    }

    // Update is called once per frame
    void Update()
    {
        KeyGenerateItem();
    }

    /// <summary>
    /// キー入力でアイテムの生成
    /// </summary>
    private void KeyGenerateItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { itemHaveController.GetItemReservation(Item.SLIPPERS); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { itemHaveController.GetItemReservation(Item.TOILET); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { itemHaveController.GetItemReservation(Item.DRIVER); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { itemHaveController.GetItemReservation(Item.BLANKET); }
        if (Input.GetKeyDown(KeyCode.Q)) { itemHaveController.GetItemReservation(Item.WHISTLE); }
        if (Input.GetKeyDown(KeyCode.W)) { itemHaveController.GetItemReservation(Item.FLASHLIGHT); }
        if (Input.GetKeyDown(KeyCode.E)) { itemHaveController.GetItemReservation(Item.WATER); }
        if (Input.GetKeyDown(KeyCode.R)) { itemHaveController.GetItemReservation(Item.GLOVE); }
        if (Input.GetKeyDown(KeyCode.A)) { itemHaveController.GetItemReservation(Item.BATTERY); }
        if (Input.GetKeyDown(KeyCode.S)) { itemHaveController.GetItemReservation(Item.NOODLE); }
        if (Input.GetKeyDown(KeyCode.D)) { itemHaveController.GetItemReservation(Item.PLASTICBAG); }
        if (Input.GetKeyDown(KeyCode.Z)) { itemHaveController.GetItemReservation(Item.STEPPING_STONE); }
        if (Input.GetKeyDown(KeyCode.X)) { itemHaveController.GetItemReservation(Item.HAMMER); }
        if (Input.GetKeyDown(KeyCode.C)) { itemHaveController.GetItemReservation(Item.SCISSORS); }
    }
}
