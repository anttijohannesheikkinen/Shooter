using UnityEngine;

namespace Shooter
{
    public interface IMover
    {
        // Position of this object in world space.
        Vector3 Position { get; set; }

        // Rotation of this object in world space.
        Quaternion Rotation { get; set; }

        //The speed of this mover.
        float Speed { get; }

        // Moves toward targetPosition.
        void MoveTowardsPosition(Vector3 targetPosition);
        // Move to direction 'direction'.
        void MoveToDirection(Vector3 direction);
        //Rotate toward position 'targetPosition'.
        void RotateTowardPosition(Vector3 targetPosition);
    }
}
