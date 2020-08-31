using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Player player;
    public float resetTimer = 5f;
    public GameObject ballprefab;
    public Ball ball;

    // Start is called before the first frame update
    void Start() {        
    }

    // Update is called once per frame
    void Update()
    {
    
        
            if (player.holdingBall == false) {
            resetTimer -= Time.deltaTime; 
            if (resetTimer <= 0) {
                //SceneManager.LoadScene("Game");
                Instantiate(ballprefab,this.transform.position,this.transform.rotation);
                resetTimer = 5f;
                // player.holdingBall = true;
                ball.GetComponent<Rigidbody>().useGravity = false;
            }
                    }
    
}
}
