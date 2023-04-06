using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    public AudioClip pickupSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update() { }
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log($"Item triggered: {gameObject.name}, Colliding object: {other.gameObject.name}");
        if (other.CompareTag("Player")) {
            FirstPersonController player = other.gameObject.GetComponent<FirstPersonController>();
            player.OnItemPickUp();

            // Hide but still exists so sound can play
            GetComponent<Collider>().enabled = false; // Disable the collider to prevent further interactions
            GetComponentInChildren<SpriteRenderer>().enabled = false; // Hide the item sprite
            
            // Destroy when pickup sound completes
            audioSource.PlayOneShot(pickupSound);
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound() {
        while (audioSource.isPlaying) {
            yield return null;
        }
        Destroy(gameObject);
    }
}
