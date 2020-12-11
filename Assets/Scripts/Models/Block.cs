using UnityEngine;

public class Block : PhysicalObject
{

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
