using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenController : MonoBehaviour
{

    public GameObject _playerReadyMenu;
    public GameObject _canvas;
    public MenuController _menuControllerScript;
    public AudioClip _audioClip;

    // Update is called once per frame
    void Update()
    {
        if (_menuControllerScript.GetIsOpen())
        {
            if (Input.anyKeyDown)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(_audioClip, 1f);
                _canvas.GetComponent<MenuManager>().ChangeMenu(_playerReadyMenu);
            }
        }
    }

    public void Init()
    {
        Input.ResetInputAxes();
    }
}