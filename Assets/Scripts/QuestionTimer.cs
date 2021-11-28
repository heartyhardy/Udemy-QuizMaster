using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTimer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToReview = 10f;

    public bool loadNextQuestion;
    public float fillFraction;

    bool isAnswering;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer(){
        timerValue -= Time.deltaTime;

        if(isAnswering){
            if(timerValue > 0){
                fillFraction = timerValue / timeToComplete;
            }else{
                isAnswering = false;
                timerValue = timeToReview;
            }
        }else{
            if(timerValue > 0){
                fillFraction = timerValue / timeToReview;
            }else{
                isAnswering = true;
                timerValue = timeToComplete;
                loadNextQuestion = true;
            }
        }
    }

    public void CancelTimer(){
        timerValue = 0;
    }
}
