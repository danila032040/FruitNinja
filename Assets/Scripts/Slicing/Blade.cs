using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private float minSlicingDistance = 0.01f;

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

        gameObject.transform.position = mainCamera.ScreenToWorldPoint(newPosition);


        newPosition = mainCamera.ScreenToViewportPoint(newPosition);

        if (isSlicing && Mathf.Abs(newPosition.magnitude - oldPosition.magnitude) >= minSlicingDistance)
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
    }

    public void EndSlicing()
    {
        isSlicing = false;
        trail.enabled = false;
    }

}
