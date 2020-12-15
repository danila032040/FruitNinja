using UnityEngine;
using UnityEngine.Events;

public class Block : PhysicalObject
{
    [SerializeField] protected float radius = 1f;


    protected bool isSliced = false;


    public float Radius => radius;

    public virtual void Slice(Vector3 direction)
    {
        isSliced = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        BlockManager.existBlocks.Remove(this);
    }
}
