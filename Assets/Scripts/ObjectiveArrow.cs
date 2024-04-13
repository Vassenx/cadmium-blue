using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveArrow : MonoBehaviour
{
    Camera cam;
    // Distance for marker to edge of screen.
    int buffer = 50;

    void Start(){
        cam = Camera.main;
    }

    void Update () {
        if (GlobalManager.Instance.Target != null) {
            Vector3 targetPos = cam.WorldToScreenPoint(GlobalManager.Instance.Target.gameObject.transform.position);
            if (!Screen.safeArea.Contains(targetPos)) {
                GetComponent<Image>().enabled = true;
                Vector3 screenMiddle = new Vector3(Screen.width/2, Screen.height/2, 0); 
                float angle = 360 - (Mathf.Atan2(targetPos.x-screenMiddle.x, targetPos.y-screenMiddle.y) * 180 / Mathf.PI);
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);

                var rectTransform = GetComponent<RectTransform>();
                rectTransform.position = Camera.main.WorldToScreenPoint(GlobalManager.Instance.Target.gameObject.transform.position);
                if (rectTransform.position.x > Screen.width - buffer) rectTransform.position = new Vector2(Screen.width - buffer, rectTransform.position.y);
                if (rectTransform.position.x < buffer) rectTransform.position = new Vector2(buffer, rectTransform.position.y);
                if (rectTransform.position.y > Screen.height - buffer) rectTransform.position = new Vector2(rectTransform.position.x, Screen.height - buffer);
                if (rectTransform.position.y < buffer) rectTransform.position = new Vector2(rectTransform.position.x, buffer);
            }
            else {
                GetComponent<Image>().enabled = false;
            }
        }
        else GetComponent<Image>().enabled = false;
    }
}