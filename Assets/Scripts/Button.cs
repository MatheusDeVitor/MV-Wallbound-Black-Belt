using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    int currentLevel = 0;

    // Start is called before the first frame update
    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    } 

    public void MainMenu ()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadInfo()
    {
        SceneManager.LoadScene(3);
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
