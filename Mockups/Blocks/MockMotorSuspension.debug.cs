using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using VRage.Game.ModAPI.Ingame;
using IngameScript.Mockups.Base;

namespace IngameScript.Mockups.Blocks
{
#if !MOCKUP_DEBUG
    [System.Diagnostics.DebuggerNonUserCode]
#endif
    class MockMotorSuspension : MockFunctionalBlock, IMyMotorSuspension
    {
        public float PropulsionOverride { get; set; }
        public float SteerOverride { get; set; }

        protected override IEnumerable<ITerminalProperty> CreateTerminalProperties()
        {
            return base.CreateTerminalProperties().Concat(new[]
            {
                new MockTerminalProperty<IMyFunctionalBlock, float>("Propulsion override", b => (b as MockMotorSuspension).PropulsionOverride, (b, v) => (b as MockMotorSuspension).PropulsionOverride = v),
                new MockTerminalProperty<IMyFunctionalBlock, float>("Steer override", b => (b as MockMotorSuspension).SteerOverride, (b, v) => (b as MockMotorSuspension).SteerOverride = v),
                new MockTerminalProperty<IMyFunctionalBlock, float>("MaxSteerAngle", b => (b as MockMotorSuspension).MaxSteerAngle, (b, v) => (b as MockMotorSuspension).MaxSteerAngle = v)
            });
        }

        private float height;

        public bool attached = false;
        public bool detached = false;
        public bool Steering { get; set; }

        public bool Propulsion { get; set; }
        public bool InvertSteer { get; set; }
        public bool InvertPropulsion { get; set; }

        public float Damping { get; set; }

        public float Strength { get; set; }
        public float Friction { get; set; }
        public float Power { get; set; }
        public float Height { get { return this.height; } set { this.height = VRageMath.MathHelper.Clamp(value, -2, 2); } }

        public float SteerAngle { get; set; }

        public float MaxSteerAngle { get; set; }

        public float SteerSpeed { get; set; }

        public float SteerReturnSpeed { get; set; }

        public float SuspensionTravel { get; set; }

        public bool Brake { get; set; }
        public bool AirShockEnabled { get; set; }

        public IMyCubeGrid TopGrid { get; set; }

        public IMyAttachableTopBlock Top { get; set; }

        public float SafetyLockSpeed { get; set; }
        public bool SafetyLock { get; set; }

        public bool IsAttached { get; set; }

        public bool IsLocked { get; set; }

        public bool PendingAttachment { get; set; }

        public void Attach()
        {
            attached = true;
        }
        public void Detach()
        {
            detached = true;
        }
    }
}
