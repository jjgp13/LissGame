﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


    public Text dialogText;
    public GameObject face;
    public Animator anim;
    public AudioSource source;
	private Queue<Sentence> sentencesInQ;
    private string actualEmotion;
    public Button nextDialogButton;
    public Animator DialogBoxAnimator;

	// Use this for initialization
	void Start () {
		sentencesInQ = new Queue<Sentence> ();
        anim = face.GetComponent<Animator>();
        source = face.GetComponent<AudioSource>();
        actualEmotion = "";
        nextDialogButton.gameObject.SetActive(false);
    }

	public void StartDialogue (Dialogue dialogue){
        sentencesInQ.Clear();
        gameObject.GetComponent<AudioSource>().Play();
        DialogBoxAnimator.SetBool("isOpen", true);
        foreach (Sentence sentence in dialogue.sentences)
        {
            sentencesInQ.Enqueue(sentence);
        }
        Invoke("DisplayNextSentence", 6f);
    }

    public void DisplayNextSentence()
    {
        if(sentencesInQ.Count == 0)
        {
            EndDialogue();
            return;
        }
        source.Play();
        Sentence sentenceObj = sentencesInQ.Dequeue();
        string sentence = sentenceObj.message;
        string feeling = sentenceObj.emotion;
        float sentenceSpeed = sentenceObj.time;
        AudioClip sound = sentenceObj.soundEmotion;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, feeling, sentenceSpeed, sound));
    }

    IEnumerator TypeSentence(string sentence, string feeling, float time, AudioClip sound)
    {
        anim.SetBool("Talking", true);
        if (actualEmotion == "") actualEmotion = feeling;
        else
        {
            anim.SetBool(actualEmotion, false);
            actualEmotion = feeling;
        }
        nextDialogButton.gameObject.SetActive(false);
        dialogText.text = "";
        source.Play();
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(time);
        }
        anim.SetBool("Talking", false);
        anim.SetBool(feeling, true);
        source.Stop();
        source.PlayOneShot(sound);
        nextDialogButton.gameObject.SetActive(true);
    }

    void EndDialogue()
    {
        Debug.Log("No hay mas dialogos");
    }
}