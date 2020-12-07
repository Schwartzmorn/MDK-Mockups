using IngameScript.Mockups.Base;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameScript.Mockups.Blocks
{
#if !MOCKUP_DEBUG
    [System.Diagnostics.DebuggerNonUserCode]
#endif
    class MockSolarPanel : MockFunctionalBlock, IMySolarPanel
    {
        public float CurrentOutput { get; set; }
        public float MaxOutput { get; set; }
    }
}
