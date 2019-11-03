using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    [SerializeField]GameObject equation;
    Collider2D mychestCollider;
    Animator myChestAnimator;
	// Use this for initialization
	void Start () {
        mychestCollider = GetComponent<Collider2D>();
        myChestAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        OnTriggerEnter2D(mychestCollider);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            myChestAnimator.SetBool("Touched", true);
            
            equation.SetActive(true);
        }
        else
        {
            myChestAnimator.SetBool("Touched", false);
            equation.SetActive(false);
        }
        
    }
}
