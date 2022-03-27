using Ecommerce.Data.Models;
using Nest;

namespace Ecommerce.Api.Extensions
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            string uri = configuration["ELKConfiguration:Uri"];
            string index = configuration["ELKConfiguration:Index"];

            // Create a connection setting to point to ELS server
            var settings = new ConnectionSettings(new Uri(uri))
                            .PrettyJson()
                            .DefaultIndex(index);

            // Decide what to fields to ignore (ignored field won't be queried from ELS)
            AddDefaultMappings(settings);

            // Call the client to create index with above settings
            var client = new ElasticClient(settings);

            // Register the IElasticClient in IoC container so that it'll be available for DI
            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, index);
            
        }

        private static void AddDefaultMappings(ConnectionSettings connection)
        {
            connection.DefaultMappingFor<Product>(p => 
                p.Ignore(x => x.Description)
                    .Ignore(x => x.Category)
                    .Ignore(x => x.CategoryId)
                    .Ignore(x => x.Status)
            );
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            client.Indices.Create(indexName, i => i.Map<Product>(x => x.AutoMap()));
        }
    }
}