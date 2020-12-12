using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField]
    private float minSlicingVelocity = 0.01f;

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

        Slice();
    }

    private Vector3 oldPosition;

    public void Slice()
    {
        Vector3 newPosition = Input.mousePosition;
        newPosition.z = mainCamera.nearClipPlane;

        gameObject.transform.position = mainCamera.ScreenToWorldPoint(newPosition);

        if (isSlicing && Mathf.Abs(newPosition.magnitude - oldPosition.magnitude) >= minSlicingVelocity)
        {
            trail.enabled = true;
        }
        oldPosition = newPosition;
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
