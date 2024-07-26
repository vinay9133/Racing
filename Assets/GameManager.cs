
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text coinCountText; // Reference to the UI text that shows the number of coins collected
    private int coinsCollected = 0; // Counter for collected coins

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Ensure this GameObject persists across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void CollectCoin()
    {
        coinsCollected++;
        UpdateCoinCountUI();
    }

    void UpdateCoinCountUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coins: " + coinsCollected.ToString();
        }
    }
}
