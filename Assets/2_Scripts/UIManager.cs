using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image scorelmg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    [SerializeField] private Image timerlmg;
    [SerializeField] private TextMeshProUGUI timerTmp;

    private void Awake()
    {
        Instance = this;
    }

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore}/{maxScore}";
        scorelmg.fillAmount = (float)currentScore / maxScore;
    }

    public void OnTimerChange(float currentTimer, float maxTimer)
    {
        timerTmp.text = $"{currentTimer:N1} / {maxTimer:N1}";
        timerlmg.fillAmount = (float)currentTimer / maxTimer;
    }
}
