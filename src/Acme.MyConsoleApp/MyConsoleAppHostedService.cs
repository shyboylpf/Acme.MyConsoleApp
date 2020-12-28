using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Acme.MyConsoleApp
{
    public class MyConsoleAppHostedService : IHostedService
    {
        private readonly IAbpApplicationWithExternalServiceProvider _application;
        private readonly IServiceProvider _serviceProvider;
        private readonly HelloWorldService _helloWorldService;
        private readonly PeriodWorkerService _periodWorkerService;

        public MyConsoleAppHostedService(
            IAbpApplicationWithExternalServiceProvider application,
            IServiceProvider serviceProvider,
            HelloWorldService helloWorldService,
            PeriodWorkerService periodWorkerService)
        {
            _application = application;
            _serviceProvider = serviceProvider;
            _helloWorldService = helloWorldService;
            _periodWorkerService = periodWorkerService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _application.Initialize(_serviceProvider);

            _helloWorldService.SayHello();

            _periodWorkerService.Start();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _periodWorkerService.Stop();
            _application.Shutdown();

            return Task.CompletedTask;
        }
    }
}
