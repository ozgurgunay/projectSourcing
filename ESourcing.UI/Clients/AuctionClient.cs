using ESourcing.Core.Common;
using ESourcing.Core.ResultModels;
using ESourcing.UI.ViewModel;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ESourcing.UI.Clients
{
    public class AuctionClient
    {
        public HttpClient _client { get; }

        public AuctionClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.BaseAddress);
        }

        public async Task<Result<AuctionViewModel>> CreateAuction(AuctionViewModel model)
        {
            var dataAsString = JsonConvert.SerializeObject(model);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var response = await _client.PostAsync("/Auction", content);
            
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuctionViewModel>(responseData);
                if (result != null)
                    return new Result<AuctionViewModel>(true, ResultConstant.RecordCreateSuccessfully, result);
                else
                    return new Result<AuctionViewModel>(false, ResultConstant.RecordCreateNotSuccessfully);
            }

            return new Result<AuctionViewModel>(false, ResultConstant.RecordCreateNotSuccessfully);
        }



    }
}
