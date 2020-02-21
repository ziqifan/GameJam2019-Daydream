using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentControle : MonoBehaviour
{
    public bool yeeted = false;

    private static ObjectPool myPool;
    // Start is called before the first frame update
    void Start()
    {
        myPool = ObjectPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        var rigid = GetComponent<Rigidbody>();
        if (Mathf.Abs(rigid.velocity.magnitude) < 0.05)
        {
            rigid.velocity = Vector3.zero;
            yeeted = false;
        }
        if(rigid.position.y < -5)
        {
            myPool.DespawnObject(gameObject);
        }
        else if (rigid.position.y > 60)
        {
            myPool.DespawnObject(gameObject);
        }
    }
    //yeet
    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.tag.Contains("Present") && col.gameObject.tag.Contains("Tree"))
        {
            yeeted = false;
        }
    }

}
