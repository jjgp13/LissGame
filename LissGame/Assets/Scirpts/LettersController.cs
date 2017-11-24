using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LettersController : MonoBehaviour {

    public Animator noLetterUI;

    public bool[] lettersAvailable;

    public void openScene(int indexScene)
    {
        if(lettersAvailable[indexScene-1] == true)
            SceneManager.LoadScene(indexScene);
        else
        {
            SetAnimationFalse();
            AnimationIn();
        }
    }

    private void SetAnimationFalse()
    {
        noLetterUI.SetBool("FadeIn", false);
        noLetterUI.SetBool("InDisplay", false);
        noLetterUI.SetBool("FadeOut", false);
        noLetterUI.SetBool("OffDisplay", false);
    }

    private void AnimationIn()
    {
        noLetterUI.SetBool("FadeIn", true);
        noLetterUI.SetBool("InDisplay", true);
    }

    public void AnimationOut()
    {
        SetAnimationFalse();
        noLetterUI.SetBool("FadeOut", true);
        noLetterUI.SetBool("OffDisplay", true);
    }
}
