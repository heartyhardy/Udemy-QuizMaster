using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions/New Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "New Question Title";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] [Range(0, 3)] int correctAnswerIndex = 0;

    public string GetQuestion() => this.question;

    public int GetGetCorrectAnswerIndex() => this.correctAnswerIndex;

    public string GetAnswerByIndex(int index) => index >= 0 && index < answers.Length ? answers[index] : null;
}
