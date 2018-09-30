using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class PlayerAnimationScript : MonoBehaviour {

    public float speed;
    public Rigidbody2D rigid;
    private Animator animator;
    public Text texto;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        //Screen.SetResolution(800, 640, true);
  	}
	
	// Update is called once per frame
	void Update () {
        Touch touch = Input.GetTouch(0);
        texto.text = "x: " + touch.position.x + ", y: " + touch.position.y + "\n" +
            "Screen: " + Screen.width + "x" + Screen.height;
        if(touch.position.x > Screen.width / 2) {
            animator.SetFloat("Movement", 0.2f);
        }
        else {
            animator.SetFloat("Movement", 0.0f);
        }

	}
}
