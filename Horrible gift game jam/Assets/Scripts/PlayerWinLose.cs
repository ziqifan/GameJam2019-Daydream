using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using FMODUnity;


public class PlayerWinLose : MonoBehaviour
{
    public int happiness = 5;
    // Start is called before the first frame update
    int hatedPresent = 0;

    public GameObject otherPlayer;
    public GameObject presnt1;
    public GameObject presnt2;
    public GameObject presnt3;
    public GameObject presnt4;
    public GameObject presnt5;
    public GameObject presnt6;

    public GameObject happyEffect;
    public GameObject hateEffect;
    //bool present1Collision = false;
    //bool present2Collision = false;
    //bool present3Collision = false;
    //bool present4Collision = false;
    //bool present5Collision = false;
    //bool present6Collision = false;

    //boxIHate 
    bool lose = false;
    bool win = false;
    public static Dictionary<int, Type> presTypes;
    void Start()
    {
        hatedPresent = UnityEngine.Random.Range(1, 7);
        Debug.Log(hatedPresent);
    }

    // Update is called once per frame
    void Update()
    {
        if (happiness <= 0)
        {
            lose = true;
            Debug.Log("Game Over Kys");
        }
        if (otherPlayer.GetComponent<Player2WinLose>().happiness <= 0)
        {
            win = true;
        }

        if (lose)
        {

        }
        if (win)
        {
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        Debug.Log(other.gameObject.tag);
        if (other.GetComponent<PresentControle>().yeeted == true)
        {
            if (other.gameObject.CompareTag("Present 1"))
            {
                Debug.Log("Present 1");
                //if(present of that type is thrown)
                //{

                if (hatedPresent == 1)
                {
                    happiness -= 1;
                    Debug.Log("-1 Happiness: " + happiness);
                    hateEffect.GetComponent<ParticleSystem>().Play();
                    FMODUnity.RuntimeManager.PlayOneShot("event:/I Hate It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Hate It", this.gameObject);

                }
                else
                {
                    happiness += 1;

                    Debug.Log("+1 Happiness: " + happiness);
                    happyEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Love It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Love It", this.gameObject);
                }
                //}
            }
            if (other.gameObject.CompareTag("Present 2"))
            {
                //present1Collision = true;
                if (hatedPresent == 2)
                {
                    happiness -= 1;
                    Debug.Log("-1 Happiness: " + happiness);
                     hateEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Hate It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Hate It", this.gameObject);
                }
                else
                {
                    happiness += 1;
                    //Destroy(other.gameObject);
                    Debug.Log("+1 Happiness: " + happiness);
                    happyEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Love It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Love It", this.gameObject);
                    
                }
            }
            if (other.gameObject.CompareTag("Present 3"))
            {
                //present1Collision = true;
                if (hatedPresent == 3)
                {
                    happiness -= 1;
                    Debug.Log("-1 Happiness: " + happiness);
                     hateEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Hate It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Hate It", this.gameObject);
                }
                else
                {
                    happiness += 1;
                    //Destroy(other.gameObject);
                    Debug.Log("+1 Happiness: " + happiness);
                    happyEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Love It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Love It", this.gameObject);
                }
            }
            if (other.gameObject.CompareTag("Present 4"))
            {
                //present1Collision = true;
                if (hatedPresent == 4)
                {
                    happiness -= 1;
                    Debug.Log("-1 Happiness: " + happiness);
                     hateEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Hate It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Hate It", this.gameObject);
                }
                else
                {
                    happiness += 1;
                    //Destroy(other.gameObject);
                    Debug.Log("+1 Happiness: " + happiness);
                    happyEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Love It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Love It", this.gameObject);
                }
            }
            if (other.gameObject.CompareTag("Present 5"))
            {
                //present1Collision = true;
                if (hatedPresent == 5)
                {
                    happiness -= 1;
                    Debug.Log("-1 Happiness: " + happiness);
                     hateEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Hate It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Hate It", this.gameObject);
                }
                else
                {
                    happiness += 1;
                    //Destroy(other.gameObject);
                    Debug.Log("+1 Happiness: " + happiness);
                    happyEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Love It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Love It", this.gameObject);
                }
            }
            if (other.gameObject.CompareTag("Present 6"))
            {
                //present1Collision = true;
                if (hatedPresent == 6)
                {
                    happiness -= 1;
                    Debug.Log("-1 Happiness: " + happiness);
                     hateEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Hate It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Hate It", this.gameObject);
                }
                else
                {
                    happiness += 1;
                    //Destroy(other.gameObject);
                    Debug.Log("+1 Happiness: " + happiness);
                    happyEffect.GetComponent<ParticleSystem>().Play();
                     FMODUnity.RuntimeManager.PlayOneShot("event:/I Love It", GetComponent<Transform>().position);
                    FMODUnity.RuntimeManager.PlayOneShotAttached("event:/I Love It", this.gameObject);
                }
            }
        }
    }
}


