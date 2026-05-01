using UnityEngine;
using TMPro;
using System.Collections;

public class CountUpText : MonoBehaviour
{
    private TMP_Text textComponent;
    public int startValue = 0;
    public int endValue = 100;
    public float duration = 1f;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        StartCoroutine(CountUp());
    }

    IEnumerator CountUp()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float current = Mathf.Lerp(startValue, endValue, elapsed / duration);
            // Format as "n0" for no decimals and comma-separated thousands
            textComponent.text = Mathf.RoundToInt(current).ToString("n0");
            yield return null;
        }
        textComponent.text = endValue.ToString("n0"); // Ensure final number is exact
    }
}
