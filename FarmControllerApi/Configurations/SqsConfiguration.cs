using Amazon;
using Amazon.SQS;
using FarmController.Application.Options;

namespace FarmController.Api.Configurations
{
    public static class SqsConfiguration
    {
        public static IServiceCollection AddSqsConfiguration(this IServiceCollection services, SqsOptions configuration) 
        {
            services.AddSingleton<IAmazonSQS>(
                new AmazonSQSClient(RegionEndpoint.GetBySystemName(
                    configuration.Region)
                )
            );

            return services;
        }
    }
}
