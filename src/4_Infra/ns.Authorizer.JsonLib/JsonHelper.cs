using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using ns.Authorizer.ResultLib;

namespace ns.Authorizer.JsonLib
{
    public static class JsonHelper<T>
    {
        public static Result<T> CreateObject(string json, string schema)
        {
            if (ValidateJsonSchema(json, schema))
                return Result<T>.Ok(JsonConvert.DeserializeObject<T>(json));

            return Result<T>.Fail();
        }

        private static bool ValidateJsonSchema(string json, string jsonSchema)
        {
            JSchema jSchema = JSchema.Parse(jsonSchema);

            JObject jObject = JObject.Parse(json);
            return jObject.IsValid(jSchema);
        }
    }

    public static class JsonHelper
    {
        public static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
    }
}
