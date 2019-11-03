using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    BoxCollider2D colision;
    CapsuleCollider2D hurting;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        hurting = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
        die();

    }
    private bool isFacingLeft()
    {
        return transform.localScale.x < 0;//if its facing right returns true, else its facing left
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            transform.localScale = new Vector2((Mathf.Sign(myRigidBody.velocity.x)), 1f);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {


        transform.localScale = new Vector2((Mathf.Sign(myRigidBody.velocity.x)), 1f);

    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //}
    public void die()
    {
        
        if (hurting.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
           
            animator.SetBool("IsDying", true);
           
            StartCoroutine(delay());
            
        }
    }
    IEnumerator delay()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
        gameObject.SetActive(false);
        Destroy(this);
        
    }


}
