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

    [Header("�v���C���[�̉摜�W")]
    [Header("�ʏ�̏����摜")]
    [SerializeField] private Sprite _girlNormalImage;
    [Header("�����Ă��鏭���摜")]
    [SerializeField] private Sprite _girlWalkImage;
    [Header("���ł��鏭���摜")]
    [SerializeField] private Sprite _girlHappyImage;
    [Header("�����Ă��鏭���摜")]
    [SerializeField] private Sprite _girlTroubleImage;
}
