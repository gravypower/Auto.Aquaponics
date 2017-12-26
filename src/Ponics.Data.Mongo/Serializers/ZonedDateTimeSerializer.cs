using System;
using MongoDB.Bson.Serialization;
using NodaTime;
using NodaTime.Text;

namespace Ponics.Data.Mongo.Serializers
{
    public class ZonedDateTimeSerializer : IBsonSerializer<ZonedDateTime>
    {
        private static ZonedDateTimeSerializer __instance = new ZonedDateTimeSerializer();

        /// <summary>
        /// Gets an instance of the ZonedDateTimeSerializer class.
        /// </summary>
        public static ZonedDateTimeSerializer Instance => __instance;

        object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Deserialize(context, args);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ZonedDateTime value)
        {
            context.Writer.WriteString(ZonedDateTimePattern.CreateWithInvariantCulture("G", DateTimeZoneProviders.Tzdb).Format(value));
        }

        public ZonedDateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var zonedDateTimeString = context.Reader.ReadString();
            var parseResult = ZonedDateTimePattern.CreateWithInvariantCulture("G", DateTimeZoneProviders.Tzdb).Parse(zonedDateTimeString);

            if (!parseResult.Success)
            {
                throw parseResult.Exception;
            }

            return parseResult.Value;
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            Serialize(context, args, value as ZonedDateTime? ?? new ZonedDateTime());
        }

        public Type ValueType => typeof(ZonedDateTime);
    }
}
