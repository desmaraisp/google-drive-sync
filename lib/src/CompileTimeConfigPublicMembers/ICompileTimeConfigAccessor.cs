namespace CompileTimeConfigPublicMembers;

public interface ICompileTimeConfigAccessor<out T> where T : class
{
    public T GetConfig();
}
