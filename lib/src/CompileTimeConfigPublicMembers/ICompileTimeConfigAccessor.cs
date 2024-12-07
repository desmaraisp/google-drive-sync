namespace CompileTimeConfigPublicMembers
{
    public interface ICompileTimeConfigAccessor<out T> where T : class
    {
        T GetConfig();
    }
}
