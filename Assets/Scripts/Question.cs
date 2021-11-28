using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Question : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField] TextMeshProUGUI questionText = null;
    [SerializeField] QuestionSO questionSo =  null;
    [SerializeField] GameObject[] answers;
    [SerializeField] Sprite defaultButtonSprite;
    [SerializeField] Sprite correctButtonSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    QuestionTimer questionTimer;
    
    void Start()
    {
        questionTimer = FindObjectOfType<QuestionTimer>();
        SetupButtonText();
        SetDefaultSprites();
        SetButtonState(true);
    }

    void Update() {
        timerImage.fillAmount = questionTimer.fillFraction;

        if(questionTimer.loadNextQuestion){
            GetNextQuestion();
            questionTimer.loadNextQuestion = false;
        }
    }

    private void SetupButtonText()
    {
        questionText.text = questionSo.GetQuestion();

        for (int i = 0; i < answers.Length; i++)
        {
            TextMeshProUGUI buttonText = answers[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionSo.GetAnswerByIndex(i);
        }
    }

    public void onAnswerClick(int index){

        SetButtonState(false);

        int correctAnswer = questionSo.GetGetCorrectAnswerIndex();

        if(index == correctAnswer){
            questionText.text = "Correct!";
            Image btnImage = answers[index].GetComponent<Image>();
            btnImage.sprite = correctButtonSprite;
        }else{
            string correctAnswerText = questionSo.GetAnswerByIndex(correctAnswer);
            questionText.text = "Sorry correct anwser was: \n" + correctAnswerText;

            Image btnImage = answers[correctAnswer].GetComponent<Image>();
            btnImage.sprite = correctButtonSprite;
        }
    }

    void SetButtonState(bool isEnabled){
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].GetComponent<Button>().interactable = isEnabled;
        }
    }

    void SetDefaultSprites(){
        for (int i = 0; i < answers.Length; i++){
            answers[i].GetComponent<Image>().sprite = defaultButtonSprite;
        }
    }

    void GetNextQuestion(){

    }
}
