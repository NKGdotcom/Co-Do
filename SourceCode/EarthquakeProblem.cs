using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EarthquakeProblem : MonoBehaviour
{
    public static EarthquakeProblem Instance { get; private set; }

    [Header("�������ׂ��������o�I�Ɍ�����e�L�X�g")]
    [SerializeField] private TextMeshProUGUI problemText;

    [Header("�������ׂ����̐�")]
    [SerializeField] private int maxProblemNum = 3;
    private int nowProblemNum = 0; //���݂̉���������萔

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
    /// ����������
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
    /// �������ׂ����
    /// </summary>
    private void UpdateSolutionText()
    {
        problemText.text = $"�������ׂ����F{nowProblemNum}/{maxProblemNum}";
    }
    /// <summary>
    /// �S�Ă̖�������
    /// </summary>
    public bool AllSolution()
    {
        return nowProblemNum >= maxProblemNum;
    }
    
}
