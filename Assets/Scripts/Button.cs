using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    static int currentLevel = 2;

    // Start is called before the first frame update
    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    } 

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        currentLevel++;
        Debug.Log(currentLevel);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }


    public void LoadInfo()
    {
        SceneManager.LoadScene(1);
    }

    public void FirstLevel()
    {
        Debug.Log(currentLevel);
        SceneManager.LoadScene(currentLevel);
    }
}
