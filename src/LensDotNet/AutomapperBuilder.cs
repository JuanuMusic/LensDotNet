using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using AutoMapper;
using LensDotNet.Models;
using Nethereum.ABI.EIP712;
using Nethereum.Contracts.Standards.ERC20.TokenList;

namespace LensDotNet
{
    public static class AutomapperBuilder
    {
        private static IMapper _mapper;
        public static IMapper Mapper { get => GetMapper(); }

        public static IMapper GetMapper()
        {
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<string, BigInteger>().ConvertUsing(x => BigInteger.Parse(x));
                    cfg.CreateMap<EIP712TypedDataField, MemberDescription>();
                    cfg.CreateMap<EIP712TypedDataDomain, Domain>();
                    //cfg.CreateMap<CreateFollowEIP712TypedDataTypes, IDictionary<string, MemberDescription[]>>()
                    //    .ConvertUsing(x =>
                    //        new Dictionary<string, MemberDescription[]>(
                    //            new[] {
                    //            new KeyValuePair<string, MemberDescription[]>("FollowWithSig",
                    //                x.FollowWithSig.Select(y => new MemberDescription { Name = y.Name, Type = y.Type }).ToArray()) }));
                    cfg.CreateMap<CreateFollowEIP712TypedData, TypedData<Domain>>()
                        .ForMember(dst => dst.Message, opts => opts.Ignore())
                        .ForMember(dst => dst.PrimaryType, opts => opts.MapFrom(src => "FollowWithSig"))
                        .ForMember(dst => dst.DomainRawValues, opts => opts.Ignore())
                        //.ForMember(dst => dst.DomainRawValues, opts => opts.MapFrom(src => new MemberValue[] {
                        //	new MemberValue { TypeName = nameof(src.Value.) } ))
                        .ForMember(dst => dst.Domain, opts => opts.MapFrom(src => src.Domain))
                        .ForMember(dst => dst.Types,
                            opts => opts.MapFrom((src, dest) =>
                            {
                                var dict = new Dictionary<string, MemberDescription[]>();
                                MemberDescriptionFactory.AddMemberDescriptionFromTypeToDictionary(dict, typeof(Domain));
                                dict.Add("FollowWithSig", src.Types.FollowWithSig.Select(itm => new MemberDescription { Name = itm.Name, Type = itm.Type }).ToArray());
                                return dict;
                            }));
                });
                // only during development, validate your mappings; remove it before release
#if DEBUG
                config.AssertConfigurationIsValid();
#endif
                // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
                _mapper = config.CreateMapper();
            }
            return _mapper;
        }
    }
}

