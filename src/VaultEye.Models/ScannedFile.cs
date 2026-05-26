namespace VaultEye.Models
{
    public class ScannedFile
    {
        public string FileName { get; set; }
            = string.Empty;

        public List<string> Content { get; set; }
            = new();
    }
}