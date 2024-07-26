using UnityEngine;

public class Coin : MonoBehaviour
{
    // This script assumes that the coin is tagged as "Collectible"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify UI or game manager about the coin collection
            GameManager.Instance.CollectCoin(); // Ensure you have a GameManager class with a CollectCoin method

            // Optional: Play a sound effect or particle effect for collecting the coin
            // AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Disable or destroy the coin object
            gameObject.SetActive(false); // or use Destroy(gameObject); if you prefer to remove it from the scene
        }
    }
}
