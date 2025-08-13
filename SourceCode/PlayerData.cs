using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Sprite GirlNormalImage { get => _girlNormalImage;}
    public Sprite GirlWalkImage { get => _girlWalkImage;}
    public Sprite GirlHappyImage { get => _girlHappyImage;}
    public Sprite GirlTroubleImage { get => _girlTroubleImage;}

    [Header("プレイヤーの画像集")]
    [Header("通常の少女画像")]
    [SerializeField] private Sprite _girlNormalImage;
    [Header("歩いている少女画像")]
    [SerializeField] private Sprite _girlWalkImage;
    [Header("喜んでいる少女画像")]
    [SerializeField] private Sprite _girlHappyImage;
    [Header("困っている少女画像")]
    [SerializeField] private Sprite _girlTroubleImage;
}
