using Newtonsoft.Json;
using System;
using UploadImages.Utils.Converters;

namespace UploadImages.Models
{
    public class CreatePostBodyDto
    {
        public int? Id { get; set; }
        public string caption { get; set; }

        [JsonConverter(typeof(JsonToByteArrayConverter))]
        public byte[] image { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public DateTime? createdAt { get; set; }
    }
}
