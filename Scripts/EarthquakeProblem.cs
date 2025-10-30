using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EarthquakeProblem : MonoBehaviour
{
    public static EarthquakeProblem Instance { get; private set; }

    [Header("解決すべき問題を視覚的に見せるテキスト")]
    [SerializeField] private TextMeshProUGUI problemText;

    [Header("解決すべき問題の数")]
    [SerializeField] private int maxProblemNum = 3;
    private int nowProblemNum = 0; //現在の解決した問題数

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateSolutionText();
    }
    /// <summary>
    /// 解決した時
    /// </summary>
    public void OneSolution()
    {
        if(nowProblemNum < maxProblemNum)
        {
            nowProblemNum++;
        }
        UpdateSolutionText();
    }
    /// <summary>
    /// 解決すべき問題
    /// </summary>
    private void UpdateSolutionText()
    {
        problemText.text = $"解決すべき問題：{nowProblemNum}/{maxProblemNum}";
    }
    /// <summary>
    /// 全ての問題を解決
    /// </summary>
    public bool AllSolution()
    {
        return nowProblemNum >= maxProblemNum;
    }
    
}
