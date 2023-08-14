namespace WebClient.Interfaces.Options
{
    public class WebResource
    {
        public string Name { get; set; }

        public string Host { get; set; }

        public List<Segment> Segments { get; set; }
    }
}
