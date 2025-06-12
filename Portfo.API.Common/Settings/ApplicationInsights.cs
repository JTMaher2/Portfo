using System.ComponentModel.DataAnnotations;

namespace Portfo.API.Common.Settings
{
    public class ApplicationInsights
    {
        [Required]
        public bool Enabled { get; set; }

        public string ConnectionString { get; set; }
    }
}
