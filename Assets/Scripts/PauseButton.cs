using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour,IPointerDownHandler
{

    

    [SerializeField] GameObject PauseMenu;
    public void OnPointerDown(PointerEventData eventData)
    {
        

        PauseMenu.SetActive(true);
    }
    
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
