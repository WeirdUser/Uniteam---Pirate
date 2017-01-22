using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRock : MonoBehaviour {

    private AudioSource clip;

    void Awake()
    {
        clip = GetComponent<AudioSource>();
        clip.Play();
    }
}
