
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

    public void InitMeal(Meal currentMeal, int quality)
    {
        mealImage.gameObject.SetActive(true);
        switch (quality)
        {
            case 0:
                mealImage.sprite = currentMeal.OvercookedImage;
                break;
            case 1:
                mealImage.sprite = currentMeal.RawImage;
                break;
            case 2:
                mealImage.sprite = currentMeal.GoodImage;
                break;
            case 3:
                mealImage.sprite = currentMeal.GreatImage;
                break;
            default:
                break;
        }
    }
}