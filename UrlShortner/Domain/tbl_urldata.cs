using System;
using System.Collections.Generic;

namespace UrlShortner.Domain
{
    public partial class tbl_urldata
    {
        public long Id { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public int? NumberOfTimes { get; set; }
        public int? NumberOfTimesUsed { get; set; }
        public byte Status { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
