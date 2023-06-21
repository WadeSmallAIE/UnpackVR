using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreboardTable : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private void Awake()
    {
        scoreContainer = transform.Find("highscoreContainer");
        scoreTemplate = scoreContainer.Find("highscoreTemplate");

        scoreTemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(9000, "BBQ");

        //highscoreEntryList = new List<HighscoreEntry>()
        //{ new HighscoreEntry{score = 1902, name = "PNS"},
        //new HighscoreEntry{score = 2344, name = "ABC"},
        //new HighscoreEntry{score = 5466, name = "DIK"},
        //new HighscoreEntry{score = 2354, name = "WLY"},
        //new HighscoreEntry{score = 4235, name = "OOG"},
        //new HighscoreEntry{score = 2455, name = "BOO"},
        //new HighscoreEntry{score = 2345, name = "POO"},
        //new HighscoreEntry{score = 5235, name = "LOO"},
        //new HighscoreEntry{score = 2555, name = "DOO"},
        //new HighscoreEntry{score = 1923, name = "GOO"},
        //};

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Sort
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i+1; j < highscores.highscoreEntryList.Count; j++) 
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) 
                { 
                    HighscoreEntry temp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = temp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) 
        {
            CreateHighscoreTransform(highscoreEntry, scoreContainer, highscoreEntryTransformList);
        }

    }

    private void CreateHighscoreTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30;
        Transform scoreTransform = Instantiate(scoreTemplate, container);
        RectTransform scoreRectTransform = scoreTransform.GetComponent<RectTransform>();
        scoreRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        scoreTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        scoreTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;
        int score = highscoreEntry.score;
        scoreTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString();
        string name = highscoreEntry.name;
        scoreTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

        transformList.Add(scoreTransform);

    }

    private void AddHighscoreEntry(int score, string name)
    {
        //Create
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //Load
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Add
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}