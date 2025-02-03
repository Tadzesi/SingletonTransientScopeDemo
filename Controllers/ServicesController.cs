using Microsoft.AspNetCore.Mvc;
using SingletonTransientScopeDemo.Interfaces;
using SingletonTransientScopeDemo.Services;

namespace SingletonTransientScopeDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IService _singletonService1;
        private readonly IService _singletonService2;
        private readonly IService _scopedService1;
        private readonly IService _scopedService2;
        private readonly IService _transientService1;
        private readonly IService _transientService2;

        public ServicesController(
             [FromKeyedServices(ServiceType.Singleton)] IService singletonService1,
             [FromKeyedServices(ServiceType.Singleton)] IService singletonService2,
             [FromKeyedServices(ServiceType.Scoped)] IService scopedService1,
             [FromKeyedServices(ServiceType.Scoped)] IService scopedService2,
             [FromKeyedServices(ServiceType.Transient)] IService transientService1,
             [FromKeyedServices(ServiceType.Transient)] IService transientService2)
        {
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = new
            {
                Singleton1 = new
                {
                    Id = _singletonService1.Id,
                    Type = _singletonService1.ServiceType,
                    Explanation = _singletonService1.Explanation
                },
                Singleton2 = new
                {
                    Id = _singletonService2.Id,
                    Type = _singletonService2.ServiceType,
                    _singletonService2.Explanation
                },
                Scoped1 = new
                {
                    Id = _scopedService1.Id,
                    Type = _scopedService1.ServiceType,
                    _scopedService1.Explanation
                },
                Scoped2 = new
                {
                    Id = _scopedService2.Id,
                    Type = _scopedService2.ServiceType,
                    _scopedService2.Explanation
                },
                Transient1 = new
                {
                    Id = _transientService1.Id,
                    Type = _transientService1.ServiceType,
                    _transientService1.Explanation

                },
                Transient2 = new
                {
                    Id = _transientService2.Id,
                    Type = _transientService2.ServiceType,
                    _transientService2.Explanation

                }
            };

            return Ok(response);
        }
    }
}

