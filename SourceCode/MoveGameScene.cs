using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGameScene : MonoBehaviour
{
    public void OnClick()
    {
       //シーン移動を行う
        SceneManager.LoadScene("SampleScene");
    }
}
