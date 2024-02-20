using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Begin : MonoBehaviour
{
    // Start is called before the first frame update
    int currentScene;
    int mainScene;
    public string sceneName;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        mainScene = SceneManager.GetSceneByName(sceneName).buildIndex;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(mainScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
