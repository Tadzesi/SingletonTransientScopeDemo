using SingletonTransientScopeDemo.Interfaces;

namespace SingletonTransientScopeDemo.Services
{


    public class ScopedService : IService
    {
        private readonly Guid _id;
        private readonly string _serviceType;

        public ScopedService()
        {
            _id = Guid.NewGuid();
            _serviceType = "Scoped";
        }

        public Guid Id => _id;
        public string ServiceType => _serviceType;
        public string Explanation => "Scoped services are scoped to the HTTP request";
    }


}
