namespace WebService.Controllers.Laptops;

public class AddLaptopRequest
{
    /// <summary>
    /// Brand name of the laptop
    /// </summary>
    /// <example>Asus/Apple/Hp</example>
    public string Brand { get; private set; } = string.Empty;

    /// <summary>
    /// Processor name of the laptop
    /// </summary>
    /// <example>Intel Corei5/Ryzen 5</example>
    public string Processor { get; private set; } = string.Empty;

    /// <summary>
    /// Processor Generation of the laptop
    /// </summary>
    /// <example>5th/11th/9th/5000U/7700U</example>
    public string Generation { get; private set; } = string.Empty;

    // <summary>
    /// Ram size of the laptop
    /// </summary>
    /// <example>16GB 3200Mhz/32GB 3300Mhz</example>

    public string Ram { get; private set; } = string.Empty;

    // <summary>
    /// SSD size of the laptop
    /// </summary>
    /// <example>256GB/512GB</example>
    public string SSD { get; private set; } = string.Empty;

    // <summary>
    /// Cache size of the laptop
    /// </summary>
    /// <example>6MB/12MB</example>
    public string Cache { get; private set; } = string.Empty;

    // <summary>
    /// Monitor size of the laptop
    /// </summary>
    /// <example>14"/15"/13"</example>
    public string MonitorSize { get; private set; } = string.Empty;
}
