﻿using System;
using IngameScript.Mockups.Base;
using Sandbox.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript.Mockups.Blocks
{
#if !MOCKUP_DEBUG
    [System.Diagnostics.DebuggerNonUserCode]
#endif
    public class MockMotorStator : MockFunctionalBlock, IMyMotorStator
    {
        public float Angle { get; set; } = 0;
        public float Torque { get; set; }
        public float BrakingTorque { get; set; }
        public float TargetVelocityRad
        {
            get { return Convert.ToSingle(2 * Math.PI) / 60 * TargetVelocityRPM; }
            set { TargetVelocityRPM = value / Convert.ToSingle(2 * Math.PI) * 60; }
        }
        public float TargetVelocityRPM { get; set; }
        public float LowerLimitRad
        {
            get { return ToRads(LowerLimitDeg); }
            set { LowerLimitDeg = FromRads(value); }
        }
        
        public float LowerLimitDeg { get; set; } = float.MinValue;
        public float UpperLimitRad
        {
            get { return ToRads(UpperLimitDeg); }
            set { UpperLimitDeg = FromRads(value); }
        }

        public float UpperLimitDeg { get; set; } = float.MaxValue;
        public float Displacement { get; set; } = 0f;
        public bool RotorLock { get; set; } = false;

        public IMyCubeGrid TopGrid => Top?.CubeGrid;

        public IMyAttachableTopBlock Top { get; private set; }

        public float SafetyLockSpeed { get; set; }
        public bool SafetyLock { get; set; }

        public bool IsLocked { get; set; } = false;
        
        public bool IsAttached => Top != null;
        public bool PendingAttachment => MockPendingAttachment != null;

        public IMyAttachableTopBlock MockPendingAttachment { get; set; }

        private float FromRads(float value)
        {
            if (value == float.MaxValue)
            {
                return float.MaxValue;
            }
            else if (value == float.MinValue)
            {
                return float.MinValue;
            }
            return value * 180 / Convert.ToSingle(Math.PI);
        }

        private float ToRads(float value)
        {
            if (value == float.MaxValue)
            {
                return float.MaxValue;
            }
            else if (value == float.MinValue)
            {
                return float.MinValue;
            }
            return Convert.ToSingle(Math.PI) * value / 180;
        }

        public void Attach()
        {
            if (PendingAttachment && !IsAttached)
            {
                var attachment = MockPendingAttachment as MockMotorRotor;
                if (attachment != null)
                {
                    Top = attachment;
                    attachment.Base = this;
                    MockPendingAttachment = null;
                }
                else
                {
                    throw new NotSupportedException("Cannot attach Rotors which are not Mocks");
                }
            }
        }

        public void Detach()
        {
            MockPendingAttachment = Top;
            Top = null;
        }
    }
}
