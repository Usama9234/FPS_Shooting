using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 20;
    float xRotation = 0;
    bool check;
    public Transform player;
    Vector3 touchStartPos;
    Vector3 currentRotation;
    float smooth = 0.5f;


    private void Start()
    {
        currentRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        if (check)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    float mouseX = (touch.position.x - touchStartPos.x) * sensitivity * Time.deltaTime;
                    float mouseY = (touch.position.y - touchStartPos.y) * sensitivity * Time.deltaTime;

                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                    currentRotation = Vector3.Lerp(currentRotation, new Vector3(xRotation, 0f, 0f), smooth);
                    transform.localRotation = Quaternion.Euler(currentRotation);

                    player.Rotate(Vector3.up * mouseX);

                    touchStartPos = touch.position;
                }


            }
        }
        
    }

    public void OnPointerEnter()
    {
        check = true;
    }

    public void OnPointerExit()
    {
        check = false;
    }
}
