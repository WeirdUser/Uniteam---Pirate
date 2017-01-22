using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRock : MonoBehaviour {

    public AudioSource clip;

    void Awake()
    {
        clip.Play();
    }
}
