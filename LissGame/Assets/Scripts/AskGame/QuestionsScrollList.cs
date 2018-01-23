using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionsScrollList : MonoBehaviour {

    public Button questionPrefab;
    public Button returnMainMenuButton;
    public Transform contentPanel;
    public Text countAnserws;

    public GameObject askPanel;
    public Button[] answerButtons;
    public Text questionText;
    public Text[] textAnswerButtons;
    public Sprite cAnsSprite, iAnsSprite;
    public Sprite[] colorButtonSprites;
    private int activeQuestionNumber;
    private int activeCorrectAnswer;
    private int cAns, iAns;

    public Question[] questionsInfo;

    // Use this for initialization
    void Start () {
        addQuestions();
        GetSavedAnserws();
        //PlayerPrefs.DeleteAll();
        //Get total answers
        if (!PlayerPrefs.HasKey("cAns")) PlayerPrefs.SetInt("cAns", 0);
        if (!PlayerPrefs.HasKey("iAns")) PlayerPrefs.SetInt("iAns", 0);
        cAns = PlayerPrefs.GetInt("cAns");
        iAns = PlayerPrefs.GetInt("iAns");

        ShowAnsCount();
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

    //Execute when a answer button is pressed.
    public void CheckAnswer(int answerNumber)
    {
        Image ansStateImage = GameObject.Find(activeQuestionNumber.ToString()).transform.GetChild(1).GetComponent<Image>();
        ansStateImage.enabled = true;
        DisEnableAnswerButtons(false);
        if (answerNumber == activeCorrectAnswer)
        {
            ansStateImage.sprite = cAnsSprite;
            PlayerPrefs.SetString(activeQuestionNumber.ToString(), "Correct");
            cAns++;
            PlayerPrefs.SetInt("cAns", cAns);
            ShowAnsCount();
        }
        else
        {
            ansStateImage.sprite = iAnsSprite;
            PlayerPrefs.SetString(activeQuestionNumber.ToString(), "Incorrect");
            iAns++;
            PlayerPrefs.SetInt("iAns", iAns);
            ShowAnsCount();
        }
    }

    //Function to execute when the question button is pressed.
    public void SetPanelQuestionInfo(Button questionButton)
    {
        questionText.text = questionButton.GetComponent<SampleQuestion>().questionStruct.question;
        activeQuestionNumber = int.Parse(questionButton.name);
        activeCorrectAnswer = questionButton.GetComponent<SampleQuestion>().questionStruct.correctAnswer;

        if (PlayerPrefs.GetString(activeQuestionNumber.ToString()) == "NoAns") DisEnableAnswerButtons(true);
        else DisEnableAnswerButtons(false);

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
            if (!PlayerPrefs.HasKey(i.ToString())) PlayerPrefs.SetString(i.ToString(), "NoAns");
            else
            {
                Image ansStatus = GameObject.Find(i.ToString()).transform.GetChild(1).GetComponent<Image>();
                ansStatus.enabled = true;

                if (PlayerPrefs.GetString(i.ToString()) == "NoAns") ansStatus.enabled = false;
                else if (PlayerPrefs.GetString(i.ToString()) == "Correct") ansStatus.sprite = cAnsSprite;
                else ansStatus.sprite = iAnsSprite;
            }
        }
    }

    public void DisEnableAnswerButtons(bool enabled)
    {
        for (int i = 0; i < answerButtons.Length; i++) answerButtons[i].interactable = enabled;
    }

    public void ShowAnsCount()
    {
        countAnserws.text = "Correctas : " + PlayerPrefs.GetInt("cAns") + "\nIncorrectas : " + PlayerPrefs.GetInt("iAns");
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}