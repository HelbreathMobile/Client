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
    public Vector3 newPos;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        newPos = transform.position;
        //Screen.SetResolution(800, 640, true);
  	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            texto.text = "x: " + touch.position.x + ", y: " + touch.position.y + "\n" +
                "Screen: " + Screen.width + "x" + Screen.height;
            if (touch.position.x > Screen.width / 2)
            {
                animator.SetFloat("Movement", 0.2f);
                newPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
            else if (touch.position.x < Screen.width / 2)
            {
                animator.SetFloat("Movement", -0.2f);
                newPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }
        float step = 3 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
        Debug.Log("Pos: " + transform.position.x + " Des: " + newPos.x);
        Debug.Log("Dis: " + Vector3.Distance(transform.position, newPos).ToString());
        if (Vector3.Distance(transform.position, newPos) < 0.1f)
        {
            animator.SetFloat("Movement", 0.0f);
        }

	}
}

