using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class QuizManager : MonoBehaviour
{
    public List<QnA> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject Quizpanel;
    public GameObject GoPanel;
    public Text QuestionTxt;
    public Text ScoreTxt;
    public int totalQuestions = 5;
    public int score;
    public int count = 0;

    private void Start()
    {
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void GamOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        StateValueConrtoller.stateValue += (score*3); 
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void SetAnswer()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
        count += 1;
    }

    public void generateQuestion()
    {
        if(count == totalQuestions)
        {
            GamOver();
        }
        else if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].question;

            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");
            GamOver();
        }
    }
}
