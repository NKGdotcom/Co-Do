using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [Header("プレイヤーの感情を示すイラスト(星と汗)")]
    [SerializeField] private SpriteRenderer happyStarImage;
    [SerializeField] private SpriteRenderer troubleSweatImage;

    [Header("コメント")]
    [SerializeField] private GameObject radioComment;
    private TextMeshProUGUI radioCommentText;
    [SerializeField] private GameObject breakerComment;
    private TextMeshProUGUI breakerCommentText;
    [SerializeField] private GameObject entranceComment;
    [SerializeField] private GameObject windowComment;
    private TextMeshProUGUI windowCommentText;
    [SerializeField] private GameObject pieceOfGlassComment;
    private TextMeshProUGUI pieceOfGlassCommentText;

    [Header("テキストが置いてある階層")]
    [SerializeField] private int textHierarchy = 1;

    [Header("星が表示される世界")]
    [SerializeField] private float displayStarTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        happyStarImage.enabled = false;
        troubleSweatImage.enabled = false;

        GetText(radioComment, ref radioCommentText);
        GetText(breakerComment, ref breakerCommentText);
        GetText(windowComment, ref windowCommentText);
        GetText(pieceOfGlassComment, ref pieceOfGlassCommentText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// テキストたちを取得
    /// </summary>
    /// <param name="_commentUI"></param>
    /// <param name="_commentText"></param>
    private void GetText(GameObject _commentUI, ref TextMeshProUGUI _commentText)
    {
        Transform _child = _commentUI.transform.GetChild(textHierarchy);
        _commentText = _child.GetComponent<TextMeshProUGUI>();
    }
    /// <summary>
    /// コメントUIを表示
    /// </summary>
    /// <param name="_commentUI"></param>
    public void CommentDisplay(GameObject _commentUI)
    {
        _commentUI.SetActive(true);
    }
    /// <summary>
    /// コメントUIを隠す
    /// </summary>
    public void CommentHidden()
    {
        radioComment.SetActive(false);
        breakerComment.SetActive(false);
        entranceComment.SetActive(false);
        windowComment.SetActive(false);
        pieceOfGlassComment.SetActive(false);
        happyStarImage.enabled=false;
        troubleSweatImage.enabled=false;
    }
    /// <summary>
    /// ラジオが聞けない
    /// </summary>
    public void NotHearRadioComment()
    {
        troubleSweatImage.enabled = true;
        troubleSweatImage.gameObject.SetActive(true);
        CommentDisplay(radioComment);
        PlayerSplineState.Instance.SetTroubleImage();
        radioCommentText.text = "ラジオだ...\n聴きたいのに電池が切れてる...";
    }
    /// <summary>
    /// ラジオに電源を入れた
    /// </summary>
    public void FixRadioComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(radioComment);
        radioCommentText.text = "これで安全に避難できそうだ！";
    }
    /// <summary>
    /// ブレーカーが落ちる
    /// </summary>
    public void TripBreakerComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "ブレーカーだ。高くて届かない";
    }
    /// <summary>
    /// ブレーカーを直す
    /// </summary>
    public void FixBreakerComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(breakerComment);
        breakerCommentText.text = "ブレーカーを落とした。\n火事を未然に防いだ！";
    }
    /// <summary>
    /// 家から出れない
    /// </summary>
    public void NotLeaveHouseComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(entranceComment);
        PlayerSplineState.Instance.SetTroubleImage();
    }
    /// <summary>
    /// ガラス片があって危険
    /// </summary>
    public void DangerGlassComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "棚が壊れてガラスが散っている...";
    }
    /// <summary>
    /// ガラス片を安全に渡れるように
    /// </summary>
    public void SafeGlassComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(breakerComment);
        breakerCommentText.text = "廊下を安全に渡れる！";
    }
    /// <summary>
    /// 窓を壊そう
    /// </summary>
    public void NormalWindowComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "窓が開かないみたい...\n窓を壊して脱出できないかな？";
    }
    /// <summary>
    /// 雨に濡れないようにしよう
    /// </summary>
    public void BreakWindowComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "外は雨が降っている...\n雨に濡れたくないけど、どうしよう？";
    }
    /// <summary>
    /// 家を出れた
    /// </summary>
    public void LeaveHouseComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(breakerComment);
        breakerCommentText.text = "外に出れた！！！";
    }
    /// <summary>
    /// 解決できた！
    /// </summary>
    /// <returns></returns>
    public IEnumerator HappySolution()
    {
        troubleSweatImage.enabled = false;
        CommentHidden();
        GameState.Instance.SetState(GameState.State.Happy);
        PlayerSplineState.Instance.SetHappyImage();
        happyStarImage.enabled = true;
        SoundManager.Instance.PlaySE(SESource.happy);
        yield return new WaitForSeconds(displayStarTime);
        happyStarImage.enabled = false;
        GameState.Instance.SetState(GameState.State.GameScene);
        yield break;
    }
}
