namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using GraphQL.Types;
    using LensDotNet.Core.Extensions;
    using Newtonsoft.Json;

    public class ProfileMedia : DynamicObject
    {
        Dictionary<string, object> properties = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (properties.ContainsKey(binder.Name))
            {
                var nftImg = this.As<NftImage>();
                if (nftImg != null)
                {
                    result = nftImg.TryGetMember(binder, out result);
                } else {
                    var mediaSet = this.As<MediaSet>();
                    result = mediaSet;
                }

                return result == null;
            }
            else
            {
                result = "Invalid Property!";
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            properties[binder.Name] = value;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            dynamic method = properties[binder.Name];
            result = method(args[0].ToString(), args[1].ToString());
            return true;
        }
    }
}