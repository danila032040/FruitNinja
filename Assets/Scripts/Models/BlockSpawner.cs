using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public enum EPlace
    {
        Up,
        Down,
        Left,
        Right
    }

    [SerializeField]
    private EPlace place;

    [SerializeField]
    [Range(0, 10)]
    private uint priority;

    [SerializeField]
    [Range(0, 1)]
    private float minPlacePercentage;

    [SerializeField]
    [Range(0, 1)]
    private float maxPlacePercentage;

    [SerializeField]
    private Block prefabBlock;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            SpawnOneBlock();
        }
    }

    void SpawnOneBlock()
    {
        Vector3 viewportPos = new Vector3(0, 0, Camera.main.nearClipPlane);
        switch (place)
        {
            case EPlace.Up:
                viewportPos.x = Random.Range(minPlacePercentage, maxPlacePercentage);
                viewportPos.y = 1;
                break;
            case EPlace.Right:
                viewportPos.x = 1;
                viewportPos.y = Random.Range(minPlacePercentage, maxPlacePercentage);
                break;
            case EPlace.Down:
                viewportPos.x = Random.Range(minPlacePercentage, maxPlacePercentage);
                viewportPos.y = 0;
                break;
            case EPlace.Left:
                viewportPos.x = 0;
                viewportPos.y = Random.Range(minPlacePercentage, maxPlacePercentage);
                break;
        }
        Vector3 result = Camera.main.ViewportToWorldPoint(viewportPos);
        PhysicalObject obj = Instantiate(prefabBlock, result, Quaternion.identity).GetComponent<PhysicalObject>();
    }
}
