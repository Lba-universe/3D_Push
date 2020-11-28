using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushHim : MonoBehaviour
{
    public GameObject[] gos;
    public float power = 500f;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DoPush();
        }
    }


    private void DoPush()
    {

        gos= GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        Vector3 dir = new Vector3();
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                Debug.Log(closest);
                dir = diff;
            }
        }
        dir = dir.normalized;
        if (distance < 0.9)
        {
            Debug.Log(distance);
            closest.GetComponent<Rigidbody>().AddForce(dir * power);
        }
     




    }

}
