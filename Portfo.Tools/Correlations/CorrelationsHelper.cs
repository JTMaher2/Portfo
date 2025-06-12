using System;

namespace Portfo.Tools.Correlations
{
    public class CorrelationsHelper
    {
        public static string BuildCorrelationId()
        {
            return $"{DateTime.UtcNow.ToString("yyyyMMddHHmmssFFF")}";
        }
    }
}
