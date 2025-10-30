using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerItemGetInf : MonoBehaviour
{
    public static PlayerItemGetInf Instance { get; private set; }
    public int NowHaveItemNum {  get => nowHaveItemNum; private set => nowHaveItemNum = value; }
    public int MaxHaveItemNum { get => maxHaveItemNum; private set => maxHaveItemNum = value; }

    private PlayerUIManager playerUIManager;
    private int nowHaveItemNum = 0;
    private int maxHaveItemNum = 5;

    private Dictionary<KeyCode, Items.ItemType.ItemTypes> keyItemMap;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetKeyDictionary();

        playerUIManager = GetComponent<PlayerUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete)) DestroyItem();
        if (Input.GetKeyDown(KeyCode.B)) ItemBox.Instance.CombinationItem();
        if (nowHaveItemNum >= maxHaveItemNum) return;
        KeybordGetItem();
    }
    /// <summary>
    /// 初めに辞書として設定
    /// </summary>
    private void SetKeyDictionary()
    {
        keyItemMap = new Dictionary<KeyCode, Items.ItemType.ItemTypes>
        {
            { KeyCode.Alpha1, Items.ItemType.ItemTypes.Slippers },　//ハサミ
            { KeyCode.Alpha2, Items.ItemType.ItemTypes.Toilet }, //トイレ
            { KeyCode.Alpha3, Items.ItemType.ItemTypes.Driver }, //ドライバー

            { KeyCode.Q, Items.ItemType.ItemTypes.Blanket }, //ブランケット
            { KeyCode.W, Items.ItemType.ItemTypes.SteppingStone }, //踏み台
            { KeyCode.E, Items.ItemType.ItemTypes.FlashLight }, //懐中電灯

            { KeyCode.A, Items.ItemType.ItemTypes.Water }, //水
            { KeyCode.S, Items.ItemType.ItemTypes.Glove }, //軍手
            { KeyCode.D, Items.ItemType.ItemTypes.Battery }, //電池

            { KeyCode.Z, Items.ItemType.ItemTypes.Noodle }, //カップ麺
            { KeyCode.X, Items.ItemType.ItemTypes.PlasticBag }, //ポリ袋
            { KeyCode.C, Items.ItemType.ItemTypes.Scissors } //ハサミ
        };
    }
    /// <summary>
    /// キーボードでアイテムを獲得
    /// </summary>
    public void KeybordGetItem()
    {
        if (GameState.Instance.IsGameScene())
        {
            foreach (var pair in keyItemMap)
            {
                if (Input.GetKeyDown(pair.Key))
                {
                    GetItemInformation(pair.Value);
                    break;
                }
            }
        } 
    }
    /// <summary>
    /// アイテム情報を取得
    /// </summary>
    /// <param name="_item"></param>
    public void GetItemInformation(Items.ItemType.ItemTypes _item)
    {
        nowHaveItemNum++;
        Items.ItemType _itemType = ItemGenerater.Instance.GetItemInformation(_item);
        ItemBox.Instance.SetItem(_itemType);
    }
    /// <summary>
    /// 落ちてるアイテムを拾ってアイテム情報を取得
    /// </summary>
    /// <param name="_item"></param>
    public void ColliderGetItem(Items.ItemType.ItemTypes _item)
    {
        if (nowHaveItemNum > maxHaveItemNum) return;
        GetItemInformation(_item);
    }
    /// <summary>
    /// 組み合わせる時のみ、2個分消す
    /// </summary>
    public void Combination()
    {
        nowHaveItemNum-= 2;
    }
    /// <summary>
    /// アイテムを使ってみる
    /// </summary>
    /// <param name="_item"></param>
    public void TryUseItem(Items.ItemType.ItemTypes _item)
    {
        bool _solution;
        _solution = ItemBox.Instance.TryUseItem(_item);
        if (_solution)
        {
            nowHaveItemNum--;
            StartCoroutine(playerUIManager.HappySolution());
            switch (_item)
            {
                case Items.ItemType.ItemTypes.Slippers: //スリッパをはく
                    EarthquakeProblem.Instance.OneSolution();
                    HouseState.Instance.SafeGlass();
                    break;
                case Items.ItemType.ItemTypes.Battery: //バッテリーを交換する
                    EarthquakeProblem.Instance.OneSolution();
                    HouseState.Instance.FixRadio();
                    break;
                case Items.ItemType.ItemTypes.SteppingStone: //踏み台を置く
                    EarthquakeProblem.Instance.OneSolution();
                    HouseState.Instance.FixBreaker();
                    break;
                case Items.ItemType.ItemTypes.Hammer: //ハンマーでたたく
                    HouseState.Instance.BreakWindow();
                    break;
                case Items.ItemType.ItemTypes.RainCoat: //レインコートを着る
                    HouseState.Instance.WearRainCoat();
                    break;
                case Items.ItemType.ItemTypes.Blanket:
                    HouseState.Instance.WearRainCoat();
                    break;
            }
        }
    }
    /// <summary>
    /// アイテムを消去
    /// </summary>
    public void DestroyItem()
    {
        nowHaveItemNum--;
        ItemBox.Instance.OneSlotRemove();
    }
}
