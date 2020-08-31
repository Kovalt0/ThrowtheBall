using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> leaderboardEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("leaderboardEntryContainer");
        entryTemplate = transform.Find("leaderboardEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddLeaderBoardEntry(10000, "CMK");


        string jsonString = PlayerPrefs.GetString("leaderboardTable");
        Leaderboard leaderboard = JsonUtility.FromJson<Leaderboard>(jsonString);

        //Sort entry list by score
        for (int i = 0; i < leaderboard.leaderboardEntryList.Count; i++)
        {
            for (int j = i + 1; j < leaderboard.leaderboardEntryList.Count; j++)
            {
                if (leaderboard.leaderboardEntryList[j].score > leaderboard.leaderboardEntryList[i].score)
                {
                    // Swap
                    LeaderBoardEntry tmp = leaderboard.leaderboardEntryList[i];
                    leaderboard.leaderboardEntryList[i] = leaderboard.leaderboardEntryList[j];
                    leaderboard.leaderboardEntryList[j] = tmp;
                }
            }
        }


        leaderboardEntryTransformList = new List<Transform>();
        foreach (LeaderBoardEntry leaderboardEntry in leaderboard.leaderboardEntryList)
        {
            CreateLeaderBoardEntryTransform(leaderboardEntry, entryContainer, leaderboardEntryTransformList);
        }
    }

    private void CreateLeaderBoardEntryTransform(LeaderBoardEntry leaderBoardEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        int score = leaderBoardEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = leaderBoardEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private void AddLeaderBoardEntry(int score, string name)

    {
        // Create Leaderboardentry
        LeaderBoardEntry leaderboardEntry = new LeaderBoardEntry { score = score, name = name };

        //Load saved Leaderboard
        string jsonString = PlayerPrefs.GetString("leaderboardTable");
        Leaderboard leaderboard = JsonUtility.FromJson<Leaderboard>(jsonString);

        // Add new entry to Leaderboard
        leaderboard.leaderboardEntryList.Add(leaderboardEntry);

        //Save updated Leaderboard
        string json = JsonUtility.ToJson(leaderboard);
        PlayerPrefs.SetString("leaderboardTable", json);
        PlayerPrefs.Save();
    }
    private class Leaderboard
    {
        public List<LeaderBoardEntry> leaderboardEntryList;
    }

    /*
     * Represents a sigle Leader Board Entry
     * */
    [System.Serializable] //esto es nuevo (hace parte con lo que hay que tener cuidado)
    private class LeaderBoardEntry
    {
        public int score;
        public string name;


    }
}
