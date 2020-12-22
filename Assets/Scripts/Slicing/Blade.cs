using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private float minSlicingVelocity = 0.01f;

    private Camera mainCamera;
    private bool isSlicing;
    private TrailRenderer trail;

    void Start()
    {
        mainCamera = Camera.main;
        trail = GetComponentInChildren<TrailRenderer>();
        trail.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartSlicing();
        if (Input.GetMouseButtonUp(0)) EndSlicing();

        Slicing();
    }

    private Vector3 oldPosition;

    public void Slicing()
    {
        Vector3 newPosition = Input.mousePosition;
        newPosition.z = mainCamera.nearClipPlane;
        newPosition = mainCamera.ScreenToWorldPoint(newPosition);

        gameObject.transform.position = newPosition;

        if (isSlicing && (newPosition - oldPosition).magnitude * Time.deltaTime > minSlicingVelocity)
        {
            trail.enabled = true;
            trail.emitting = true;
            SliceBlocks((newPosition - oldPosition).normalized);
        }
        else
        {
            trail.emitting = false;
        }
        oldPosition = newPosition;
    }

    public void SliceBlocks(Vector3 direction)
    {
        foreach(Block block in BlockManager.GetInstance().GetAll())
        {
            if ((gameObject.transform.position - block.gameObject.transform.position).magnitude<=block.Radius)
            {
                block.Slice(direction);
            }
        }
    }

    public void StartSlicing()
    {
        isSlicing = true;
        trail.enabled = false;

        Vector3 newPosition = Input.mousePosition;
        newPosition.z = mainCamera.nearClipPlane;
        newPosition = mainCamera.ScreenToWorldPoint(newPosition);
        oldPosition = newPosition;
    }

    public void EndSlicing()
    {
        isSlicing = false;
        trail.enabled = false;
    }

}
