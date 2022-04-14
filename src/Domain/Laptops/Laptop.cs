namespace Domain.Laptops;

public class Laptop : AggregateRoot
{
    public Laptop(
        string brand,
        string processor,
        string generation,
        string ram,
        string sSD,
        string cache,
        string monitorSize)
    {
        ItemId = Guid.NewGuid().ToString();
        Brand = brand;
        Processor = processor;
        Generation = generation;
        Ram = ram;
        SSD = sSD;
        Cache = cache;
        MonitorSize = monitorSize;
    }

    public string Brand { get; set; }
    
    public string Processor { get; set; }
    
    public string Generation { get; set; }
    
    public string Ram { get; set; }
    
    public string SSD { get; set; }
    
    public string Cache { get; set; }
    
    public string MonitorSize { get; set; }

    public void SetId(string id)
    {
        ItemId = id;
    }
}
