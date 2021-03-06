﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Update is called once per frame
    private Rigidbody rb;
    public float speed;
    public Text winText;
    private int count;
    public Text countText;


    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
        
    }
	void FixedUpdate () {
        float moveHorizontal = 0;
        float moveVertical = 0;
        if (Input.touchCount > 0)
        {
            Mathf.Sign(moveHorizontal = Input.touches[0].deltaPosition.x);
            Mathf.Sign(moveVertical = Input.touches[0].deltaPosition.y);
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement *= 0.5f;
        rb.AddForce(movement);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count > 7)
        {
            winText.text = "You win!";
        }
    }
    
}
/*
Destroy(other.gameObject);
if (other.gameObject.CompareTag("player"))
gameObject.SetActive(false);
*/