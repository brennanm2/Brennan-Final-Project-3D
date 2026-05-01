using UnityEngine;

public class Playerdata : MonoBehaviour
{
    public int coinsCollected;

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "Coin")
      {
        // add one to our coin counter
        coinsCollected += 1;

        other.gameObject.SetActive(false);
      }
    }
}
