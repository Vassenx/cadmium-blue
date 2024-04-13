using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    Meal currentMeal;
    void Start() {
        currentMeal = GlobalManager.Instance.Menu[GlobalManager.Instance.CompletedMeals.Count];
        switch (GlobalManager.Instance.DTaskState) {
            case 0:
                transform.position = new Vector2(Int32.Parse(currentMeal.gatherLocation.Split(',')[0]), Int32.Parse(currentMeal.gatherLocation.Split(',')[1]));
                break;
            case 1:
                transform.position = new Vector2(Int32.Parse(currentMeal.prepLocation.Split(',')[0]), Int32.Parse(currentMeal.prepLocation.Split(',')[1]));
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
                transform.position = new Vector2(Int32.Parse(currentMeal.prepLocation.Split(',')[0]), Int32.Parse(currentMeal.prepLocation.Split(',')[1]));
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
                break;
            case 3:
                int quality = 2; 
                if (GlobalManager.Instance.CookTime < currentMeal.greatThreshold) quality = 1;
                if (GlobalManager.Instance.CookTime < currentMeal.goodThreshold) quality = 0;
                Debug.Log(quality);
                GlobalManager.Instance.CompletedMeals.Add(currentMeal, quality);
                break;
            default:
                break;
        
            
        }
    }
}
