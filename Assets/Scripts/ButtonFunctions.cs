using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.eraseLevelObjectives();
        Dictionary<string, Vector3> levelStartingPositions = Constants.getLevelStartingPositions();

        Debug.Log("CALLER: " + gameObject.name.ToLower());
        SceneManager.LoadScene(sceneName: "Coin_Collection");
        Constants.playerPos = levelStartingPositions[gameObject.name.ToLower()];
    }

    public void goToMainMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("AudioManager"));
        GameManager.eraseLevelObjectives();
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        SceneManager.LoadScene(sceneName: "Coin_Collection");
    }

    public void exposeLevelButtons()
    {
        Dictionary<string, bool> unlockedLevels = GameManager.getUnlockedLevels();

        foreach (var level in unlockedLevels)
        {
            if (level.Value)
            {
                Debug.Log(level.Key + "Btn");
                GameObject.FindGameObjectWithTag(level.Key + "Btn").GetComponent<Button>().interactable = true;
            }
        }
    }
}
