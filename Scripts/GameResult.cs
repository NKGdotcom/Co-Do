using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameResult : MonoBehaviour
{
    public static GameResult Instance { get; private set; }
    [Header("ゲームクリア演出")]
    [SerializeField] private GameObject gameClear;
    [Header("ゲームオーバー演出")]
    [SerializeField] private GameObject gameFailed;
    public void Awake()
    {
        if(Instance == null) Instance = this;
    }
    private void Update()
    {
        if (!GameState.Instance.IsResult()) return;
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //すべて解決したかどうか
            if (EarthquakeProblem.Instance.AllSolution())
            {
                GameClear();
            }
            else
            {
                GameFailed();
            }

            GameState.Instance.SetState(GameState.State.Result);
        }
    }
    public void GameClear()
    {
        SoundManager.Instance.PlayBGM(BGMSource.gameClearBGM);
        gameClear.gameObject.SetActive(true);
    }
    public void GameFailed()
    {
        SoundManager.Instance.PlayBGM(BGMSource.gameOverBGM);
        gameFailed.gameObject.SetActive(true);
    }
}
