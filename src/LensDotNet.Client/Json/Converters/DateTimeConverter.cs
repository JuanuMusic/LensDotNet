using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LensDotNet.Client.Json.Converters
{
    internal class UnixTimestampToDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.UnixEpoch.AddSeconds(reader.GetInt64());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            Int32 unixTimestamp = (int)value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            writer.WriteStringValue(unixTimestamp.ToString());
        }
    }
}
