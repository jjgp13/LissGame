using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public Button startButton;
    public GameObject dialogUI;

    public void TriggerDialogue(){
        gameObject.SetActive(true);
        dialogUI.SetActive(true);
        startButton.gameObject.SetActive(false);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
