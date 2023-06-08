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
    public class LongToChainIdJsonConverter : LongToZeroQLScalarJsonConverter<ChainId>
    {
        public LongToChainIdJsonConverter() { }
    }

    public class LongToNonceJsonConverter : LongToZeroQLScalarJsonConverter<Nonce>
    {
        public LongToNonceJsonConverter() { }
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
                return new ZeroQLScalar { Value = number.ToString() } as TZeroQLScalar;

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
