using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControllerInput;

public class Yeet : MonoBehaviour
{
    public Animator _animator;

    public int PlayerIndex;
    bool hasPresent = false, buttonDown = false, windup = false;
    [Range(0, 50)]
    float windupCount;
    GameObject present;
    Transform cam;

    Vector3 impulse = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isButtonPressed(PlayerIndex, (int)CONTROLLER_BUTTON.X) && !buttonDown && hasPresent)
        {
            hasPresent = false;
            buttonDown = true;
            present.GetComponent<Rigidbody>().detectCollisions = true;
            present = null;
        }

        if (getTriggers(PlayerIndex).RT > .3f)
        {
            windupCount += 0.3f;
            windup = true;
            //var V = transform.up;
            //var D = transform.forward;
            //float angle = -35;
            //var D_tick = Vector3.Cross(Vector3.Cross(V, D), V).normalized;
            impulse = Vector3.Lerp(cam.transform.forward, cam.transform.up, .3f) * windupCount;
        }

        if (windup && getTriggers(PlayerIndex).RT < .3f)
        {
            present.transform.rotation = cam.transform.rotation;
            present.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
            windupCount = 0;
            print(impulse);
            present.GetComponent<PresentControle>().yeeted = true;
            // print(present);
            hasPresent = false;
            windup = false;
            //  present = null;
            present.GetComponent<Rigidbody>().detectCollisions = true;
        }

        if (isButtonReleased(PlayerIndex, (int)CONTROLLER_BUTTON.X) && buttonDown)
            buttonDown = false;


        if (hasPresent)
        {

            present.transform.rotation = cam.transform.rotation;

            present.transform.position = (cam.transform.forward * 3) + cam.transform.position;

            _animator.SetBool("isHold", true);
        }
        else
        {
            _animator.SetBool("isHold", false);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag.Contains("Present"))
            if (isButtonPressed(PlayerIndex, (int)CONTROLLER_BUTTON.X) && !buttonDown && !hasPresent)
            {
                buttonDown = true;
                hasPresent = true;
                present = col.gameObject;
                present.GetComponent<Rigidbody>().detectCollisions = false;
            }

    }
}
