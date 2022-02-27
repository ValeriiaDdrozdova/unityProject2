using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContrl : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource player;

    // Start is called before the first frame update
    public void PunchSound()
    {
        player.PlayOneShot(clips[Random.Range(0, 3)]);
    }
}
