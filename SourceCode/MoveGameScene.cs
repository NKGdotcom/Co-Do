using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGameScene : MonoBehaviour
{
    public void OnClick()
    {
       //�V�[���ړ����s��
        SceneManager.LoadScene("SampleScene");
    }
}
