using UnityEngine;
using UnityEngine.AI;

public abstract class SoldierPositionController : MonoBehaviour
{
    public SoldierPositionObject soldierPosition;

    protected Transform KingPos; // Gameobject to follow
    protected float soldierSpacing = 1.5f; // Space between soldiers
    protected float[] columnOffsets; // Offsets for the columns
    protected float maxSpeed = 8f; // Maximum speed for soldiers
    protected float distanceFactor = 4.5f; // Factor to determine speed based on distance
    protected LayerMask groundLayer; // Layer mask to identify the ground

    private void Update()
    {
        int soldierIndex = 0;
        GetSoldierData();
        foreach (Transform child in transform)
        {
            Vector3 targetPosition = CalculateTargetPosition(soldierIndex);
            SetSoldierSpeed(child, targetPosition);

            soldierIndex++;
        }
    }

    /// <summary>
    /// Obtains data of soldiers from the linked soldierPositionObject
    /// </summary>
    protected virtual void GetSoldierData()
    {
        soldierSpacing = soldierPosition.soldierSpacing;
        columnOffsets = soldierPosition.columnOffsets;
        maxSpeed = soldierPosition.maxSpeed;
        distanceFactor = soldierPosition.distanceFactor;
        groundLayer = soldierPosition.groundLayer;
    }

    /// <summary>
    /// Calculates the target position for a soldier based on its index.
    /// </summary>
    /// <param name="soldierIndex">Index of the soldier.</param>
    /// <returns>Target position for the soldier.</returns>
    protected virtual Vector3 CalculateTargetPosition(int soldierIndex)
    {
        int columnIndex = soldierIndex % columnOffsets.Length;
        float offset = columnOffsets[columnIndex];

        Vector3 targetPosition = KingPos.position - ((soldierIndex / columnOffsets.Length) + 1) * soldierSpacing * KingPos.forward + offset * soldierSpacing * KingPos.right;
        return targetPosition;
    }

    /// <summary>
    /// Sets the speed of a soldier based on the distance to the target position.
    /// </summary>
    /// <param name="soldier">The soldier transform.</param>
    /// <param name="targetPosition">The target position for the soldier.</param>
    protected virtual void SetSoldierSpeed(Transform soldier, Vector3 targetPosition)
    {
        if (soldier.TryGetComponent<NavMeshAgent>(out var agent))
        {
            agent.SetDestination(targetPosition);

            float distance = Vector3.Distance(soldier.position, targetPosition);
            agent.speed = Mathf.Min(maxSpeed, distance * distanceFactor);
        }
    }
}
