using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    [SerializeField] private string checkItemName;
    private string itemName;
    private int scorePoints;

    [SerializeField] private ScoreTracker scoreTracker;

    private void OnTriggerEnter(Collider other)
    {
        itemName = other.GetComponent<ItemDetails>().name;
        scorePoints = other.GetComponent<ItemDetails>().points;

        if (itemName == checkItemName)
        {
            scoreTracker.AddScore(scorePoints);
            Debug.Log("Valid Item. Score:" + scoreTracker.score.ToString());
        }
        else
        {
            Debug.Log("NO");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        itemName = other.GetComponent<ItemDetails>().name;
        scorePoints = other.GetComponent<ItemDetails>().points;

        if (itemName == checkItemName)
        {
            scoreTracker.RemoveScore(scorePoints);
            Debug.Log("Item Removed. Score:" + scoreTracker.score.ToString());
        }
    }

}
