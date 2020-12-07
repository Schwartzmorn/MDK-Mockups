using System;
using System.Collections.Generic;
using System.Text;
using IngameScript.Mockups.Base;
using Sandbox.ModAPI.Ingame;

namespace IngameScript.Mockups.Blocks
{
    class MockShipConnector : MockFunctionalBlock, IMyShipConnector
    {
        public bool RequestedConnection { get; set; }
        public bool RequestedDisconnection { get; set; }
        public bool RequestedToggle { get; set; }
        public bool ThrowOut { get; set; }
        public bool CollectAll { get; set; }
        public float PullStrength { get; set; }

        public bool IsLocked { get; set; }

        public bool IsConnected { get; set; }

        public MyShipConnectorStatus Status { get; set; }

        public IMyShipConnector OtherConnector { get; set; }

        public void Connect()
        {
            RequestedConnection = true;
        }

        public void Disconnect()
        {
            RequestedDisconnection = true;
        }
        public void ToggleConnect()
        {
            RequestedToggle = true;
        }
    }
}
