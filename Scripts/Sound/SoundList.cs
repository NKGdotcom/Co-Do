using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音を格納する物
/// </summary>
[CreateAssetMenu(fileName = "SoundData", menuName = "Scriptable Objects/SoundData")]
public class SoundList : ScriptableObject
{
    [System.Serializable]
    public class BGMSoundData
    {
        [Header("音の種類")]
        [Tooltip("音の種類を選択し、呼び出す際はこの種類を指定して呼び出す")]
        public BGMSource BGMSource;
        [Header("音のクリップ")]
        [Tooltip("音のクリップを指定し、鳴らしたい音を付ける")]
        public AudioClip BGMAudioClip;

        public BGMSoundData(BGMSource BGMSource, AudioClip BGMAudioClip)
        {
            this.BGMSource = BGMSource;
            this.BGMAudioClip = BGMAudioClip;
        }
    }
    [System.Serializable]
    public class SESoundData
    {
        [Header("音の種類")]
        [Tooltip("音の種類を選択し、呼び出す際はこの種類を指定して呼び出す")]
        public SESource SESource;
        [Header("音のクリップ")]
        [Tooltip("音のクリップを指定し、鳴らしたい音を付ける")]
        public AudioClip SEAudioClip;
        public SESoundData(SESource SESource, AudioClip SEAudioClip)
        {
            this.SESource = SESource;
            this.SEAudioClip = SEAudioClip;
        }
    }
    public List<BGMSoundData> bgmSoundDataList = new List<BGMSoundData>();
    public List<SESoundData> seSoundDataList = new List<SESoundData>();

    public BGMSoundData GetBGMData(BGMSource BGMSource)
    {
        foreach (BGMSoundData bgm in bgmSoundDataList)
        {
            if (bgm.BGMSource == BGMSource)
            {
                return new BGMSoundData(bgm.BGMSource, bgm.BGMAudioClip);
            }
        }
        return null;
    }
    public SESoundData GetSEData(SESource SESource)
    {
        foreach (SESoundData se in seSoundDataList)
        {
            if (se.SESource == SESource)
            {
                return new SESoundData(se.SESource, se.SEAudioClip);
            }
        }
        return null;
    }
}
