using System;
using System.Collections.Generic;
using System.Text;
using Sandbox.ModAPI.Ingame;
using VRageMath;

namespace IngameScript.Mockups.Blocks {
    class MockRemoteControl : MockShipController, IMyRemoteControl
    {
        public List<MyWaypointInfo> Waypoints { get; set; } = new List<MyWaypointInfo>();

        public bool IsAutoPilotEnabled { get; set; }

        public float SpeedLimit { get; set; }
        public FlightMode FlightMode { get; set; }
        public Base6Directions.Direction Direction { get; set; }

        public MyWaypointInfo CurrentWaypoint { get; set; }

        public bool WaitForFreeWay { get; set; }

        public void AddWaypoint(Vector3D coords, string name)
        {
            this.Waypoints.Add(new MyWaypointInfo(name, coords));
        }
        public void AddWaypoint(MyWaypointInfo coords)
        {
            this.Waypoints.Add(coords);
        }
        public void ClearWaypoints() {
            this.Waypoints.Clear();
        }

        public bool GetNearestPlayer(out Vector3D playerPosition)
        {
            throw new NotImplementedException();
        }

        public void GetWaypointInfo(List<MyWaypointInfo> waypoints)
        {
            waypoints.AddRange(this.Waypoints);
        }
        public void SetAutoPilotEnabled(bool enabled) { throw new NotImplementedException(); }
        public void SetCollisionAvoidance(bool enabled) { throw new NotImplementedException(); }
        public void SetDockingMode(bool enabled) { throw new NotImplementedException(); }
    }
}
