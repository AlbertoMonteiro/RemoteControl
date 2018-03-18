namespace RemoteControl.Core.Models
{
    internal class Machine
    {
        public Machine(string name)
            => Name = name;

        protected Machine()
        {

        }

        public long Id { get; private set; }
        public string Name { get; private set; }
    }
}