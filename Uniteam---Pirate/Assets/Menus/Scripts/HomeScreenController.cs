using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenController : MonoBehaviour
{

    public GameObject _playerReadyMenu;
    public GameObject _canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            _canvas.GetComponent<MenuManager>().changeMenu(_playerReadyMenu);
        }
    }
}