﻿using Newtonsoft.Json;

namespace EMS.Business
{
    public class ResultModel
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("token")]
        public string Token { get; private set; }
    }
}
