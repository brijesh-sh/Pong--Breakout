using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneManager: MonoBehaviour
{
    private GameObject _menu;
    // Start is called before the first frame update
    void Start()
    {
        _menu = GameObject.Find("Canvas");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            QuitGame();
        }

        else if (Input.GetKey(KeyCode.A))
        {
             _menu.GetComponent<MenuManager>().LoadSceneA();
        }

        else if (Input.GetKey(KeyCode.B))
        {
            _menu.GetComponent<MenuManager>().LoadSceneB();
        }

    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
    EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }


}
