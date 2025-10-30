using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// �Ƃ̏��
/// </summary>
public class HouseState : MonoBehaviour
{
    public static HouseState Instance;

    [Header("�K���X��")]
    [SerializeField] private GameObject pieceOfGlass;
    private float pieceOfGlassAlpha = 0.4f;
    [Header("��")]
    [SerializeField] private GameObject window;
    private float windowAlpha = 0.4f;

    public bool IsFixRadio {  get; private set; }
    public bool IsFixBreaker { get; private set; }
    public bool IsSafeGlass{ get; private set; }
    public bool IsBreakWindow { get; private set; }
    public bool IsWearRainCoat {  get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    /// <summary>
    /// ���W�I�𒼂�
    /// </summary>
    public void FixRadio()
    {
        IsFixRadio = true;
    }
    /// <summary>
    /// �u���[�J�[���グ��
    /// </summary>
    public void FixBreaker()
    {
        IsFixBreaker = true;
    }
    /// <summary>
    /// �K���X�����S�ɂ���
    /// </summary>
    public void SafeGlass()
    {
        IsSafeGlass = true;

        Collider2D _glassCollider = pieceOfGlass.gameObject.GetComponent<Collider2D>();
        _glassCollider.isTrigger = true;

        SpriteRenderer _glassSpriteRenderer = pieceOfGlass.gameObject.GetComponent<SpriteRenderer>();
        _glassSpriteRenderer.color = new Color(_glassSpriteRenderer.color.r, _glassSpriteRenderer.color.g, _glassSpriteRenderer.color.b, pieceOfGlassAlpha);
    }
    /// <summary>
    /// ������
    /// </summary>
    public void BreakWindow()
    {
        IsBreakWindow = true;

        SpriteRenderer _windowRenderer = window.gameObject.GetComponent<SpriteRenderer> ();
        _windowRenderer.color = new Color(_windowRenderer.color.r, _windowRenderer.color.g, _windowRenderer.color.b, windowAlpha);
    }
    /// <summary>
    /// ���C���R�[�g�𒅂�
    /// </summary>
    public void WearRainCoat()
    {
        IsWearRainCoat = true;
        window.SetActive(false);
    }
}
