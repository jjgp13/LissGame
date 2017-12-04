using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour {

    public Animator feelingsUI, asksUI;

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