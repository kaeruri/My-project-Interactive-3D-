using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 1;
    AudioSource collectibleAudio;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectibleAudio.Play();
            Destroy(gameObject, collectibleAudio.clip.length);
        }
    }

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        AudioSource.PlayClipAtPoint(collectibleAudio.clip, transform.position);
        Destroy(gameObject);
    }
}
