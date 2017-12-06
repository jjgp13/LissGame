using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsScrollList : MonoBehaviour {

    public Button questionPrefab;
    public Transform contentPanel;
    public Text countAnserws;

    public GameObject askPanel;
    public Button[] answerButtons;
    public Text questionText;
    public Text[] textAnswerButtons;
    public Sprite cAnsSprite, iAnsSprite;
    public Sprite[] colorButtonSprites;
    private int activeQuestionNumber;

    public Question[] questionsInfo;

    


    // Use this for initialization
    void Start () {
        addQuestions();
	}
	
	
    private void addQuestions()
    {
        for (int i = 0; i < questionsInfo.Length; i++)
        {
            //Save the prefab in a new gameobject and set it child of the content panel (alignment)
            Button question = Instantiate(questionPrefab);
            question.transform.SetParent(contentPanel);
            //Change its name to get a reference and color.
            question.name = i.ToString();
            question.GetComponent<Image>().sprite = colorButtonSprites[Random.Range(0, 10)];

            //Set number of question.
            int qNumber = i + 1;
            question.GetComponent<SampleQuestion>().questionNumber.text = qNumber.ToString();
            
            //Set Question info in the button game object.
            SetInfoInTheButton(question, questionsInfo[i]);
            question.onClick.AddListener(delegate { AskPanelBehavior(question); });
        }
    }

    //Show question panel and fill its buttons.
    public void AskPanelBehavior(Button qButton)
    {
        if (askPanel.activeSelf == true) askPanel.SetActive(false);
        else {
            askPanel.SetActive(true);
            SetPanelQuestionInfo(qButton);
        }
    }

    public void CheckAnswer(int answerNumber)
    {
        if(answerNumber == activeQuestionNumber)
        {
            Debug.Log("Correcto");

        }
        else
        {
            Debug.Log("Incorrecto");
        }
    }

    //Function to execute when the button is pressed.
    public void SetPanelQuestionInfo(Button questionButton)
    {
        questionText.text = questionButton.GetComponent<SampleQuestion>().questionStruct.question;
        activeQuestionNumber = questionButton.GetComponent<SampleQuestion>().questionStruct.correctAnswer;
        for (int i = 0; i < textAnswerButtons.Length; i++)
            textAnswerButtons[i].text = questionButton.GetComponent<SampleQuestion>().questionStruct.answers[i];
    }

    //Load the information in the button when the scene is loaded.
    public void SetInfoInTheButton(Button qBtn, Question qInfo)
    {
        qBtn.GetComponent<SampleQuestion>().questionStruct.question = qInfo.question;
        qBtn.GetComponent<SampleQuestion>().questionStruct.correctAnswer = qInfo.correctAnswer;
        for (int i = 0; i < qInfo.answers.Length; i++) qBtn.GetComponent<SampleQuestion>().questionStruct.answers[i] = qInfo.answers[i];
    }

    //Get the player advance when the scene is loaded.
    public void GetSavedAnserws()
    {
        for (int i = 0; i < questionsInfo.Length; i++)
        {
            if (!PlayerPrefs.HasKey(i.ToString())) PlayerPrefs.SetString(i.ToString(), "No");
            else
            {
                if (PlayerPrefs.GetString(i.ToString()) == "Correct")
                    GameObject.Find(i.ToString()).transform.GetChild(1).GetComponent<Image>().sprite = cAnsSprite;
                else
                    GameObject.Find(i.ToString()).transform.GetChild(1).GetComponent<Image>().sprite = iAnsSprite;
            }
        }
    }

    public void DisEnableAnswerButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++) answerButtons[i].enabled = false;
    }
}
