using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerName : MonoBehaviour
{
    public GameObject makerMenu;
    public GameObject particle1;
    public GameObject particle2;

    public void goBack()
    {
        makerMenu.SetActive(false);
    }

    public void particleOn()
    {
        particle1.SetActive(true);
        particle2.SetActive(true);
    }

    public void showMaker()
    {
        makerMenu.SetActive(true);
    }

    public void particleOff()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
    }
}
