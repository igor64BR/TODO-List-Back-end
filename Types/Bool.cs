using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListBackend.Types
{
    [ComplexType]
    public class Bool
    {
        public bool Value { get; private set; }

        public Bool() { }

        public Bool(bool value)
        {
            Value = value;
        }

        public void Enable()
        {
            if (Value)
                throw new InvalidOperationException("The boolean is already enabled.");

            Value = true;
        }

        public void Disable()
        {
            if (!Value)
                throw new InvalidOperationException("The boolean is already disabled.");

            Value = false;
        }

        public void Toggle()
        {
            Value = !Value;
        }
    }
}
