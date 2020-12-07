using System;
using System.Collections.Generic;
using System.Text;
using Sandbox.ModAPI.Ingame;

namespace IngameScript.Mockups {
    class MockUnicastListener : IMyUnicastListener
    {
        readonly Queue<MyIGCMessage> messages = new Queue<MyIGCMessage>();
        public bool HasPendingMessage => this.messages.Count > 0;

        public int MaxWaitingMessages { get; set; }

        public MyIGCMessage AcceptMessage()
        {
            return this.messages.Dequeue();
        }

        public void DisableMessageCallback() { throw new NotImplementedException(); }
        public void SetMessageCallback(string argument = "") { throw new NotImplementedException(); }

        public void QueueMessage(string s) {
            this.messages.Enqueue(new MyIGCMessage(s, "whatever", 0));
        }
    }
}
