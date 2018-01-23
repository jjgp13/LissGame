using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence {

    public string emotion;
    public float time;
    public AudioClip soundEmotion;
    [TextArea(3, 7)]
    public string message;
}
