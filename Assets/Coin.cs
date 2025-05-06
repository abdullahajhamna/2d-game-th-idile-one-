using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1; // Make sure this is public
    
    // Optional effects
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private GameObject collectEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.CollectCoin(value);
                
                // Play effects
                if (collectSound != null)
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                
                if (collectEffect != null)
                    Instantiate(collectEffect, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
    }
}