using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    [SerializeField] AudioClip hitBrickSound;
    [SerializeField] AudioClip outOfBoundsSound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int type)
    {
        if (type == 0) audioSource.PlayOneShot(hitBrickSound);
        if (type == 1) audioSource.PlayOneShot(outOfBoundsSound);
    }
}
