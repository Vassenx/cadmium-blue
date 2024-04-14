using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "StevenTypes/Meal", order = 1)]
public class Meal : ScriptableObject{
    public string dishName;
    public UnityEngine.Vector2 gatherLocation;
    public UnityEngine.Vector2 prepLocation;
    public float cookTime;
    public float greatThreshold;
    public float goodThreshold;
    public int breakPoint;

    public List<Battle> battles;

    public Sprite RawImage;
    public Sprite GoodImage;
    public Sprite GreatImage;
    public Sprite OvercookedImage;
    
    public List<string> qualityString;
}

