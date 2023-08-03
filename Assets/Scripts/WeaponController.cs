using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class WeaponController : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-180);
    }
}
//Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
//float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//Quaternion rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
//transform.rotation = rotation;