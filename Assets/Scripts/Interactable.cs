using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    private Meal currentMeal;

    void Start()
    {
        GlobalManager manager = GlobalManager.Instance;
        currentMeal = manager.Menu[manager.CompletedMeals.Count];
        switch (manager.GetPlayer().GetStateMachine().currentState.GetStateName()) {
            case "Gather":
                transform.position = currentMeal.gatherLocation;
                break;
            case "Prep":
                transform.position = currentMeal.prepLocation;
                break;
            default:
                // Set position to be kitchen stove
                break;
        }
    }

    public void Interact()
    {
        CookTimer cookTimer = GlobalManager.Instance.GetCookTimer();
        GlobalManager manager = GlobalManager.Instance;
        // dtask state 0 = gather, 1 = prep, 2 = cook, 3 = stop-cook
        switch (manager.GetPlayer().GetStateMachine().currentState.GetStateName()) {
            case "Gather":
                transform.position = currentMeal.prepLocation;
                if (currentMeal.breakPoint == 0) manager.AtHome = false;
                GlobalManager.Instance.GetPlayer().GetStateMachine().ChangeState(manager.GetStateByName("Prep"));
                break;
            case "Prep":
                if (currentMeal.breakPoint == 1) manager.AtHome = false;
                manager.GetPlayer().GetStateMachine().ChangeState(manager.GetStateByName("Cook"));
                cookTimer.StartTimer(currentMeal.goodThreshold, currentMeal.greatThreshold, currentMeal.cookTime);
                break;
            case "Cook":
                // Do not transition immediately so that players can't double-click the to skip being summoned
                if (currentMeal.breakPoint == 2) manager.AtHome = false;
                GlobalManager.Instance.GetPlayer().GetStateMachine().ChangeState(manager.GetStateByName("FinishMeal"));
                break;
            case "FinishMeal":
                int quality = 2;
                if (cookTimer.curTime < currentMeal.greatThreshold) quality = 1;
                if (cookTimer.curTime < currentMeal.goodThreshold) quality = 0;
                Debug.Log(quality);
                
                manager.CompletedMeals.Add(currentMeal, quality);

                if (manager.CompletedMeals.Count >= manager.Menu.Count)
                {
                    // TODO: done with food
                    Debug.Log("TODO done with menu");
                }
                else
                {
                    manager.GetPlayer().GetStateMachine().ChangeState(manager.GetStateByName("Gather"));
                }
                cookTimer.EndTimer();
                break;
            default:
                break;
        }
    }
}
