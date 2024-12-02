using System;

namespace CompileTimeConfigPublicMembers;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class GenerateConfigAccessorAttribute(Type configRecordType) : Attribute
{
    public Type ConfigRecordType { get; } = configRecordType;
}
