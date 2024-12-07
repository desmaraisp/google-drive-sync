using System;

namespace CompileTimeConfigPublicMembers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class GenerateConfigAccessorAttribute : Attribute
    {
        public Type ConfigRecordType { get; private set; }

        public GenerateConfigAccessorAttribute(Type configRecordType)
        {
            ConfigRecordType = configRecordType;
        }
    }
}
