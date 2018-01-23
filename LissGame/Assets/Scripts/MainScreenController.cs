using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreenController : MonoBehaviour {

    public Animator feelingsUI, asksUI;
    public Text feelingsScore, askingScore;

    private void Start()
    {
        ShowHighScore("feelingsScoreKey", feelingsScore);
        ShowHighScore("cAns", askingScore);
    }

    public void ShowHighScore(string scoreType, Text scoreText)
    {
        if (PlayerPrefs.HasKey(scoreType)) scoreText.text = PlayerPrefs.GetInt(scoreType).ToString();
        else scoreText.text = "0";
    }

    public void openScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
        SetAnimationFalse(feelingsUI);
        SetAnimationFalse(asksUI);
    }

    public void SetAnimationFalse(Animator target)
    {
        target.SetBool("FadeIn", false);
        target.SetBool("InDisplay", false);
        target.SetBool("FadeOut", false);
        target.SetBool("OffDisplay", false);
    }

    public void AnimationIn(Animator target)
    {
        SetAnimationFalse(target);
        target.SetBool("FadeIn", true);
        target.SetBool("InDisplay", true);
    }

    public void AnimationOut(Animator target)
    {
        SetAnimationFalse(target);
        target.SetBool("FadeOut", true);
        target.SetBool("OffDisplay", true);
    }

}