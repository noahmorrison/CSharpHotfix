namespace HotfixTest.ExampleNamespace
{
    class ExampleClass : IExample
    {
        private string _ExampleProperty = "I'm a value! :P";
        public string ExampleProperty
        {
            get => _ExampleProperty;
            set => _ExampleProperty = value;
        }

        public void DoSomething(string data)
        {
            System.Console.WriteLine("Doing something without " + data);
        }
    }
}
