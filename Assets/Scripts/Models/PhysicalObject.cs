using UnityEngine;

public class PhysicalObject : MonoBehaviour
{

    [SerializeField]
    private float gravity = 9.807f;
    [SerializeField]
    private float weight = 1f;

    private Vector3 externalforce;
    private Vector3 speed;

    public Vector3 Acceleration => Force / weight;
    public Vector3 Force => externalforce + Vector3.down * gravity * weight;
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
            case ForceMode.Acceleration: this.externalforce += force * weight; break;
            case ForceMode.Force: this.externalforce += force;  break;
            case ForceMode.Impulse: this.speed += force / weight; break;
            case ForceMode.VelocityChange: this.speed += force; break;
        }
    }
}
