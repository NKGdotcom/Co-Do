using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    ///�C���X�y�N�^�[����public�Ő錾�����ϐ��ɑΉ�������̂��A�^�b�`���Ȃ��Ɠ����Ȃ��̂Œ���!!!

    //Timer:�������Ԃ̕b�� WaitTime:�J�E���g�_�E���J�n�܂ł̗P�\�̕b�� StartAppearTime:StartObj(���Ő錾���Ă���GameObject)��������܂ł̕b��
    public float timer, WaitTime, StartAppearTime;
    float second, minutes, defaultTime;
    //TimerTxt:�^�C�}�[�Ƃ��Ďg���e�L�X�g
    public TextMeshProUGUI TimerTxt;
    //ReadyObj:�J�E���g�_�E���J�n�܂ł̊Ԃɕ\������I�u�W�F�N�g StartObj:�X�^�[�g���ɕ\������I�u�W�F�N�g
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