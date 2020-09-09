using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Ball ball;
    public GameObject playerCamera;

    public float ballDistance = 2.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void respwn()
    {
        ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
    }
}
