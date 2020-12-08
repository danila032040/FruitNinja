using UnityEngine;

public class PhysicalObject : MonoBehaviour
{

    [SerializeField]
    private float gravity = 9.807f;
    [SerializeField]
    private float weight = 1f;

    private Vector3 force;
    private Vector3 speed;

    public Vector3 Acceleration => Force / weight;
    public Vector3 Force => force + Vector3.down * gravity * weight;
    public Vector3 Speed => speed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        gameObject.transform.position += speed * Time.deltaTime;
        speed += Acceleration * Time.deltaTime;
    }

    public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
    {
        switch(mode)
        {
            case ForceMode.Acceleration: this.force += force * weight; break;
            case ForceMode.Force: this.force += force;  break;
            case ForceMode.Impulse: this.speed += force / weight; break;
            case ForceMode.VelocityChange: this.speed += force; break;
        }
    }
}
