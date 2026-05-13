using UnityEngine;

public class ImpostorMode : MonoBehaviour
{
    public SpriteRenderer spr;

    public void TurnBlack()
    {
        spr.color = new Color(0, 255, 0);
    }
}
