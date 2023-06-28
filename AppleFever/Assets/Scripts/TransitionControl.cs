using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionControl : MonoBehaviour
{
    private UnloadLogic UnloadLogic;

    void Start()
    {
        UnloadLogic = FindObjectOfType<UnloadLogic>();
    }


    void Update()
    {
        
    }

    public void GameOver()
    {
        UnloadLogic.SaveApples();

        SceneManager.LoadScene("Shop");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
