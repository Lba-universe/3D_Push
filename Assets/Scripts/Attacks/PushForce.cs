using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{

    private Vector3 velocty;
    private Rigidbody rb;
    private Transform tf;
    private bool isPressed = false;

    private bool AttackIsReady = true;
    [SerializeField]
    private ForceMode forcemode;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPressed = true;
        }
    }


    void OnCollisionEnter(Collision other)
    {

        if (enabled && other.gameObject.tag == "Player")
        {

            Debug.Log("collid");

            velocty = rb.velocity;
            float xDir = tf.transform.eulerAngles.x;
            float zDir = tf.transform.eulerAngles.z;

            if (isPressed && AttackIsReady)
            {
                other.rigidbody.AddExplosionForce(1000 ,new Vector3(xDir * velocty.x, 0, zDir * velocty.z), 50, 8, forcemode);
                AttackIsReady = false;
                StartCoroutine("wait");
            }
            else
            {
                other.rigidbody.AddForce(new Vector3(xDir * velocty.x, 0, zDir * velocty.z), forcemode);
            }
            isPressed = false;
        }
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        AttackIsReady = true;
    }

}
