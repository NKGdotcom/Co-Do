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
    /// ���߂Ɏ����Ƃ��Đݒ�
    /// </summary>
    private void SetKeyDictionary()
    {
        keyItemMap = new Dictionary<KeyCode, Items.ItemType.ItemTypes>
        {
            { KeyCode.Alpha1, Items.ItemType.ItemTypes.Slippers },�@//�n�T�~
            { KeyCode.Alpha2, Items.ItemType.ItemTypes.Toilet }, //�g�C��
            { KeyCode.Alpha3, Items.ItemType.ItemTypes.Driver }, //�h���C�o�[

            { KeyCode.Q, Items.ItemType.ItemTypes.Blanket }, //�u�����P�b�g
            { KeyCode.W, Items.ItemType.ItemTypes.SteppingStone }, //���ݑ�
            { KeyCode.E, Items.ItemType.ItemTypes.FlashLight }, //�����d��

            { KeyCode.A, Items.ItemType.ItemTypes.Water }, //��
            { KeyCode.S, Items.ItemType.ItemTypes.Glove }, //�R��
            { KeyCode.D, Items.ItemType.ItemTypes.Battery }, //�d�r

            { KeyCode.Z, Items.ItemType.ItemTypes.Noodle }, //�J�b�v��
            { KeyCode.X, Items.ItemType.ItemTypes.PlasticBag }, //�|����
            { KeyCode.C, Items.ItemType.ItemTypes.Scissors } //�n�T�~
        };
    }
    /// <summary>
    /// �L�[�{�[�h�ŃA�C�e�����l��
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
    /// �A�C�e�������擾
    /// </summary>
    /// <param name="_item"></param>
    public void GetItemInformation(Items.ItemType.ItemTypes _item)
    {
        nowHaveItemNum++;
        Items.ItemType _itemType = ItemGenerater.Instance.GetItemInformation(_item);
        ItemBox.Instance.SetItem(_itemType);
    }
    /// <summary>
    /// �����Ă�A�C�e�����E���ăA�C�e�������擾
    /// </summary>
    /// <param name="_item"></param>
    public void ColliderGetItem(Items.ItemType.ItemTypes _item)
    {
        if (nowHaveItemNum > maxHaveItemNum) return;
        GetItemInformation(_item);
    }
    /// <summary>
    /// �g�ݍ��킹�鎞�̂݁A2������
    /// </summary>
    public void Combination()
    {
        nowHaveItemNum-= 2;
    }
    /// <summary>
    /// �A�C�e�����g���Ă݂�
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
                case Items.ItemType.ItemTypes.Slippers: //�X���b�p���͂�
                    EarthquakeProblem.Instance.OneSolution();
                    HouseState.Instance.SafeGlass();
                    break;
                case Items.ItemType.ItemTypes.Battery: //�o�b�e���[����������
                    EarthquakeProblem.Instance.OneSolution();
                    HouseState.Instance.FixRadio();
                    break;
                case Items.ItemType.ItemTypes.SteppingStone: //���ݑ��u��
                    EarthquakeProblem.Instance.OneSolution();
                    HouseState.Instance.FixBreaker();
                    break;
                case Items.ItemType.ItemTypes.Hammer: //�n���}�[�ł�����
                    HouseState.Instance.BreakWindow();
                    break;
                case Items.ItemType.ItemTypes.RainCoat: //���C���R�[�g�𒅂�
                    HouseState.Instance.WearRainCoat();
                    break;
                case Items.ItemType.ItemTypes.Blanket:
                    HouseState.Instance.WearRainCoat();
                    break;
            }
        }
    }
    /// <summary>
    /// �A�C�e��������
    /// </summary>
    public void DestroyItem()
    {
        nowHaveItemNum--;
        ItemBox.Instance.OneSlotRemove();
    }
}
