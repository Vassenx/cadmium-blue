
using UnityEngine;
using UnityEngine.UI;

public class MealContainer:MonoBehaviour
{
    
    [SerializeField]
    private Image mealImage;
    
    private void Start()
    {
        mealImage.gameObject.SetActive(false);
    }

    public void InitMeal(Meal currentMeal)
    {
        mealImage.gameObject.SetActive(true);
    }
}