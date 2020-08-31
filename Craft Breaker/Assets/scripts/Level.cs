﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int numberOfBlocks;
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    SceneLoader sceneLoader;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void countBreakableBlocks()
    {
        numberOfBlocks++;
    }

    public void brickBroken()
    {
        numberOfBlocks--;
        if (numberOfBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void scoreIncrease()
    {

        score++;
     
        scoreText.text = score.ToString();
    }
    public string startScore()
    {
        return score.ToString();
    }
}
