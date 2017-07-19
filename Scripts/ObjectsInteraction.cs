using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteraction : MonoBehaviour {

    public LayerMask blockingLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();

        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	       
           
           
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.SetActive(false);
            // inventory = add new wood/food item
        }
    }
}
