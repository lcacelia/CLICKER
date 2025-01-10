using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sauvegarde : MonoBehaviour
{
    // Références publiques pour les boutons
    public Button saveButton;
    public Button loadButton;
    public Button saveAndQuitButton;

    // Référence au script Clicker
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

    // Méthode pour sauvegarder les données
    public void SaveData()
    {
        PlayerPrefs.SetFloat("CurrentScore", managerReference.currentScore);
        PlayerPrefs.SetFloat("ClickValue", managerReference.clickValue);
        PlayerPrefs.SetFloat("AutoClickValue", managerReference.autoClickValue);

        Debug.Log("Données sauvegardées !");
    }

    // Méthode pour charger les données
    public void LoadData()
    {
        managerReference.currentScore = PlayerPrefs.GetFloat("CurrentScore", 0);
        managerReference.clickValue = PlayerPrefs.GetFloat("ClickValue", 1);
        managerReference.autoClickValue = PlayerPrefs.GetFloat("AutoClickValue", 0);

        Debug.Log("Données chargées !");
    }

    // Méthode pour sauvegarder et quitter vers la scène 0
    public void SaveAndQuit()
    {
        SaveData();
        SceneManager.LoadScene(0);
    }
}
