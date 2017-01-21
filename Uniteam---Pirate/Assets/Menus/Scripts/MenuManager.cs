using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    // Public 
    public GameObject _firstMenu;

    // Private
    private GameObject _currentMenu;

	// Use this for initialization
	void Start () {
       _firstMenu.GetComponent<MenuController>().setIsOpen(true);
        _currentMenu = _firstMenu;
	}

    public void changeMenu(GameObject menu)
    {
        _currentMenu.GetComponent<MenuController>().setIsOpen(false);
        _currentMenu = menu;
        _currentMenu.GetComponent<MenuController>().setIsOpen(true);
    }
}
