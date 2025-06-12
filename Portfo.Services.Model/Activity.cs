using System;

namespace Portfo.Services.Model
{
    public class Activity
    {
        public Guid ActivityID { get; set; }
        public DateTime ActivityOccuredAt { get; set; }
        public byte ActivityOperation {get;set;}
        public PostUser ActivityUser {get;set;}
    }
}
