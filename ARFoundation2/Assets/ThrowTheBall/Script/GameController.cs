using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Player player;
    public float resetTimer = 5f;
    public GameObject ballprefab;
    public Ball ball;
    //public Ball player.ball;
    //public player.ball;

    /*
    public float ballDistance = 2.25f;
    public float ballThrowingForce = 550f;
    public bool holdingBall = true;
    */

    // Start is called before the first frame update
    void Start() {        
    }

    // Update is called once per frame
    //void Update()
    void FixedUpdate()
    {
    
        
            if (player.holdingBall == false) 
        {
            resetTimer -= Time.deltaTime; 
            if (resetTimer <= 0) {
                //SceneManager.LoadScene("Game");
                player.playerCamera.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                player.playerCamera.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
                Instantiate(ballprefab,this.transform.position,this.transform.rotation);
                resetTimer = 5f;
                player.holdingBall = true;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.transform.parent = player.playerCamera.transform;
                             

                /*
                if (Input.GetMouseButtonDown(0))
                {
                    holdingBall = false;
                    ball.ActivateTrail();
                    ball.GetComponent<Rigidbody>().useGravity = true;
                    ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
                }
                */






            }
                    }
    
}
}
