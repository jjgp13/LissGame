using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question{
    [TextArea(3, 7)]
    public string question;
    public string[] answers;
    public int correctAnswer;
}
