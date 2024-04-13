using System;
using UnityEngine;

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
        Debug.Log(GlobalManager.Instance.DTaskState);
        switch (GlobalManager.Instance.DTaskState) {
            case 0:
                GlobalManager.Instance.DTaskState++;
                transform.position = new Vector2(Int32.Parse(currentMeal.prepLocation.Split(',')[0]), Int32.Parse(currentMeal.prepLocation.Split(',')[1]));
                // if (Int32.Parse(currentMeal.breakPoint) == 0) 
                break;
            case 1:
                GlobalManager.Instance.DTaskState++;
                // if (Int32.Parse(currentMeal.breakPoint) == 1) 
                break;
            case 2:
                // Do not transition immediately so that players can't double-click the to skip being summoned
                GlobalManager.Instance.CookTime = currentMeal.cookTime;

                // if (Int32.Parse(currentMeal.breakPoint) == 2) 
                break;
            case 3:
                int quality = 2; 
                if (GlobalManager.Instance.CookTime < currentMeal.greatThreshold) quality = 1;
                if (GlobalManager.Instance.CookTime < currentMeal.goodThreshold) quality = 0;
                GlobalManager.Instance.CompletedMeals.Add(currentMeal, quality);
                break;
            default:
                break;
        }
    }
}
