using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{

    private Vector3 velocty;
    private Rigidbody rb;
    private Transform tf;
    [SerializeField]
    private ForceMode forcemode;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();

    }


    void OnCollisionEnter(Collision other)
    {

        if (enabled && other.gameObject.tag == "Player")
        {

            Debug.Log("collid");


            velocty = rb.velocity;
            float xDir = tf.transform.eulerAngles.x;
            float zDir = tf.transform.eulerAngles.z;

            other.rigidbody.AddForce(new Vector3(xDir * velocty.x, 0,zDir * velocty.z).normalized * 50000f, forcemode);
        }
    }

}
