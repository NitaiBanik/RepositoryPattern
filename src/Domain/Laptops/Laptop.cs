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

    public string Brand { get; private set; }
    
    public string Processor { get; private set; }
    
    public string Generation { get; private set; }
    
    public string Ram { get; private set; }
    
    public string SSD { get; private set; }
    
    public string Cache { get; private set; }
    
    public string MonitorSize { get; private set; }
}
