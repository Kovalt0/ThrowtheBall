using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;

public class updateLB : MonoBehaviour
{
    //public scoreParser parser;
    public Text pos;
    public Text score;
    public Text namex;
    DataTable leadBoard = new DataTable();
    
    public void LeadBoardSort()
    {
       int totPlayers = PlayerPrefs.GetInt("totPlayers");
        //Debug.Log(totPlayers);
        for (int i = 0; i < totPlayers; i++)
        {
            int score = PlayerPrefs.GetInt("Player" + i.ToString());
            leadBoard.Rows.Add("Player" + i.ToString(), score);
        }
        leadBoard.DefaultView.Sort = "Score desc";
        leadBoard = leadBoard.DefaultView.ToTable();

      
    }

    // Start is called before the first frame update
    void Start()
    {
        leadBoard.Columns.Add("Players");
        leadBoard.Columns.Add("Score", typeof(int));
       /* score = gameObject.GetComponent<Text>();
        pos = gameObject.GetComponent<Text>();
        namex = gameObject.GetComponent<Text>();*/
        LeadBoardSort();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DataRow dataRow in leadBoard.Rows)
        {
            int i = 0;
            //Debug.Log(dataRow);
            foreach (var item in dataRow.ItemArray)
            {
                if (i == 0)
                {
                    Debug.Log("Name" + item);
                    namex.text = item.ToString() + "\n";
                }
                else
                {
                    Debug.Log("Score" + item);
                    score.text = item.ToString() + "\n";
                }
                i++;
                //Debug.Log(item);
            }
        }
    }
}
