using LensDotNet.Client.Fragments.Publication;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroQL;

namespace LensDotNet.Client.Fragments.Gasless
{
    public static class GaslessFragmentsExtensions
    {
        [ZeroQL.GraphQLFragment]
        public static CreateSetDispatcherEIP712TypedDataValueFragment AsFragment(this CreateSetDispatcherEIP712TypedDataValue input)
            => new CreateSetDispatcherEIP712TypedDataValueFragment
            {
                Nonce = input.Nonce,
                Deadline = input.Deadline,
                ProfileId = input.ProfileId,
                Dispatcher = input.Dispatcher
            };

        [ZeroQL.GraphQLFragment]
        public static EIP712TypedDataDomainFragment AsFragment(this EIP712TypedDataDomain input)
            => new EIP712TypedDataDomainFragment
            {
                ChainId = input.ChainId,
                VerifyingContract = input.VerifyingContract,
                Name = input.Name,
                Version = input.Version
            };


        [ZeroQL.GraphQLFragment]
        public static CreateSetDispatcherEIP712TypedDataFragment AsFragment(this CreateSetDispatcherEIP712TypedData input)
            => new CreateSetDispatcherEIP712TypedDataFragment
            {
                Domain = input.Domain(d => d.AsFragment()),
                Types = input.Types(t => t.AsFragment()),
                Value = input.Value(v => v.AsFragment())
            };

        [ZeroQL.GraphQLFragment]
        public static CreateSetDispatcherBroadcastItemResultFragment AsFragment(this CreateSetDispatcherBroadcastItemResult result)
            => new CreateSetDispatcherBroadcastItemResultFragment
            {
                ExpiresAt = result.ExpiresAt,
                Id = new BroadcastId(result.Id),
                TypedData = result.TypedData(td => td.AsFragment())
                
            };

        [ZeroQL.GraphQLFragment]
        public static CreateSetDispatcherEIP712TypedDataTypesFragment AsFragment(this CreateSetDispatcherEIP712TypedDataTypes input)
            => new CreateSetDispatcherEIP712TypedDataTypesFragment
            {
                SetDispatcherWithSig = input.SetDispatcherWithSig(o => new EIP712TypedDataField { Name = o.Name, Type = o.Type })
            };

        [ZeroQL.GraphQLFragment]
        public static RelayResultFragment AsFragment(this RelayResult relayResult)
            => new RelayResultFragment
            {
                Result = relayResult.On<RelayerResult>().Select(rr => new RelayerResult { TxHash = rr.TxHash, TxId = rr.TxId }),
                Error = relayResult.On<RelayError>().Select(re => new RelayError { Reason = re.Reason })
            };

        [ZeroQL.GraphQLFragment]
        public static DispatcherFragment AsFragment(this Dispatcher dispatcher)
            => new DispatcherFragment { Address = dispatcher.Address, CanUseRelay = dispatcher.CanUseRelay, Sponsor = dispatcher.Sponsor };
    }
}
