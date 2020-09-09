using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public GameObject effectObject;
    public scoreParser parser;
    public Ball ball;
    public GameObject playerCamera;

    public float ballDistance = 2.25f;

    public void UpdateLeadBoard()
    {
        //PlayerPrefs.SetInt(parser.currentPlayerKey, ScoreScript.scoreValue);
        PlayerPrefs.SetInt(parser.currentPlayerKey, Random.Range(1, 20));
    }
    void Start ()
    {
        effectObject.SetActive(false);
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Ball> () != null) 
        {
            effectObject.SetActive(true);

            ScoreScript.scoreValue += 1;
            UpdateLeadBoard();
            Debug.Log("Score!");
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
        }
    }
}
