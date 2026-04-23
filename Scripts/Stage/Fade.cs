using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// シーンを移動したい際に呼び出すフェードアニメーション管理
/// </summary>
public class Fade : MonoBehaviour
{
    [Header("シーン遷移")]
    [Tooltip("フェードアニメーションでフェードアウト")]
    [SerializeField] private Animator fadeAnimator;
    [Tooltip("シーン遷移を管理するクラス")]
    [SerializeField] private SceneTransition sceneTransition;
    private const string STR_FADEOUT = "FadeOut";
    private void Awake()
    {
        if(fadeAnimator == null) { Debug.LogError("fadeAnimatorが参照されていません"); return; }
        if(sceneTransition == null) { Debug.LogError("sceneTransitionが参照されていません"); return; }
    }

    /// <summary>
    /// フェードアウト処理を行い、シーン遷移する非同期処理
    /// </summary>
    /// <param name="_token"></param>
    /// <returns></returns>
    public async UniTaskVoid FadeOut(CancellationToken _token)
    {
        fadeAnimator.SetTrigger(STR_FADEOUT);
        int _fadeoutState = Animator.StringToHash(STR_FADEOUT);

        await UniTask.Yield(_token);

        //フェードアウトアニメーションが終わるまで待機
        await UniTask.WaitUntil(() =>
        {
            AnimatorStateInfo _stateInfo = fadeAnimator.GetCurrentAnimatorStateInfo(0);
            return _stateInfo.shortNameHash == _fadeoutState && _stateInfo.normalizedTime >= 1;
        }, cancellationToken: _token);

        //次のシーンに遷移
        sceneTransition.NextSceneTransition();
    }
}
