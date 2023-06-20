using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreboardTable : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    private void Awake()
    {
        scoreContainer = transform.Find("highscoreContainer");
        scoreTemplate = scoreContainer.Find("highscoreTemplate");

        scoreTemplate.gameObject.SetActive(false);

        float templateHeight = 30;

        for (int i = 0; i < 10; i++)
        {
            Transform scoreTransform = Instantiate(scoreTemplate, scoreContainer);
            RectTransform scoreRectTransform = scoreTransform.GetComponent<RectTransform>();
            scoreRectTransform.anchoredPosition = new Vector2(0, - templateHeight * i);
            scoreTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch(rank) 
            {
                default:
                    rankString = rank + "th"; break;

                case 1: rankString = "1st"; break;
                case 2: rankString = "2nd"; break;
                case 3:rankString = "3rd"; break;
            }

            scoreTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;
            int score = Random.Range(0, 10000);
            scoreTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString();
            string name = "BBQ";
            scoreTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

        }
    }
}
