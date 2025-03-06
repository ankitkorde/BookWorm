//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.Extensions.Options;

//namespace BookWorm_Dotnet.ServicesImpl
//{
//    public class CheckOutService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly string _springBootBaseUrl;

//        public CheckOutService(HttpClient httpClient, IOptions<AppSettings> appSettings)
//        {
//            _httpClient = httpClient;
//            _springBootBaseUrl = appSettings.Value.SpringBootApiUrl; // Read from appsettings.json
//        }

//        public async Task CheckoutCart(int CustId)
//        {
//            var response = await _httpClient.GetAsync($"{_springBootBaseUrl}/api/myshelf/{shelfId}");
//        }
//    }
//}
