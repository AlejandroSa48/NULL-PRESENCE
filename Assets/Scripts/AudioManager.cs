using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hurt;
    public AudioClip coin;
    public AudioClip step;

    void Start()
    {
        GameEvents.Instance.OnDamage.AddListener(PlayHurt);
        GameEvents.Instance.OnHeal.AddListener(PlayCoin);
        GameEvents.Instance.OnSpacePressed.AddListener(PlayStep);
    }

    void PlayHurt()
    {
        audioSource.PlayOneShot(hurt);
    }

    void PlayCoin()
    {
        audioSource.PlayOneShot(coin);
    }

    void PlayStep()
    {
        audioSource.PlayOneShot(step);
    }
}
