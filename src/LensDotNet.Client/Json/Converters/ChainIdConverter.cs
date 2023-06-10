using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZeroQL;

namespace LensDotNet.Client.Json.Converters
{
    public class LongToChainIdJsonConverter : JsonConverter<ChainId>
    {
        public LongToChainIdJsonConverter() { }
        public override ChainId Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;

            if (Utf8Parser.TryParse(span, out long number, out var bytesConsumed) && span.Length == bytesConsumed)
            {
               
                var retVal = new ChainId { Value = number.ToString() };
                return retVal;
            }

            var data = reader.GetString();

            throw new InvalidOperationException($"'{data}' is not a correct expected value!")
            {
                Source = nameof(LongToChainIdJsonConverter)
            };
        }

        public override void Write(Utf8JsonWriter writer, ChainId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }

    public class LongToNonceJsonConverter : LongToZeroQLScalarJsonConverter<Nonce>
    {
        public override Nonce Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;

            if (Utf8Parser.TryParse(span, out long number, out var bytesConsumed) && span.Length == bytesConsumed)
            {

                var retVal = new Nonce { Value = number.ToString() };
                return retVal;
            }

            var data = reader.GetString();

            throw new InvalidOperationException($"'{data}' is not a correct expected value!")
            {
                Source = nameof(LongToNonceJsonConverter)
            };
        }

        public override void Write(Utf8JsonWriter writer, Nonce value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }

    internal class LongToUnixTimestampConverter : LongToZeroQLScalarJsonConverter<UnixTimestamp>
    {
        public LongToUnixTimestampConverter() { }

        public override UnixTimestamp Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;

            if (Utf8Parser.TryParse(span, out long number, out var bytesConsumed) && span.Length == bytesConsumed)
            {
                var retVal = new UnixTimestamp { Value = number.ToString() };
                return retVal;
            }

            var data = reader.GetString();

            throw new InvalidOperationException($"'{data}' is not a correct expected value!")
            {
                Source = nameof(LongToUnixTimestampConverter)
            };
        }

        public override void Write(Utf8JsonWriter writer, UnixTimestamp value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }

        public class LongToZeroQLScalarJsonConverter<TZeroQLScalar> : JsonConverter<TZeroQLScalar> where TZeroQLScalar : ZeroQLScalar
    {
        //public LongToZeroQLScalarJsonConverter<TZeroQLScalar>() {}

        public override TZeroQLScalar Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.Number &&
                type == typeof(String))
                return new ZeroQLScalar { Value = reader.GetString() } as TZeroQLScalar;

            var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;

            if (Utf8Parser.TryParse(span, out long number, out var bytesConsumed) && span.Length == bytesConsumed)
            {
                switch(type.Name)
                {
                    case "ChainId":
                        return new ChainId { Value = number.ToString() } as TZeroQLScalar;
                    case "Nonce":
                        return new Nonce { Value = number.ToString() } as TZeroQLScalar;
                    case "UnixTimestamp":
                        return new UnixTimestamp { Value = number.ToString() } as TZeroQLScalar;
                    default:
                        throw new InvalidOperationException($"'{type.Name}' is not a correct expected value!")
                        {
                            Source = "LongToZeroQLScalarJsonConverter"
                        };
                }   
                var retVal = new ZeroQLScalar { Value = number.ToString() } as TZeroQLScalar;
                return retVal;
            }

            var data = reader.GetString();

            throw new InvalidOperationException($"'{data}' is not a correct expected value!")
            {
                Source = "LongToStringJsonConverter"
            };
        }

        public override void Write(Utf8JsonWriter writer, TZeroQLScalar value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
