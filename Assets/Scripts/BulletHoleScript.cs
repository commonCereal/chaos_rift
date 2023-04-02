using System.Collections;
using UnityEngine;

public class BulletHoleScript : MonoBehaviour {
    // [FormerlySerializedAs("gunFiringSound")]
    [Header("Sound")]
    [Tooltip("Sound bullet hole should make")]
    public AudioClip ricochetSound;
    private AudioSource _audioSource;

    [Header("Bullet Hole Settings")]
    [Tooltip("Sound bullet hole should make")]
    public int lifespan = 60;
    
    // Start is called before the first frame update
    public IEnumerator Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null) {
            gameObject.AddComponent<AudioSource>();
            _audioSource = GetComponent<AudioSource>();
        }
        _audioSource.PlayOneShot(ricochetSound);
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
