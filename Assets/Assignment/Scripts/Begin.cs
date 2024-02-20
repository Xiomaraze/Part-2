using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Begin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
