using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.WaypointSystem
{
    public class PathUser : MonoBehaviour, IPathUser
    {

        #region Unity fields

        [SerializeField] private Direction _direction;
        [SerializeField] private float _arriveDistance = 0.1f;

        #endregion

        private IMover _mover;
        private Path _path;
        private bool _isInitialized = false;
        private float _sqrArriveDistance;

        public Waypoint CurrentWaypoint { get; private set; }
        public Direction Direction { get { return _direction; } set { _direction = value; } }

        public Vector3 Position{ get { return transform.position; } set { transform.position = value; } }

        public void Init(IMover mover, Path path)
        {
            _sqrArriveDistance = _arriveDistance * _arriveDistance;
            _mover = mover;
            _path = path;
            
            if (_path != null)
            {
                CurrentWaypoint = _path.GetClosestWaypoint(Position);
                _isInitialized = true;
            }
        }

        protected void Update ()
        {
            if (!_isInitialized)
            {
                return;
            }

            CurrentWaypoint = GetWayPoint();

            if (CurrentWaypoint != null)
            {
                Vector3 direction = CurrentWaypoint.Position - Position;
                _mover.MoveToDirection(direction);
                _mover.RotateTowardPosition(CurrentWaypoint.Position);
            }
        }

        //Gets the waypoint we are moving towards this frame.

        private Waypoint GetWayPoint ()
        {
            Waypoint result = CurrentWaypoint;

            if (CurrentWaypoint != null)
            {
                Vector3 toWaypointVector = CurrentWaypoint.Position - Position;
                float waypointVectorSqrMagnitude = toWaypointVector.sqrMagnitude;

                if (waypointVectorSqrMagnitude <= _sqrArriveDistance)
                {
                    // We have reached currentwaypoint.
                    result = _path.GetNextWaypoint(CurrentWaypoint, ref _direction);
                }
            }

            return result;
        }
    }
}