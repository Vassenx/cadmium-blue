using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{

    [SerializeField]
    private Canvas resultScreenCanvas;

    [SerializeField]
    private List<MealContainer> mealContainers;
    [SerializeField]
    private TMP_Text qualityText;
    [SerializeField] 
    private List<string> qualityString;
    private bool canExitScreen;


    // Start is called before the first frame update
    void Start()
    {
        resultScreenCanvas.enabled = false;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if(Input.GetKeyUp(KeyCode.L))
        {
            GlobalManager.Instance.ShowResultScreen(GlobalManager.Instance.Menu[0]);
        }
#endif
        if (Input.GetKeyDown(KeyCode.E)&& resultScreenCanvas.enabled)
        {
            canExitScreen = true;
        }
    }

    public IEnumerator ShowResultScreen(Meal currentMeal, int resultValue)
    {
        resultScreenCanvas.enabled = true;
        mealContainers[0].InitMeal(currentMeal);
        
        qualityText.text = qualityString[resultValue];
        
        //Stop updating gamestate 
        GlobalManager.Instance.GetPlayer().GetStateMachine().PauseState = true;
        while (!canExitScreen)
        {
            yield return null;
        }
        GlobalManager.Instance.GetPlayer().GetStateMachine().PauseState = false;

        resultScreenCanvas.enabled = false;
        canExitScreen = false;
        yield break;
    }
}
