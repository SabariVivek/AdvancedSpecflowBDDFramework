namespace SpecflowBDDFramework.Base
{
    public class ConfigBase
    {
        public string ApplicationUrl { get; set; } = null!;
        public Browser BrowserType { get; set; }
        public bool Headless { get; set; }
    }
}