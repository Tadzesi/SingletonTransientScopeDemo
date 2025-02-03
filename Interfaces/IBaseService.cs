namespace SingletonTransientScopeDemo.Interfaces
{
    public interface IService
    {
        Guid Id { get; }
        string ServiceType { get; }
        string Explanation { get; }
    }


}
