using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルでの処理をまとめる
/// ここから呼び出す
/// </summary>
public class TitleController : MonoBehaviour
{
    [SerializeField] private TitleGameStartAnimation titleGameStartAnimation;

    private void Awake()
    {
        if(titleGameStartAnimation == null) { TryGetComponent<TitleGameStartAnimation>(out titleGameStartAnimation); }
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンを押したらスタート
        if (Input.anyKeyDown)
        {
            titleGameStartAnimation.GameStart(this.GetCancellationTokenOnDestroy()).Forget();
        }
    }
}
