using UnityEngine;

public class Playerdata : MonoBehaviour
{
    public int coinsCollected;
    public bool magnetCollected;

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "Coin")
      {
        // add one to our coin counter
        coinsCollected += 1;

        other.gameObject.SetActive(false);
      }

      if (other.gameObject.tag == "Magnet")
      {

        other.gameObject.SetActive(false);
      }

      
    }
}
