using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// 家の状態
/// </summary>
public class HouseState : MonoBehaviour
{
    public static HouseState Instance;

    [Header("ガラス片")]
    [SerializeField] private GameObject pieceOfGlass;
    private float pieceOfGlassAlpha = 0.4f;
    [Header("窓")]
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
    /// ラジオを直す
    /// </summary>
    public void FixRadio()
    {
        IsFixRadio = true;
    }
    /// <summary>
    /// ブレーカーを上げる
    /// </summary>
    public void FixBreaker()
    {
        IsFixBreaker = true;
    }
    /// <summary>
    /// ガラスを安全にする
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
    /// 窓を壊す
    /// </summary>
    public void BreakWindow()
    {
        IsBreakWindow = true;

        SpriteRenderer _windowRenderer = window.gameObject.GetComponent<SpriteRenderer> ();
        _windowRenderer.color = new Color(_windowRenderer.color.r, _windowRenderer.color.g, _windowRenderer.color.b, windowAlpha);
    }
    /// <summary>
    /// レインコートを着る
    /// </summary>
    public void WearRainCoat()
    {
        IsWearRainCoat = true;
        window.SetActive(false);
    }
}
