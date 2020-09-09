using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject[] visual;
    

    void Start()
    {
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        //visual = transform.GetChild(0).gameObject;
        //visual1 = transform.GetChild(1).gameObject;
        //hide the placement visual
        visual[0].SetActive(false);
        visual[1].SetActive(false);
        // visual1.SetActive(false);
    }

    void Update()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.All);

        // if we hit an AR plane, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual[0].activeInHierarchy)
            {
                visual[0].SetActive(true);
              }

                if (!visual[1].activeInHierarchy)
                { visual[1].SetActive(true); }

            // if (!visual1.activeInHierarchy)
            //    visual1.SetActive(true);
        }
    }
}
