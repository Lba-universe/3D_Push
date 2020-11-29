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
    [SerializeField]
    private float ForceLevel = 15;


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

            other.rigidbody.AddForce(transform.forward* ForceLevel, forcemode);
        }
    }

}
