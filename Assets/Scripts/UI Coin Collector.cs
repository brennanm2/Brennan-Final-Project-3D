using UnityEngine;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    public TMP_Text coinCounter;
    public Playerdata player;

    void Update()
    {
        coinCounter.text = "Coins Collected: " + player.coinsCollected;
    }
}
