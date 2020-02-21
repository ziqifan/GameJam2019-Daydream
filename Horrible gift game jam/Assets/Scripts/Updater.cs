using UnityEngine;

public class Updater : MonoBehaviour
{


    // Start is called before the first frame update
    void Awake()
    {
        ControllerInput.update();
    }

    // Update is called once per frame
    void Update()
    {

        for (int a = 0; a < 4; a++)
            ControllerInput.setStickDeadZone(a,0.2f);

        ControllerInput.update();
    }


    void OnApplicationQuit()
    {
        for (int a = 0; a < 4; a++)
            ControllerInput.resetVibration(a);
    }
}
