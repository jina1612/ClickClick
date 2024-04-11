using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreatScore = 10;
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TimerCouroutine());
    }

    IEnumerator TimerCouroutine()
    {
        float currenTime = 0f;

        while (currenTime < maxTime)
        {
            currenTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currenTime, maxTime);
            yield return null;  
        }

        Debug.Log("Game Over...........");
    }
    internal void CalculateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreatScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
        }
        else
        {
            score--;
        }

        UIManager.Instance.OnScoreChange(this.score,maxScore);
    }
}
