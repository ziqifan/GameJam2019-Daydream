﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI2 : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Happiness: " + player.GetComponent<Player2WinLose>().happiness;

        //  transform.position = player.transform.position + player.transform.lossyScale;
    }
}

