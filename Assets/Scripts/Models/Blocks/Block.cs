using UnityEngine;
using UnityEngine.Events;

public class Block : PhysicalObject
{
    [SerializeField] protected float radius = 1f;


    protected bool isSliced = false;


    public event UnityAction Sliced;

    public float Radius => radius;

    public virtual void Slice(Vector3 direction)
    {
        Sliced?.Invoke();
        isSliced = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
