using System.Reflection;
using System.Linq;

namespace HotfixTest.ExampleNamespace
{
    class HotfixExample : IExample
    {
        private object _hotfixObject;
        public HotfixExample(object hotfixObject)
        {
            _hotfixObject = hotfixObject;
        }

        private T GetProperty<T>(string propName)
        {
            return (T)_hotfixObject.GetType().GetProperties().Where(pi => pi.Name == propName).First().GetMethod.Invoke(_hotfixObject, new object[] { });
        }

        private void SetProperty<T>(string propName, T value)
        {
            _hotfixObject.GetType().GetProperties().Where(pi => pi.Name == propName).First().SetMethod.Invoke(_hotfixObject, new object[] { value });
        }

        private T RunMethod<T>(string methodName, params object[] values)
        {
            return (T)_hotfixObject.GetType().GetMethod(methodName, values.Select(v => v.GetType()).ToArray()).Invoke(_hotfixObject, values);
        }

        string IExample.ExampleProperty
        {
            get => GetProperty<string>("ExampleProperty");
            set => SetProperty("ExampleProperty", value);
        }

        void IExample.DoSomething(string data)
        {
            RunMethod<object>("DoSomething", data);
        }
    }
}
