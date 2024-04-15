using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteUIAnim : MonoBehaviour
{
    public Image image;
    public List<Sprite> sprites;
    public float animSpeed = 1;
    public bool loop = true;
    
    private int index;
    private bool hasntStarted = true;

    void OnEnable()
    {
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        while(hasntStarted || loop)
        {
            yield return new WaitForSeconds(animSpeed);
            index++;
            if (index >= sprites.Count)
            {
                hasntStarted = false;
                index = 0;
            }
            else
            {
                image.sprite = sprites[index]; 
            }
        }
    }
}
