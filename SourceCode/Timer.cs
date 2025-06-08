using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    ///インスペクターからpublicで宣言した変数に対応するものをアタッチしないと動かないので注意!!!

    //Timer:制限時間の秒数 WaitTime:カウントダウン開始までの猶予の秒数 StartAppearTime:StartObj(下で宣言しているGameObject)が消えるまでの秒数
    public float timer, WaitTime, StartAppearTime;
    float second, minutes, defaultTime;
    //TimerTxt:タイマーとして使うテキスト
    public TextMeshProUGUI TimerTxt;
    //ReadyObj:カウントダウン開始までの間に表示するオブジェクト StartObj:スタート時に表示するオブジェクト
    public GameObject ReadyObj, StartObj,finishObj;
    bool isStart;
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        defaultTime = timer;
        second = Mathf.Floor(Mathf.Repeat(timer, 60));
        minutes = Mathf.Floor((timer) / 60);
        TimerTxt.SetText(minutes.ToString("f0") + ":" + second.ToString("00"));
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        WaitTime -= Time.deltaTime;
        if (WaitTime > 0f)
        {
            ReadyObj.SetActive(true);
            StartObj.SetActive(false);
        }
        else
        {
            ReadyObj.SetActive(false);
            timer -= Time.deltaTime;
            if (timer > defaultTime - StartAppearTime)
            {
                StartObj.SetActive(true);
            }
            else
            {
                StartObj.SetActive(false);
            }
            if (timer > 0f)
            {
                second = Mathf.Floor(Mathf.Repeat(timer + 1, 60));
                minutes = Mathf.Floor((timer + 1) / 60);
                TimerTxt.SetText(minutes.ToString("f0") + ":" + second.ToString("00"));
            }
            else
            {
                TimerTxt.SetText("0:00");
                finishObj.SetActive(true);
                audioSource.PlayOneShot(sound1);
                Time.timeScale = 0;
            }
        }
    }
}