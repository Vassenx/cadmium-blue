using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    Meal currentMeal;
 
    [SerializeField] private CookTimer cookTimer;

    void Start() {
        currentMeal = GlobalManager.Instance.Menu[GlobalManager.Instance.CompletedMeals.Count];
        switch (GlobalManager.Instance.DTaskState) {
            case 0:
                transform.position = currentMeal.gatherLocation;
                break;
            case 1:
                transform.position = currentMeal.prepLocation;
                break;
            default:
                // Set position to be kitchen stove
                break;
        }
    }

    public void Interact() {
        switch (GlobalManager.Instance.DTaskState) {
            case 0:
                GlobalManager.Instance.DTaskState++;
                transform.position = currentMeal.prepLocation;
                if (currentMeal.breakPoint == 0) GlobalManager.Instance.AtHome = false;
                break;
            case 1:
                GlobalManager.Instance.DTaskState++;
                if (currentMeal.breakPoint == 1) GlobalManager.Instance.AtHome = false;
                break;
            case 2:
                // Do not transition immediately so that players can't double-click the to skip being summoned
                // GlobalManager.Instance.DTaskState++;
                GlobalManager.Instance.CookTime = currentMeal.cookTime;
                if (currentMeal.breakPoint == 2) GlobalManager.Instance.AtHome = false;
                cookTimer.StartTimer(currentMeal.goodThreshold, currentMeal.greatThreshold, currentMeal.cookTime);
                break;
            case 3:
                int quality = 2; 
                if (GlobalManager.Instance.CookTime < currentMeal.greatThreshold) quality = 1;
                if (GlobalManager.Instance.CookTime < currentMeal.goodThreshold) quality = 0;
                Debug.Log(quality);
                GlobalManager.Instance.CompletedMeals.Add(currentMeal, quality);
                cookTimer.EndTimer();
                break;
            default:
                break;
        
            
        }
    }
}
