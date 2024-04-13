using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Meal currentMeal;
    void Start() {
        GlobalManager.Instance.Target = gameObject;
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
                break;
            case 1:
                GlobalManager.Instance.DTaskState++;
                break;
            case 2:
                // Do not transition immediately so that players can't double-click the to skip being summoned
                GlobalManager.Instance.DTaskState++;
                break;
            case 3:
                GlobalManager.Instance.CookTime = currentMeal.cookTime;
                break;
            default:
                break;
        }
    }
}
