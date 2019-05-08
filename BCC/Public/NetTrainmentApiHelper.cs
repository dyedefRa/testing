using BIPv2.Data.Domain.CustomRequestEntities;
using BIPv2.Data.Domain.Entities;
using BIPv2.Data.Domain.Enums;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BIPv2.Business.Services.Services
{
    public class NetTrainmentApiHelper
    {
        private const string boschPublicKey = "3E43FA66D64B46E1B3DF0145952A3A2F";
        private const string boschPrivateKey = "FC6E791A7AC8440B8DD8D6CFF80E6275";

        private const string profiloPublicKey = "6BDAFDC6FF4941788F04B9F12020F6E7";
        private const string profiloPrivateKey = "3234A4CC50CD49768B5D5AD70C66F699";

        private const string bshPublicKey = "CF835389085D4272BBAD35C8E496347A";
        private const string bshPrivateKey = "15BC27956705460188C724237D0A5879";

        private static HttpClient apiClient { get; set; }
        private const string _requestUri = "api/v1/auth";

        public NetTrainmentApiHelper(BrandEnum brandEnum)
        {
            apiClient = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            InitializeClient(brandEnum);
        }

        private static void InitializeClient(BrandEnum brandEnum)
        {       
            string privateKey = "";
            if (brandEnum == BrandEnum.Bosch)
                privateKey = boschPrivateKey;
            else if (brandEnum == BrandEnum.Profilo)
                privateKey = profiloPrivateKey;
            else if (brandEnum == BrandEnum.BipService)
                privateKey = bshPrivateKey;
            else
                privateKey = string.Empty;

            apiClient.DefaultRequestHeaders.Authorization =   new AuthenticationHeaderValue("Bearer", privateKey);
            apiClient.BaseAddress = new Uri(@"https://netTrainment.bsh-group.com/");
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<NetTrainmentUserModel> GetModelByGuid(string guid = "")
        {
            try
            {
                using (HttpResponseMessage httpResponse = apiClient.GetAsync(_requestUri+ "?id=" +guid).Result)
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var userModel = await httpResponse.Content.ReadAsAsync<NetTrainmentUserModel>();
                        userModel.StatusCode = StatusCode.Basarili;
                        return userModel;
                    }                   
                        return new NetTrainmentUserModel { StatusCode = StatusCode.YapilanIslemOlumsuz };                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public NetTrainmentUserModel Post(NetTrainmentUserModel personel)
        {
            try
            {
                HttpResponseMessage httpResponse = apiClient.PostAsJsonAsync(_requestUri, personel).Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    var userModel= httpResponse.Content.ReadAsAsync<NetTrainmentUserModel>().Result;
                    userModel.StatusCode = StatusCode.Basarili;
                    return userModel;
                }
                return new NetTrainmentUserModel { StatusCode = StatusCode.YapilanIslemOlumsuz };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }          
        }
        public NetTrainmentUserModel CastModel(UserEntity currentUser)
        {
            return new NetTrainmentUserModel()
            {
                Identifier = currentUser.IdGuid.ToString(),
                FirstName = currentUser.Firstname,
                LastName = currentUser.Lastname,
                Email = currentUser.Email,
                UserName = currentUser.Email.Split('@')[0],
                CountryCode = "TR",
                LanguageCode = "tr-TR",
                IsNonUniqueEmail = true
            };
        }
    }
}