using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsScrollList : MonoBehaviour {

    public GameObject questionPrefab;
    public Transform contentPanel;
    public Text countAnserws;
    public Button ans0, ans1, ans2, ans3;

    // Use this for initialization
    void Start () {
        addQuestions();
	}
	
	
    private void addQuestions()
    {
        for (int i = 1; i <= 100; i++)
        {
            GameObject question = Instantiate(questionPrefab);
            question.transform.SetParent(contentPanel);
            question.GetComponent<SampleQuestion>().questionNumber.text = i.ToString();
        }
    }
}
