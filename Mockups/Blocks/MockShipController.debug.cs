using System;
using System.Collections.Generic;
using System.Text;
using IngameScript.Mockups.Base;
using Sandbox.ModAPI.Ingame;
using VRageMath;

namespace IngameScript.Mockups.Blocks
{
#if !MOCKUP_DEBUG
    [System.Diagnostics.DebuggerNonUserCode]
#endif
    class MockShipController : MockFunctionalBlock, IMyShipController
    {
        public bool CanControlShip { get; set; } = true;
        public bool IsUnderControl { get; set; } = true;
        public bool HasWheels { get; set; } = true;
        public bool ControlWheels { get; set; } = true;
        public bool ControlThrusters { get; set; } = true;
        public bool HandBrake { get; set; } = false;
        public bool DampenersOverride { get; set; } = true;
        public bool ShowHorizonIndicator { get; set; } = true;
        public Vector3 MoveIndicator { get; set; }
        public Vector2 RotationIndicator { get; set; }
        public float RollIndicator { get; set; } = 0f;
        public Vector3D CenterOfMass { get; set; }
        public bool IsMainCockpit { get; set; } = false;

        public MyShipMass ShipMass { get; set; }
        public MyShipMass CalculateShipMass()
        {
            return ShipMass;
        }
        public Vector3D GetArtificialGravity()
        {
            throw new NotImplementedException();
        }
        public Vector3D GetNaturalGravity()
        {
            return new Vector3D(0, -10, 0);
        }
        public double GetShipSpeed()
        {
            throw new NotImplementedException();
        }
        public MyShipVelocities GetShipVelocities()
        {
            throw new NotImplementedException();
        }
        public Vector3D GetTotalGravity()
        {
            throw new NotImplementedException();
        }
        public bool TryGetPlanetElevation(MyPlanetElevation detail, out double elevation)
        {
            throw new NotImplementedException();
        }
        public bool TryGetPlanetPosition(out Vector3D position)
        {
            throw new NotImplementedException();
        }
    }
}
