using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    private SpriteRenderer SR;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
    }
}
