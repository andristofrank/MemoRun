using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsPicked", true);
        FindObjectOfType<Health>().WinLife();
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        print("yes");
        yield return new WaitForSecondsRealtime(0.5f);
        gameObject.SetActive(false);
        Destroy(this);
        print("No");
    }
}
