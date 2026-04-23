using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移をするスクリプト
/// 呼び出すのはFadeの方から
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [Header("遷移先のプロジェクト名")]
    [Tooltip("遷移先のシーン名を入力してください")]
    [SerializeField] private string toSceneName;

    /// <summary>
    /// 設定したシーンに遷移する
    /// </summary>
    public void NextSceneTransition()
    {
        SceneManager.LoadScene(toSceneName);
    }
}
