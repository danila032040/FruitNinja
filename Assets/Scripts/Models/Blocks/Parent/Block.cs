using Scripts.Models.Blocks.Managers;
using Scripts.Models.Physics;
using Scripts.Models.Physics.Managers;
using UnityEngine;

namespace Scripts.Models.Blocks.Parent
{
    public class Block : PhysicalObject
    {
        [SerializeField] protected float radius = 1f;


        protected bool isSliced = false;


        public float Radius => radius;

        public virtual void Slice(Vector3 direction)
        {
            isSliced = true;
        }
        public void DisableSlice()
        {
            isSliced = true;
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            BlockManager.GetInstance().Remove(this);
            PhysicalObjectManager.GetInstance().Remove(this);
        }
    }
}