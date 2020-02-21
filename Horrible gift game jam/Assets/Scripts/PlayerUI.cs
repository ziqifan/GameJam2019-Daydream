using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Happiness: " + player.GetComponent<PlayerWinLose>().happiness;

      //  transform.position = player.transform.position + player.transform.lossyScale;
    }
}
