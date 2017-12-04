using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AskGameExp : MonoBehaviour {

    public Button prevButton, nextButton;
    public Text DialogText;
    public int sentenceIndex;
    [TextArea(3, 7)]
    public string[] dialog;

	// Use this for initialization
	void Start () {
        sentenceIndex = 0;
        DialogText.text = dialog[sentenceIndex];
	}

    private void Update()
    {
        if(sentenceIndex == 8) nextButton.gameObject.SetActive(false);
        else nextButton.gameObject.SetActive(true);
        if (sentenceIndex == 0) prevButton.gameObject.SetActive(false);
        else prevButton.gameObject.SetActive(true);
    }

    public void DisplayNextSentence()
    {
        if (sentenceIndex < 8)
        {
            sentenceIndex++;
            DialogText.text = dialog[sentenceIndex];
        }
    }

    public void DisplayPrevSentence()
    {
        if (sentenceIndex > 0)
        {
            sentenceIndex--;
            DialogText.text = dialog[sentenceIndex];
        }     
    }
}
