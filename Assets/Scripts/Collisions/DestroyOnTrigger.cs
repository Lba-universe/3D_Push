using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers with the given tag.
 */




public class DestroyOnTrigger : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshPro winnerText;

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == triggeringTag && enabled)
        {

            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {
            Destroy(other.gameObject);
            EnemyCounter.EnemyDie();
            if (EnemyCounter.getCount() == 0)
            {
                //reset count
                EnemyCounter.setCount(0);

                if (SceneManager.GetActiveScene().buildIndex < 1)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                else { 
                // player won
                    Time.timeScale = 0;
                    winnerText.text = "You win \n Great Job!";
                  }
            }
        }

    }

}
