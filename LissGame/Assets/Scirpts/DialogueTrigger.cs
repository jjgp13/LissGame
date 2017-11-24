using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {


    public Button startButton;
    public GameObject dialogUI;
    public Dialogue dialogue;

    public void TriggerDialogue(){
        gameObject.SetActive(true);
        dialogUI.SetActive(true);
        startButton.gameObject.SetActive(false);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
