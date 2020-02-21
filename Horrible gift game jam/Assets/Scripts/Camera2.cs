using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControllerInput;

public class Camera2 : MonoBehaviour
{

    Vector2 mousePosition;
    Vector2 smoothValue;
    public float sensitivity = 5.0f;
    public float smoothness = 2.0f;

    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Stick stick = getSticks(1)[RS];
        setStickDeadZone(1, 0.1f);

        //Move camera by the mouse movement, and use sentivity and smooth to achieve better performance
        var md = new Vector2(stick.x, stick.y);

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothness, sensitivity * smoothness));
        smoothValue.x = Mathf.Lerp(smoothValue.x, md.x, 1.0f / smoothness);
        smoothValue.y = Mathf.Lerp(smoothValue.y, md.y, 1.0f / smoothness);
        mousePosition += smoothValue;

        //Clamp camera not go above head or below feet
        mousePosition.y = Mathf.Clamp(mousePosition.y, -90.0f, 90.0f);

        transform.localRotation = Quaternion.AngleAxis(-mousePosition.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mousePosition.x, character.transform.up);
    }
}