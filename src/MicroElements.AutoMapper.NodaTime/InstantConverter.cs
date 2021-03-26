// Copyright (c) MicroElements. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using AutoMapper;
using NodaTime;
using NodaTime.Extensions;

namespace MicroElements.AutoMapper.NodaTime
{
    /// <summary>
    /// Converts <see cref="Instant"/> to <see cref="DateTime"/>, <see cref="DateTimeOffset"/> and back.
    /// </summary>
    public class InstantConverter :
        ITypeConverter<Instant, DateTime>,
        ITypeConverter<Instant?, DateTime?>,
        ITypeConverter<Instant, DateTimeOffset>,
        ITypeConverter<Instant?, DateTimeOffset?>,
        ITypeConverter<DateTime, Instant>,
        ITypeConverter<DateTime?, Instant?>,
        ITypeConverter<DateTimeOffset, Instant>,
        ITypeConverter<DateTimeOffset?, Instant?>
    {
        /// <inheritdoc />
        public DateTime Convert(Instant instant, DateTime destination, ResolutionContext context)
            => instant.ToDateTimeUtc();

        /// <inheritdoc />
        public DateTime? Convert(Instant? instant, DateTime? destination, ResolutionContext context)
            => instant?.ToDateTimeUtc();

        /// <inheritdoc />
        public DateTimeOffset Convert(Instant instant, DateTimeOffset destination, ResolutionContext context)
            => instant.ToDateTimeOffset();

        /// <inheritdoc />
        public DateTimeOffset? Convert(Instant? instant, DateTimeOffset? destination, ResolutionContext context)
            => instant?.ToDateTimeOffset();

        /// <inheritdoc />
        public Instant Convert(DateTime dateTime, Instant destination, ResolutionContext context)
            => dateTime.DateTimeToInstant();

        /// <inheritdoc />
        public Instant? Convert(DateTime? dateTime, Instant? destination, ResolutionContext context)
            => dateTime?.DateTimeToInstant();

        /// <inheritdoc />
        public Instant Convert(DateTimeOffset dateTimeOffset, Instant destination, ResolutionContext context)
            => dateTimeOffset.ToInstant();

        /// <inheritdoc />
        public Instant? Convert(DateTimeOffset? dateTimeOffset, Instant? destination, ResolutionContext context)
            => dateTimeOffset?.ToInstant();
    }

    internal static partial class ConverterExtensions
    {
        internal static Instant DateTimeToInstant(this DateTime dateTime)
        {
            var utcDateTime = dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
                : dateTime.ToUniversalTime();
            return utcDateTime.ToInstant();
        }
    }
}
