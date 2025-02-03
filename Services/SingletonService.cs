using SingletonTransientScopeDemo.Interfaces;

namespace SingletonTransientScopeDemo.Services
{
    public class SingletonService : IService
    {
        private readonly Guid _id;
        private readonly string _serviceType;

        public SingletonService()
        {
            _id = Guid.NewGuid();
            _serviceType = "Singleton";
        }

        public Guid Id => _id;
        public string ServiceType => _serviceType;

        public string Explanation => "Singleton services truly remain singleton";
    }

}
