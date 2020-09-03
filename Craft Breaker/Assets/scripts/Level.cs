using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int numberOfBlocks;
    int score = 0;
    
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

   
}
