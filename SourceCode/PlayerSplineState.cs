using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplineState : MonoBehaviour
{
    public static PlayerSplineState Instance {  get; private set; }

    [Header("�v���C���[�摜�f�[�^")]
    [SerializeField] private PlayerData playerData;
    [Header("�v���C���[�̉摜")]
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetStandImage();
    }

    /// <summary>
    /// �v���C���[�̉摜��ύX
    /// </summary>
    /// <param name="_playerSprite"></param>
    private void SetSpriteImage(Sprite _playerSprite)
    {
        playerSpriteRenderer.sprite = _playerSprite;
    }
    /// <summary>
    /// ���ꂵ���摜�ɕύX
    /// </summary>
    public void SetHappyImage()
    {
        SetSpriteImage(playerData.GirlHappyImage);
    }
    /// <summary>
    /// �ʏ��ԉ摜�ɕύX
    /// </summary>
    public void SetStandImage()
    {
        SetSpriteImage(playerData.GirlNormalImage);
    }
    /// <summary>
    /// �����Ă���摜�ɕύX
    /// </summary>
    public void SetTroubleImage()
    {
        SetSpriteImage(playerData.GirlTroubleImage);
    }
    /// <summary>
    /// �����摜�ɕύX
    /// </summary>
    public void SetWalkImage()
    {
        SetSpriteImage(playerData.GirlWalkImage);
    }
}
