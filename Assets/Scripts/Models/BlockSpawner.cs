using UnityEngine;

[System.Serializable]
public class BlockSpawner : ScriptableObject
{
    public enum EPlace
    {
        Up,
        Right,
        Down,
        Left,
    }

    public const int MinPriorityValue = 0;
    public const int MaxPriorityValue = 10;
    public const float MinVelocityValue = 0f;
    public const float MaxVelocityValue = 5f;

    #region Fields

    [SerializeField]
    private EPlace place = EPlace.Down;

    [SerializeField]
    [Range(MinPriorityValue, MaxPriorityValue)]
    private int priority;

    [SerializeField]
    [Range(0, 1)]
    private float minPlacePercentage;

    [SerializeField]
    [Range(0, 1)]
    private float maxPlacePercentage = 1f;

    [SerializeField]
    [Range(MinVelocityValue, MaxVelocityValue)]
    private float minVelocity = MinVelocityValue;

    [SerializeField]
    [Range(MinVelocityValue, MaxVelocityValue)]
    private float maxVelocity = MaxVelocityValue;

    [SerializeField]
    private Vector2 viewportPositionGoal = new Vector2(0.5f, 0.5f);

    #endregion

    #region Getters

    public EPlace Place => this.place;
    public int Priority => this.priority;
    public float MinPlacePercentage => this.minPlacePercentage;
    public float MaxPlacePercentage => this.maxPlacePercentage;
    public float MinVelocity => this.minVelocity;
    public float MaxVelocity => this.maxVelocity;

    #endregion

    private Vector2 VectorForMoveFromTo(Vector2 start, Vector2 goal) => new Vector2(goal.x - start.x, goal.y - start.y).normalized;

    public void SpawnOneBlock(Block prefab)
    {
        Vector3 viewportPos = new Vector3(0, 0, Camera.main.nearClipPlane);
        Vector3 velocity = new Vector3(0, 0, 0);

        if (place == EPlace.Left || place == EPlace.Right)
        {
            viewportPos.x = place == EPlace.Right ? 1 : 0;
            viewportPos.y = Random.Range(minPlacePercentage, maxPlacePercentage);
        }
        else
        {
            viewportPos.x = Random.Range(minPlacePercentage, maxPlacePercentage);
            viewportPos.y = place == EPlace.Up ? 1 : 0;
        }

        velocity = VectorForMoveFromTo(viewportPos, viewportPositionGoal) * Random.Range(minVelocity, maxVelocity);
        Vector3 result = Camera.main.ViewportToWorldPoint(viewportPos);
        PhysicalObject obj = Instantiate(prefab, result, Quaternion.identity);
        obj.AddVelocity(velocity);
    }
}
