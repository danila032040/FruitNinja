using UnityEngine;

public class PhysicalObject : MonoBehaviour
{

    [SerializeField] private float gravityScale = 1f;
    [SerializeField] private float weight = 1f;
    [SerializeField] private float velocityRotation;

    private Vector3 externalforce;
    private Vector3 speed;

    public Vector3 Acceleration => Force / weight;
    public Vector3 Force => externalforce + Physics.gravity * gravityScale * weight;
    public Vector3 Speed => speed;

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position += speed * Time.deltaTime;
        speed += Acceleration * Time.deltaTime;
    }
    private void Rotate()
    {
        transform.rotation = transform.rotation * Quaternion.AngleAxis(velocityRotation * Time.deltaTime, transform.forward);
    }

    public void AddAcceleration(Vector3 acceleration)
    {
        this.externalforce += acceleration * weight;
    }

    public void AddForce(Vector3 force)
    {
        this.externalforce += force;
    }

    public void AddImpulse(Vector3 impulse)
    {
        this.speed += impulse / weight; 
    }

    public void AddVelocity(Vector3 velocity)
    {
        this.speed += velocity; 
    }

    public void AddVelocityRotation(float velocity)
    {
        velocityRotation += velocity;
    }
}
