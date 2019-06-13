using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CloudStorage
{
    public class Entry
    {
        [JsonProperty(".tag")]
        public string Tag { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("client_modified")]
        public DateTime ClientModified { get; set; }
        [JsonProperty("server_modified")]
        public DateTime ServerModified { get; set; }
        [JsonProperty("rev")]
        public string Rev { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("path_lower")]
        public string PathLower { get; set; }
        [JsonProperty("path_display")]
        public string PathDisplay { get; set; }
        [JsonProperty("is_downloadable")]
        public bool IsDownloadable { get; set; }
        [JsonProperty("has_explicit_shared_members")]
        public bool HasExplicitSharedMembers { get; set; }
        [JsonProperty("content_hash")]
        public string ContentHash { get; set; }
    }
}
