using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerLimited : MonoBehaviour
{
    [Header("�u��[���v�\������")]
    [SerializeField] private float readyWaitTime = 2.0f;
    [Header("�u�X�^�[�g�I�v�\������")]
    [SerializeField] private float goWaitTime = 2.0f;
    [Header("��������")]
    [SerializeField] private float stageTime = 180f;
    [Header("ReadyGo�̃e�L�X�g")]
    [SerializeField] private TextMeshProUGUI readygoText;
    [Header("�������Ԃ̃e�L�X�g")]
    [SerializeField] private TextMeshProUGUI timerText;

    private float minute = 60;
    private float second = 60;

    // Start is called before the first frame update
    void Start()
    {
        TimerDisplay(stageTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.Instance.IsReady())
        {
            if(readyWaitTime > 0)
            {
                readyWaitTime -= Time.deltaTime;
                readygoText.text = "��[��";
            }
            else
            {
                goWaitTime -= Time.deltaTime;
                readygoText.text = "�X�^�[�g!";
                if(goWaitTime <= 0)
                {
                    GameState.Instance.SetState(GameState.State.GameScene);
                    readygoText.text = "";
                }
            }
        }
        else if(GameState.Instance.IsGameScene())
        {
            if (stageTime > 0)
            {
                stageTime -= Time.deltaTime;
                TimerDisplay(stageTime);
            }
            else if(stageTime < 0)
            {
                stageTime = 0;
                TimerDisplay(stageTime);
                GameResult.Instance.GameFailed();
            }
        }
    }
    /// <summary>
    /// ���Ԃ��e�L�X�g�ɐݒ�
    /// </summary>
    /// <param name="_time">����</param>
    private void TimerDisplay(float _time)
    {
        int _minutes = Mathf.FloorToInt(_time / minute);
        int _seconds = Mathf.FloorToInt(_time % second);
        timerText.text = string.Format("{0}:{1:00}", _minutes, _seconds);
    }
}
