using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    [SerializeField] private ItemDetails item;
    [SerializeField] private string checkItemName;

    [SerializeField] private ScoreboardTable scoreboard;
    [SerializeField] private ScoreTracker scoreTracker;

    private void OnTriggerEnter(Collider other)
    {
        if (item.itemName == checkItemName)
        {
            Debug.Log("Allo");
            //scoreboard.AddHighscoreEntry(9002, "Test2");
            scoreTracker.AddScore(item.points);
            Debug.Log(scoreTracker.score.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (item.itemName == checkItemName)
        {
            Debug.Log("'Ooroo");
            scoreTracker.RemoveScore(item.points);
            Debug.Log(scoreTracker.score.ToString());
        }
    }

}
