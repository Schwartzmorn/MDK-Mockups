using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandbox.ModAPI.Ingame;

namespace IngameScript.Mockups
{
#if !MOCKUP_DEBUG
    [System.Diagnostics.DebuggerNonUserCode]
#endif
    class MockIntergridCommunicationSystem : IMyIntergridCommunicationSystem
    {
        readonly List<Tuple<string, string>> messages = new List<Tuple<string, string>>();

        public long Me { get; set; }

        public IMyUnicastListener UnicastListener { get; set; }

        public void DisableBroadcastListener(IMyBroadcastListener broadcastListener) { throw new NotImplementedException(); }
        public void GetBroadcastListeners(List<IMyBroadcastListener> broadcastListeners, Func<IMyBroadcastListener, bool> collect = null) { throw new NotImplementedException(); }

        public bool IsEndpointReachable(long address, TransmissionDistance transmissionDistance = TransmissionDistance.AntennaRelay)
        {
            throw new NotImplementedException();
        }

        public IMyBroadcastListener RegisterBroadcastListener(string tag) { throw new NotImplementedException(); }
        public void SendBroadcastMessage<TData>(string tag, TData data, TransmissionDistance transmissionDistance = TransmissionDistance.AntennaRelay) {
            this.messages.Add(Tuple.Create(tag, data.ToString()));
        }
        public bool SendUnicastMessage<TData>(long addressee, string tag, TData data) { throw new NotImplementedException(); }

        public int MessageCount => this.messages.Count;

        public Tuple<string, string> LastMessage => this.messages.Last();
    }
}
