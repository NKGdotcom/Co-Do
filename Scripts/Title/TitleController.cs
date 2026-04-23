using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面を管理するクラス
/// </summary>
public class TitleController : MonoBehaviour
{
    [Header("コンポーネント参照")]
    [Tooltip("タイトルでゲーム開始のアニメーションを管理するクラス")]
    [SerializeField] private TitleGameStartAnimation titleGameStartAnimation;

    private void Awake()
    {
        if(titleGameStartAnimation == null) { Debug.LogError("titleGameStartAnimationが参照されていません"); return; }
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンを押したらスタート
        if (Input.anyKeyDown)
        {
            //アニメーション後フェードアウトしてゲーム開始
            titleGameStartAnimation.GameStartAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }
    }
}
