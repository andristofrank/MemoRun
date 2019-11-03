using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour {

   
    [SerializeField]GameObject exitTest;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
            exitTest.SetActive(true);
    }

}
