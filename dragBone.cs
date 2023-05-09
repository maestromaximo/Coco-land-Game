using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragBone : MonoBehaviour
{
    public void OnBeginDrag()
{
    // Track the mouse position as the user drags the object
    Vector3 mousePosition = Input.mousePosition;

    // Update the position of the object based on the mouse position
    transform.position = mousePosition;
        Debug.Log("CLICK WORKING");

    }

    public void OnPointerEnter()
    {
        Debug.Log("POINTER");
    }
}
