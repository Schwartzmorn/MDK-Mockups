﻿using System;
using IngameScript.Mockups.Base;
using Sandbox.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript.Mockups.Blocks
{
#if !MOCKUP_DEBUG
    [System.Diagnostics.DebuggerNonUserCode]
#endif
    public partial class MockMotorStator : MockFunctionalBlock, IMyMotorStator
    {
        public virtual float Angle { get; set; } = 0;
        public virtual float Torque { get; set; }
        public virtual float BrakingTorque { get; set; }
        public virtual float TargetVelocityRad
        {
            get { return Convert.ToSingle(2 * Math.PI) / 60 * TargetVelocityRPM; }
            set { TargetVelocityRPM = value / Convert.ToSingle(2 * Math.PI) * 60; }
        }
        public float TargetVelocityRPM { get; set; }
        public virtual float LowerLimitRad
        {
            get { return ToRads(LowerLimitDeg); }
            set { LowerLimitDeg = FromRads(value); }
        }
        
        public virtual float LowerLimitDeg { get; set; } = -1;
        public virtual float UpperLimitRad
        {
            get { return ToRads(LowerLimitDeg); }
            set { LowerLimitDeg = FromRads(value); }
        }

        public virtual float UpperLimitDeg { get; set; } = -1;
        public virtual float Displacement { get; set; } = 0f;
        public virtual bool RotorLock { get; set; } = false;

        public virtual IMyCubeGrid TopGrid => Top?.CubeGrid;

        public virtual IMyAttachableTopBlock Top { get; private set; }

        public virtual float SafetyLockSpeed { get; set; }
        public virtual bool SafetyLock { get; set; }

        public virtual bool IsLocked { get; set; } = false;
        
        public virtual bool IsAttached => Top != null;
        public virtual bool PendingAttachment => MockPendingAttachment != null;

        public virtual IMyAttachableTopBlock MockPendingAttachment { get; set; }

        protected float FromRads(float value)
        {
            if (value == -1)
                return -1;

            return value * 180 / Convert.ToSingle(Math.PI);
        }

        protected float ToRads(float value)
        {
            if (value == -1)
                return -1;

            return Convert.ToSingle(Math.PI) * value / 180;
        }

        public virtual void Attach()
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

        public virtual void Detach()
        {
            MockPendingAttachment = Top;
            Top = null;
        }
    }
}
