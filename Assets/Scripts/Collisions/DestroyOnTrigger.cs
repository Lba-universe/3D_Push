using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers with the given tag.
 */
public class DestroyOnTrigger : MonoBehaviour {

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter(Collider other)
    {

        if ((other.tag == triggeringTag || other.tag=="RedDragon") && enabled)
        {

            Destroy(other.gameObject);
        }
    }

}
