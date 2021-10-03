using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author’s name - Hardik Dipakbhai Shah 
/// Student Number - 101249099
/// Date last Modified - 10/03/2021
///description and Revision History
/// This code is for changing the scenes 
/// </summary>

public class UIBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIndex;

    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;              // This code will be use to change to next scene
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;          // This code will be used to change to previous scene
    }

    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void OnMainMenuButtonPressed()                                           // This code is to change the scene from GameOverScreen to MenuScreen
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
