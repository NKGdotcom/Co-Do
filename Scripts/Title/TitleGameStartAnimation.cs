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
    [Header("TapToKeyを選択")]
    [SerializeField] private Animator startAnimator;
    [SerializeField] private Fade fade;
    private const string STR_TAP = "Tap";
    // Start is called before the first frame update
    private void Awake()
    {
        if(startAnimator == null) { TryGetComponent<Animator>(out startAnimator); }
        if(fade == null) { Debug.LogError("fadeが参照されていません"); return; }
    }

    public async UniTaskVoid GameStart(CancellationToken _token)
    {
        startAnimator.SetTrigger(STR_TAP);
        int _tapState = Animator.StringToHash(STR_TAP);
        
        await UniTask.Yield(_token);

        await UniTask.WaitUntil(() =>
        {
            AnimatorStateInfo _stateInfo = startAnimator.GetCurrentAnimatorStateInfo(0);
            return _stateInfo.shortNameHash == _tapState && _stateInfo.normalizedTime >= 1;
        }, cancellationToken: _token);

        fade.FadeOut(_token).Forget(); ;
    }
}
