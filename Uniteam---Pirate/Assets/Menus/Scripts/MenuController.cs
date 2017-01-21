using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

    // Private
    private CanvasGroup _canvasGroup;
    private bool _isOpen = false;
   
    // Called before Start()
    void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
        _canvasGroup = GetComponent<CanvasGroup>();
        setIsOpen(false);
    }


    // SETTERS
    public void setIsOpen(bool value)
    {
        _isOpen = value;
        if (_isOpen)
        {
            _canvasGroup.alpha = 1;
        }
        else
        {
            _canvasGroup.alpha = 0;
            
        }
        _canvasGroup.interactable = value;
        _canvasGroup.blocksRaycasts = value;
    }   

    // GETTERS
    public bool getIsOpen()
    {
        return _isOpen;
    }
}
