using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音を鳴らす処理
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Header("BGMのオーディオ")]
    [SerializeField] private AudioSource bgmAudioSource;
    [Header("SEのオーディオ")]
    [SerializeField] private AudioSource seAudioSource;
    [Header("サウンドデータ")]
    [SerializeField] private SoundList soundList;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("SoundManager instance = null. Setting up.");
            Instance = this;
        }
        else
        {
            Debug.LogError("SoundVolume ScriptableObjectがSoundManagerに割り当てられていません。");
        }
    }
    /// <summary>
    /// BGMを流す
    /// </summary>
    /// <param name="_bgmSource"></param>
    public void PlayBGM(BGMSource _bgmSource)
    {
        SoundList.BGMSoundData bgmData = soundList.GetBGMData(_bgmSource);
        if (bgmData != null && bgmData.BGMAudioClip != null)
        {
            bgmAudioSource.clip = bgmData.BGMAudioClip;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
            Debug.Log($"Playing BGM: {_bgmSource} with volume: {bgmAudioSource.volume}");
        }
        else
        {
            Debug.LogWarning($"BGM {_bgmSource} が見つかりません");
        }
    }
    /// <summary>
    /// SEを流す
    /// </summary>
    /// <param name="_seSource"></param>
    public void PlaySE(SESource _seSource)
    {
        SoundList.SESoundData seData = soundList.GetSEData(_seSource);
        if (seData != null && seData.SEAudioClip != null)
        {
            seAudioSource.PlayOneShot(seData.SEAudioClip);
        }
        else
        {
            Debug.LogWarning($"SE {_seSource} が見つかりません");
        }
    }
}