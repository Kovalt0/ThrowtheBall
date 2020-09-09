using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Ball ball;
    public GameObject playerCamera;

    public float ballDistance = 2.25f;
    public float ballThrowingForce = 550f;

    public bool holdingBall = true;

    // Start is called before the first frame update

    void Start() {
        ball.GetComponent<Rigidbody>().useGravity = false;
        playerCamera.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        playerCamera.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update() {
        //ballThrowingForce = 550f;
        if (holdingBall) {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetMouseButtonDown(0)) {
                holdingBall = false;
               

            }
        }


    }
    public void thro()
    {
        ball.ActivateTrail();
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);

    }
}