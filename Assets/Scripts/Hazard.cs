using UnityEngine;
using UnityEngine.SceneManagement; // Useful for restarting the level

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit a hazard!");
            
            // OPTION A: Simple Restart (Kill the player instantly)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // OPTION B: Call a Damage function on the player
            // other.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }
}
