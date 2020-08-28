using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        SceneManager.LoadScene("GameOver");
    }
}
