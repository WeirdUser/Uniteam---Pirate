using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    // Public 
    public GameObject _firstMenu;

    // Private
    private GameObject _currentMenu;

	// Use this for initialization
	void Start () {
       _firstMenu.GetComponent<MenuController>().SetIsOpen(true);
        _currentMenu = _firstMenu;
	}

    public void ChangeMenu(GameObject menu)
    {
        PlayerReadyController _playerReadyControllerScript = menu.GetComponent<PlayerReadyController>();
        if (_playerReadyControllerScript != null)
        {
            _playerReadyControllerScript.Init();
        }
        HomeScreenController _homeScreenControllerScript = menu.GetComponent<HomeScreenController>();
        if (_homeScreenControllerScript != null)
        {
            _homeScreenControllerScript.Init();
        }

        _currentMenu.GetComponent<MenuController>().SetIsOpen(false);
        _currentMenu = menu;
        _currentMenu.GetComponent<MenuController>().SetIsOpen(true);
    }
}
