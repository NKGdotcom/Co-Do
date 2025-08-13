using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplineState : MonoBehaviour
{
    public static PlayerSplineState Instance {  get; private set; }

    [Header("プレイヤー画像データ")]
    [SerializeField] private PlayerData playerData;
    [Header("プレイヤーの画像")]
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
    /// プレイヤーの画像を変更
    /// </summary>
    /// <param name="_playerSprite"></param>
    private void SetSpriteImage(Sprite _playerSprite)
    {
        playerSpriteRenderer.sprite = _playerSprite;
    }
    /// <summary>
    /// うれしい画像に変更
    /// </summary>
    public void SetHappyImage()
    {
        SetSpriteImage(playerData.GirlHappyImage);
    }
    /// <summary>
    /// 通常状態画像に変更
    /// </summary>
    public void SetStandImage()
    {
        SetSpriteImage(playerData.GirlNormalImage);
    }
    /// <summary>
    /// 困っている画像に変更
    /// </summary>
    public void SetTroubleImage()
    {
        SetSpriteImage(playerData.GirlTroubleImage);
    }
    /// <summary>
    /// 歩き画像に変更
    /// </summary>
    public void SetWalkImage()
    {
        SetSpriteImage(playerData.GirlWalkImage);
    }
}
