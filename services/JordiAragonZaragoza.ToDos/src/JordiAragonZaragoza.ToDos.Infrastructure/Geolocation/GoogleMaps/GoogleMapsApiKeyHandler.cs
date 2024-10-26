namespace JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    public class GoogleMapsApiKeyHandler : DelegatingHandler
    {
        private readonly string apiKey;

        public GoogleMapsApiKeyHandler(string apiKey)
        {
            this.apiKey = apiKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["key"] = this.apiKey;
            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;

            return await base.SendAsync(request, cancellationToken);
        }
    }
}