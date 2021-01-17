using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    //public Animator transition;
    public float transitionTime = 7f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&& SceneManager.GetActiveScene().buildIndex<3)
        {
             LoadGame();
        }
        else if (SceneManager.GetActiveScene().name=="Accident Scene")
        {
            LoadGame();
        }
  
    }

    public void LoadGame()
    {
        StartCoroutine(LoadGame(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadGame(int gameIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        if (gameIndex < 3)
        {
            SceneManager.LoadScene(gameIndex);
        }
        
    }
    public void LoadChosenScene(int gameIndex)
    {
        SceneManager.LoadScene(gameIndex);
        Time.timeScale = 1;

    }
}
