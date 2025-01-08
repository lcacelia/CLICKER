using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    // Score et clics
    public Text scoreText;
    public float currentScore;
    [Header("Clic Settings")]
    [SerializeField] private float clickValue = 1; // Forcé à 1 pour éviter les erreurs
    public float autoClickValue;

    // Bouton principal (Stand)
    public Button mainButton;
    public List<Sprite> mainButtonSprites;

    // Shop 1 (Auto-clicker avec serveur)
    [Header("Shop 1 Settings (Auto-clicker)")]
    public Button shop1Button;
    public Text shop1Text;
    public int initialShop1Price = 50;
    public int shop1PriceIncrement = 50;
    public float autoClickIncrement = 1;
    public List<Image> serverImages;

    // Shop 2 (Amélioration des clics)
    [Header("Shop 2 Settings (Clic Upgrades)")]
    public Button shop2Button;
    public Text shop2Text;
    public int initialShop2Price = 50;
    public int shop2PriceIncrement = 50;
    public List<float> clickUpgrades = new List<float> { 2, 5, 10 };

    private int shop1Level = 0;
    private int shop2Level = 0;

    void Start()
    {
        // Initialisation des valeurs
        currentScore = 0;

        // Forcer la valeur de clickValue à 1 au démarrage
        clickValue = 1;
        Debug.Log("Valeur initiale de clickValue : " + clickValue);

        autoClickValue = 0;

        // Cacher toutes les images des serveurs au début
        foreach (var server in serverImages)
        {
            server.gameObject.SetActive(false);
        }

        // Ajout des listeners pour les boutons
        mainButton.onClick.AddListener(OnClick);
        shop1Button.onClick.AddListener(BuyShop1);
        shop2Button.onClick.AddListener(BuyShop2);

        // Initialisation des textes
        UpdateShopTexts();
    }

    void Update()
    {
        // Ajout des revenus passifs (auto-click)
        currentScore += autoClickValue * Time.deltaTime;

        // Mise à jour des textes UI
        scoreText.text = ((int)currentScore) + " $";
        UpdateShopTexts();
    }

    public void OnClick()
    {
        // Ajout au score lorsque le joueur clique
        currentScore += clickValue;
    }

    public void BuyShop1()
    {
        // Achat du serveur (auto-click)
        int price = GetShop1Price();
        if (currentScore >= price && shop1Level < serverImages.Count)
        {
            currentScore -= price;

            // Cacher l'image du serveur précédent
            if (shop1Level > 0)
            {
                serverImages[shop1Level - 1].gameObject.SetActive(false);
            }

            // Afficher l'image du serveur du niveau actuel
            serverImages[shop1Level].gameObject.SetActive(true);

            // Augmenter le niveau et la valeur d'auto-click
            shop1Level++;
            autoClickValue += autoClickIncrement;

            UpdateShopTexts();
        }
    }

    public void BuyShop2()
    {
        // Achat d'amélioration des clics
        int price = GetShop2Price();
        if (currentScore >= price && shop2Level < clickUpgrades.Count)
        {
            currentScore -= price;

            // Augmenter le niveau et mettre à jour la valeur des clics
            shop2Level++;
            clickValue = clickUpgrades[shop2Level - 1];

            // Changer le sprite du bouton principal (stand)
            if (shop2Level - 1 < mainButtonSprites.Count)
            {
                mainButton.image.sprite = mainButtonSprites[shop2Level - 1];
            }

            UpdateShopTexts();
        }
    }

    // Fonction pour calculer le prix du Shop 1 en fonction du niveau actuel
    private int GetShop1Price()
    {
        return initialShop1Price + (shop1Level * shop1PriceIncrement);
    }

    // Fonction pour calculer le prix du Shop 2 en fonction du niveau actuel
    private int GetShop2Price()
    {
        return initialShop2Price + (shop2Level * shop2PriceIncrement);
    }

    // Mise à jour des textes des shops
    private void UpdateShopTexts()
    {
        shop1Text.text = "Auto-click: " + GetShop1Price() + " $ (Niv " + shop1Level + ")";
        shop2Text.text = "Clic +: " + GetShop2Price() + " $ (Niv " + shop2Level + ")";
    }
}
