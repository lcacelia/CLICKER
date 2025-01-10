using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sauvegarde : MonoBehaviour
{
    // R�f�rences publiques pour les boutons
    public Button saveButton;
    public Button loadButton;
    public Button saveAndQuitButton;

    // R�f�rence au script Clicker
    public Clicker managerReference;

    private void Start()
    {
        // Ajouter les listeners aux boutons
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SaveData);
        }

        if (loadButton != null)
        {
            loadButton.onClick.AddListener(LoadData);
        }

        if (saveAndQuitButton != null)
        {
            saveAndQuitButton.onClick.AddListener(SaveAndQuit);
        }
    }

    // M�thode pour sauvegarder les donn�es
    public void SaveData()
    {
        PlayerPrefs.SetFloat("CurrentScore", managerReference.currentScore);
        PlayerPrefs.SetFloat("ClickValue", managerReference.clickValue);
        PlayerPrefs.SetFloat("AutoClickValue", managerReference.autoClickValue);

        Debug.Log("Donn�es sauvegard�es !");
    }

    // M�thode pour charger les donn�es
    public void LoadData()
    {
        managerReference.currentScore = PlayerPrefs.GetFloat("CurrentScore", 0);
        managerReference.clickValue = PlayerPrefs.GetFloat("ClickValue", 1);
        managerReference.autoClickValue = PlayerPrefs.GetFloat("AutoClickValue", 0);

        Debug.Log("Donn�es charg�es !");
    }

    // M�thode pour sauvegarder et quitter vers la sc�ne 0
    public void SaveAndQuit()
    {
        SaveData();
        SceneManager.LoadScene(0);
    }
}
