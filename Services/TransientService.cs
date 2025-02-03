using SingletonTransientScopeDemo.Interfaces;

namespace SingletonTransientScopeDemo.Services
{

    public class TransientService : IService
    {
        private readonly Guid _id;
        private readonly string _serviceType;

        public TransientService()
        {
            _id = Guid.NewGuid();
            _serviceType = "Transient";
        }

        public Guid Id => _id;
        public string ServiceType => _serviceType;
        public string Explanation => "Transient services are new instances every time";

    }
}
