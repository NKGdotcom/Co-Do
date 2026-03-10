using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("通常の少女画像")]
    public Sprite girlIdleImage;
    [Header("歩いている少女画像")]
    public Sprite girlWalkImage;
    [Header("喜んでいる少女画像")]
    public Sprite girlHappyImage;
    [Header("困っている少女画像")]
    public Sprite girlTroubleImage;
    [Header("プレイヤーの移動速度")]
    public float playerMoveSpeed;
}
