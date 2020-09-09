using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Text.RegularExpressions;


public class scoreParser : MonoBehaviour
{
    public int totPlayers;
    int highScore;
    int currentScore;
    string totPlayersKey = "totPlayers";
    public string currentPlayerKey;
    List<int> leadBoardSorted = new List<int>();
    DataTable leadBoard = new DataTable();
    public int currentPlayerNumber;

    public void LeadBoardInit()
    {
        
        if (!PlayerPrefs.HasKey(totPlayersKey)) //If we dont have a key for totPlayers, Create one
        {
            totPlayers = 0;
            PlayerPrefs.SetInt(totPlayersKey, totPlayers); //Init. totPlayers to 0
        }
        else //If PlayerPrefs has a key for totPlayers, store totPlayers
        {
            totPlayers = PlayerPrefs.GetInt(totPlayersKey);
        }
       
    }

    public void LeadBoardAddPlayer()
    {
        currentPlayerNumber = totPlayers + 1;
        currentPlayerKey = "Player" + currentPlayerNumber.ToString();
        totPlayers += 1;
        currentScore = Random.Range(1, 20);
        PlayerPrefs.SetInt(currentPlayerKey, currentScore);
        PlayerPrefs.SetInt(totPlayersKey, totPlayers); //Update totPlayers key
    }

    public void LeadBoardSort()
    {
        
        for (int i = 0; i < totPlayers; i++)
        {
            int score = PlayerPrefs.GetInt("Player" + i.ToString());
            leadBoard.Rows.Add("Player"+i.ToString(),score);
        }
        leadBoard.DefaultView.Sort = "Score desc";
        leadBoard = leadBoard.DefaultView.ToTable();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        LeadBoardInit();
        LeadBoardAddPlayer();
        //LeadBoardSort();
    }
    // Update is called once per frame
    void Update()
    {

        /*foreach (DataRow dataRow in leadBoard.Rows)
        {
            foreach (var item in dataRow.ItemArray)
            {
                Debug.Log(item);
            }
        }*/
    }
}

