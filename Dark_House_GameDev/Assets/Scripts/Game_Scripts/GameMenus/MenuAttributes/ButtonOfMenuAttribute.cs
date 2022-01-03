using System;

namespace GameMenus
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class ButtonOfMenuAttribute : Attribute
    {
        private Type _type;
        public ButtonOfMenuAttribute(Type type)
        {
            _type = type;
        }

        public Type GetMenu()
        {
            return _type;
        }
    }
}