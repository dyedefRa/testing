using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIPv2.Data.Domain.CustomRequestEntities
{
  public  class NetTrainmentUserModel
    {
        public string Identifier { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsNonUniqueEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LanguageCode { get; set; }
        public string AuthorizationToken { get; set; }
        public long Expiration { get; set; }
        public string CountryCode { get; set; }
        public string ActivationCode { get; set; }
        public StatusCode StatusCode { get; set; }
    }
    public enum StatusCode
    {
       Basarili=200,
       YapilanIslemOlumsuz=333,
       Bulunamadi=404,
       Hata=666

    }

}
