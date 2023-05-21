using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync(2);
        SceneManager.LoadSceneAsync(3);
    }
}
