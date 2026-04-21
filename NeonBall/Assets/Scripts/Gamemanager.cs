using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI finalCoinsText;

    private int coinCount = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "Coins: " + coinCount;
    }

    public void ShowVictory()
    {
        if (finalCoinsText != null)
            finalCoinsText.text = "Coins Collected: " + coinCount;
    }
}