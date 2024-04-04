using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image scorelmg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    private void Awake()
    {
        Instance = this;
    }

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore}/{maxScore}";
        scorelmg.fillAmount = (float)currentScore / maxScore;
    }
}
