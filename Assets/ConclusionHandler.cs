using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ConclusionHandler : MonoBehaviour
{
    public Sprite[] meal1;
    public Sprite[] meal2;
    public Sprite[] meal3;
    public SpriteRenderer[] circles;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        var completedMeals = GlobalManager.Instance.CompletedMeals;
        var meal1Status = completedMeals.Values.ElementAt(0);
        circles[0].sprite = meal1[meal1Status];
        var meal2Status = completedMeals.Values.ElementAt(1);
        circles[1].sprite = meal1[meal2Status];
        var meal3Status = completedMeals.Values.ElementAt(2);
        circles[2].sprite = meal1[meal3Status];
        
        text.text = (meal1Status+meal2Status+meal3Status).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
