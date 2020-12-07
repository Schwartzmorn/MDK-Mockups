using System;
using System.Collections.Generic;
using System.Text;
using IngameScript.Mockups.Base;
using Sandbox.ModAPI.Ingame;

namespace IngameScript.Mockups.Blocks {
    class MockAttachableTopBlock : MockCubeBlock, IMyAttachableTopBlock
    {
        public bool IsAttached { get; set; }

        public IMyMechanicalConnectionBlock Base { get; set; }
    }
}
