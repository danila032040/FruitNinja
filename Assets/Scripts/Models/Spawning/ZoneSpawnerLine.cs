using UnityEngine;

//[CreateAssetMenu(fileName = "ZoneSpawnerLine", menuName = "ZoneSpawner/Line", order = 1)]
public class ZoneSpawnerLine : ZoneSpawner
{

    [SerializeField] private Vector2 startSpawnLine = new Vector2(0f, 0f);
    [SerializeField] private Vector2 endSpawnLine = new Vector2(0f, 0f);
    [SerializeField] private Vector2 viewportGoalPosition = new Vector2(0.5f, 0.5f);

    private Vector2 VectorForMoveFromTo(Vector2 start, Vector2 goal) => new Vector2(goal.x - start.x, goal.y - start.y).normalized;
    private Vector2 RandomPointOnLine(Vector2 start, Vector2 end)
    {
        float percentage = Random.Range(0f, 1f);
        return Vector2.Lerp(start, end, percentage);
    }

    public override void SpawnBlock(Block prefab)
    {
        Vector2 randPointOnLine = RandomPointOnLine(startSpawnLine, endSpawnLine);
        Vector3 viewportPos = new Vector3(randPointOnLine.x, randPointOnLine.y, Camera.main.nearClipPlane);
        Vector3 velocity = VectorForMoveFromTo(viewportPos, viewportGoalPosition) * Random.Range(minVelocity, maxVelocity);
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(viewportPos);

        Block obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        obj.AddVelocity(velocity);
        obj.AddVelocityRotation(Random.Range(minVelocityRotation, maxVelocityRotation));
    }
}
