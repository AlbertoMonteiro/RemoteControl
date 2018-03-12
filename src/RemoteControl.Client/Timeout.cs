using System;

namespace RemoteControl.Client
{
    public sealed class Timeout
    {
        private readonly long _timeout;

        public Timeout(long timeout)
        {
            _timeout = TimeSpan.FromMilliseconds(timeout).Ticks;
            Value = DateTime.Now.Ticks + _timeout;
        }

        public long Value { get; private set; }

        public void Renew()
            => Value = 0;

        public void Clear()
            => Value = DateTime.Now.Ticks + _timeout;
    }
}