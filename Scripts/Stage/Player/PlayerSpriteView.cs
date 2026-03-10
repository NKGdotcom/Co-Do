using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのSpriteの画像を変更
/// </summary>
public class PlayerSpriteView : MonoBehaviour
{
    //---感情UI(汗、きらきら)---
    [SerializeField] private SpriteRenderer sweatSprite;
    [SerializeField] private SpriteRenderer starSprite;
    //---プレイヤーのSprite---
    private SpriteRenderer spriteRenderer;
    private Sprite girlIdleImage;
    private Sprite girlWalkImage;
    private Sprite girlHappyImage;
    private Sprite girlTroubleImage;

    private void Awake()
    {
        TryGetComponent<SpriteRenderer>(out spriteRenderer);
        if(sweatSprite == null) { Debug.LogError("sweatSpriteが参照されていません。");return; }
        if(starSprite == null) { Debug.LogError("starSpriteが参照されていません"); return; }
    }

    /// <summary>
    /// データを受け取る
    /// </summary>
    /// <param name="_data"></param>
    public void SetUp(PlayerData _data)
    {
        girlIdleImage = _data.girlIdleImage;
        girlWalkImage = _data.girlWalkImage;
        girlHappyImage = _data.girlHappyImage;
        girlTroubleImage = _data.girlTroubleImage;
    }

    /// <summary>
    /// 入力を受け取る
    /// </summary>
    /// <param name="_horizontalInput"></param>
    public void UpdateSpriteByInput(float _horizontalInput, bool _isFaceProblem, bool _isHappy)
    {
        if(_horizontalInput == 0f)
        {
            StopPlayer(_isFaceProblem, _isHappy);
        }
        else
        {
            ChangeWalkSprite();

            if(_horizontalInput > 0f)
            {
                spriteRenderer.flipX = false; // 右を向く
            }
            else if(_horizontalInput < 0f)
            {
                spriteRenderer.flipX = true; // 左を向く
            }
        }
    }

    /// <summary>
    /// 立ち止まった
    /// </summary>
    private void StopPlayer(bool _isFaceProblem, bool _isHappy)
    {
        if (_isFaceProblem && !_isHappy) { ChangeTroubleSprite(); }
        else if (!_isFaceProblem && _isHappy) { ChangeHappySprite(); }
        else if (!_isFaceProblem && !_isHappy) { ChangeIdleSprite(); }
    }

    /// <summary>
    /// 汗を表示
    /// </summary>
    public void ShowTroubleSweatUI()
    {
        sweatSprite.enabled = true;
    }
    /// <summary>
    /// 汗を非表示
    /// </summary>
    public void HideTroubleSweatUI()
    {
        sweatSprite.enabled = false;
    }
    /// <summary>
    /// うれしい星を表示
    /// </summary>
    public void ShowHappyStarUI()
    {
        starSprite.enabled = true;
    }
    /// <summary>
    /// うれしい星を非表示
    /// </summary>
    public void HideHappyStartUI()
    {
        starSprite.enabled = false;
    }

    /// <summary>
    /// 不動状態に変更
    /// </summary>
    private void ChangeIdleSprite() { spriteRenderer.sprite = girlIdleImage; }
    /// <summary>
    /// 移動状態に画像変更
    /// </summary>
    private void ChangeWalkSprite() { spriteRenderer.sprite = girlWalkImage; }
    /// <summary>
    /// うれしい状態に画像変更
    /// タスクをクリアしたときに変更
    /// </summary>
    private void ChangeHappySprite() { spriteRenderer.sprite = girlHappyImage; }
    /// <summary>
    /// 困った状態に画像変更
    /// タスクに立ち会ったときに変更
    /// </summary>
    private void ChangeTroubleSprite() { spriteRenderer.sprite = girlTroubleImage; }
}
