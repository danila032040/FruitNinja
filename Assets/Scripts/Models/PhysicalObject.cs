using UnityEngine;

public class PhysicalObject : MonoBehaviour
{

    public Animator animator;
    public void Awake()
    {
        this.animator = GetComponent<Animator>();
    }

    public float VelocityRotation
    {
        get
        {
            return this.animator.GetFloat("VelocityRotation");
        }
        set
        {
            this.animator.SetFloat("VelocityRotation", value);
        }
    }

    [SerializeField]
    private float gravityScale = 1f;
    [SerializeField]
    private float weight = 1f;

    private Vector3 externalforce;
    private Vector3 speed;

    public Vector3 Acceleration => Force / weight;
    public Vector3 Force => externalforce + Physics.gravity * gravityScale * weight;
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
}
