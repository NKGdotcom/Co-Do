using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// ゲームスタートのテキストアニメーションを行う
/// </summary>
public class TitleGameStartAnimation : MonoBehaviour
{
    [Header("アニメーション")]
    [Tooltip("クリックするとテキストが点滅するアニメーション")]
    [SerializeField] private Animator startAnimator;
    [Tooltip("フェードアウトのアニメーション")]
    [SerializeField] private Fade fade;
    private const string STR_TAP = "Tap";
    // Start is called before the first frame update
    private void Awake()
    {
        if(startAnimator == null) { Debug.LogError("startAnimatorが参照されていません"); return; }
        if(fade == null) { Debug.LogError("fadeが参照されていません"); return; }
    }

    /// <summary>
    /// ゲームを開始し、ステージに移る際の一連の非同期処理を行う
    /// </summary>
    /// <param name="_token"></param>
    /// <returns></returns>
    public async UniTaskVoid GameStartAsync(CancellationToken _token)
    {
        startAnimator.SetTrigger(STR_TAP);
        int _tapState = Animator.StringToHash(STR_TAP);
        
        await UniTask.Yield(_token);

        //Tapアニメーションが終わるまで待機
        await UniTask.WaitUntil(() =>
        {
            AnimatorStateInfo _stateInfo = startAnimator.GetCurrentAnimatorStateInfo(0);
            return _stateInfo.shortNameHash == _tapState && _stateInfo.normalizedTime >= 1;
        }, cancellationToken: _token);

        //フェードアウトしてシーン移動
        fade.FadeOut(_token).Forget(); ;
    }
}
