using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [Header("�v���C���[�̊���������C���X�g(���Ɗ�)")]
    [SerializeField] private SpriteRenderer happyStarImage;
    [SerializeField] private SpriteRenderer troubleSweatImage;

    [Header("�R�����g")]
    [SerializeField] private GameObject radioComment;
    private TextMeshProUGUI radioCommentText;
    [SerializeField] private GameObject breakerComment;
    private TextMeshProUGUI breakerCommentText;
    [SerializeField] private GameObject entranceComment;
    [SerializeField] private GameObject windowComment;
    private TextMeshProUGUI windowCommentText;
    [SerializeField] private GameObject pieceOfGlassComment;
    private TextMeshProUGUI pieceOfGlassCommentText;

    [Header("�e�L�X�g���u���Ă���K�w")]
    [SerializeField] private int textHierarchy = 1;

    [Header("�����\������鐢�E")]
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
    /// �e�L�X�g�������擾
    /// </summary>
    /// <param name="_commentUI"></param>
    /// <param name="_commentText"></param>
    private void GetText(GameObject _commentUI, ref TextMeshProUGUI _commentText)
    {
        Transform _child = _commentUI.transform.GetChild(textHierarchy);
        _commentText = _child.GetComponent<TextMeshProUGUI>();
    }
    /// <summary>
    /// �R�����gUI��\��
    /// </summary>
    /// <param name="_commentUI"></param>
    public void CommentDisplay(GameObject _commentUI)
    {
        _commentUI.SetActive(true);
    }
    /// <summary>
    /// �R�����gUI���B��
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
    /// ���W�I�������Ȃ�
    /// </summary>
    public void NotHearRadioComment()
    {
        troubleSweatImage.enabled = true;
        troubleSweatImage.gameObject.SetActive(true);
        CommentDisplay(radioComment);
        PlayerSplineState.Instance.SetTroubleImage();
        radioCommentText.text = "���W�I��...\n���������̂ɓd�r���؂�Ă�...";
    }
    /// <summary>
    /// ���W�I�ɓd������ꂽ
    /// </summary>
    public void FixRadioComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(radioComment);
        radioCommentText.text = "����ň��S�ɔ��ł��������I";
    }
    /// <summary>
    /// �u���[�J�[��������
    /// </summary>
    public void TripBreakerComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "�u���[�J�[���B�����ē͂��Ȃ�";
    }
    /// <summary>
    /// �u���[�J�[�𒼂�
    /// </summary>
    public void FixBreakerComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(breakerComment);
        breakerCommentText.text = "�u���[�J�[�𗎂Ƃ����B\n�Ύ��𖢑R�ɖh�����I";
    }
    /// <summary>
    /// �Ƃ���o��Ȃ�
    /// </summary>
    public void NotLeaveHouseComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(entranceComment);
        PlayerSplineState.Instance.SetTroubleImage();
    }
    /// <summary>
    /// �K���X�Ђ������Ċ댯
    /// </summary>
    public void DangerGlassComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "�I�����ăK���X���U���Ă���...";
    }
    /// <summary>
    /// �K���X�Ђ����S�ɓn���悤��
    /// </summary>
    public void SafeGlassComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(breakerComment);
        breakerCommentText.text = "�L�������S�ɓn���I";
    }
    /// <summary>
    /// �����󂻂�
    /// </summary>
    public void NormalWindowComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "�����J���Ȃ��݂���...\n�����󂵂ĒE�o�ł��Ȃ����ȁH";
    }
    /// <summary>
    /// �J�ɔG��Ȃ��悤�ɂ��悤
    /// </summary>
    public void BreakWindowComment()
    {
        troubleSweatImage.enabled = true;
        CommentDisplay(breakerComment);
        PlayerSplineState.Instance.SetTroubleImage();
        breakerCommentText.text = "�O�͉J���~���Ă���...\n�J�ɔG�ꂽ���Ȃ����ǁA�ǂ����悤�H";
    }
    /// <summary>
    /// �Ƃ��o�ꂽ
    /// </summary>
    public void LeaveHouseComment()
    {
        happyStarImage.enabled = true;
        CommentDisplay(breakerComment);
        breakerCommentText.text = "�O�ɏo�ꂽ�I�I�I";
    }
    /// <summary>
    /// �����ł����I
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
