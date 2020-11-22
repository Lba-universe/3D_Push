using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushHim : MonoBehaviour
{
    [SerializeField] public float pushRadius;
    [SerializeField] public float pushamount;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DoPush();
        }
    }

    // Update is called once per frame
    private void DoPush()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);
        foreach(Collider pushobject in colliders)
        {
            if (pushobject.CompareTag("GreenDra"))
            {
                Debug.Log("pressssssss");
                Rigidbody pushBody = pushobject.GetComponent<Rigidbody>();
                pushBody.AddExplosionForce(pushamount, Vector3.up, pushRadius);
            }
        }

        
    }
}
