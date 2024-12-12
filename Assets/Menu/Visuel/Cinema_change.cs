using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinema_change : MonoBehaviour
{
    public int numero_scene;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(numero_scene);
    }
}