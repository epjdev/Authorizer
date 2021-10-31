using Newtonsoft.Json;
using System;

namespace ns.Authorizer.Domain.Model.Transaction
{
    public class TransactionOperationVO
    {
        public const string Schema = @"{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""type"": ""object"",
  ""properties"": {
    ""transaction"": {
      ""type"": ""object"",
      ""properties"": {
        ""merchant"": {
          ""type"": ""string""
        },
        ""amount"": {
          ""type"": ""integer""
        },
        ""time"": {
          ""type"": ""string""
        }
      },
      ""required"": [
        ""merchant"",
        ""amount"",
        ""time""
      ]
    }
  },
  ""required"": [
    ""transaction""
  ]
}";

        [JsonProperty(PropertyName = "transaction")]
        public TransactionDetails Transaction { get; private set; }
    }

    public class TransactionDetails
    {
        [JsonProperty(PropertyName = "merchant")]
        public string Merchant { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public long Amount { get; set; }

        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }
    }
}
