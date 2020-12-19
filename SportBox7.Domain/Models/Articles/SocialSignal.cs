using System;
using System.Collections.Generic;
using SportBox7.Domain.Common;
using System.Linq;
using System.Threading.Tasks;
using SportBox7.Domain.Exeptions;

using static SportBox7.Domain.Models.ModelConstants.SocialSignal;

namespace SportBox7.Data.Models
{
    public class SocialSignal: Entity<int>
    {
     
        internal SocialSignal(string visitorIp, bool isLiked)
        {
            this.ValidateVisitorIp(visitorIp);
            this.VisitorIp = visitorIp;
            this.IsLiked = isLiked;
        }
        
        public bool IsLiked { get; private set; }

        public string VisitorIp { get; private set; } = default!;

        private void ValidateVisitorIp(string visitorIp)
        {
            Validator.CheckForEmptyString<InvalidSocialSignalException>(visitorIp, "VisitorIp");
            Validator.CheckStringLength<InvalidSocialSignalException>(visitorIp, MinIpLength, MaxIpLength, "VisitorIp");
        }
    }
}
