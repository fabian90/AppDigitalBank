namespace monitoreo.Commons.RequestFilter
{
    public class QueryFilter
    {
        public int page { get; set; }
        public int take { get; set; } = 10;
        public string? ids { get; set; } = null;
        public string? filter { get; set; } = null;
        public string? type { get; set; } = null;
    }
}
