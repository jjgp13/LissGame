﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LettersController : MonoBehaviour {

	public void openScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}