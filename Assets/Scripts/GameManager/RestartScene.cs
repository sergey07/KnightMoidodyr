using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        InputYDown();
    }

    private void InputYDown()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameManager.Instance.RestartScene();
        }
    }
}
