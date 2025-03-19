using System.Text.Json.Serialization;

namespace Domain.Response
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<OrderResponse> Orders { get; set; }
    }
}