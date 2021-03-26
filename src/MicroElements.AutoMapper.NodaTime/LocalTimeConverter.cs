// Copyright (c) MicroElements. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using AutoMapper;
using NodaTime;

namespace MicroElements.AutoMapper.NodaTime
{
    /// <summary>
    /// Converts <see cref="LocalTime"/> to <see cref="DateTime"/>, <see cref="TimeSpan"/> and back.
    /// </summary>
    public class LocalTimeConverter :
        ITypeConverter<LocalTime, TimeSpan>,
        ITypeConverter<LocalTime?, TimeSpan?>,
        ITypeConverter<TimeSpan, LocalTime>,
        ITypeConverter<TimeSpan?, LocalTime?>,
        ITypeConverter<LocalTime, DateTime>,
        ITypeConverter<LocalTime?, DateTime?>,
        ITypeConverter<DateTime, LocalTime>,
        ITypeConverter<DateTime?, LocalTime?>
    {
        /// <inheritdoc />
        public TimeSpan Convert(LocalTime localTime, TimeSpan destination, ResolutionContext context)
            => localTime.LocalTimeToTimeSpan();

        /// <inheritdoc />
        public TimeSpan? Convert(LocalTime? localTime, TimeSpan? destination, ResolutionContext context)
            => localTime?.LocalTimeToTimeSpan();

        /// <inheritdoc />
        public LocalTime Convert(TimeSpan timeSpan, LocalTime destination, ResolutionContext context)
            => timeSpan.TimeSpanToLocalTime();

        /// <inheritdoc />
        public LocalTime? Convert(TimeSpan? timeSpan, LocalTime? destination, ResolutionContext context)
            => timeSpan?.TimeSpanToLocalTime();

        /// <inheritdoc />
        public DateTime Convert(LocalTime localTime, DateTime destination, ResolutionContext context)
            => localTime.LocalTimeToDateTime();

        /// <inheritdoc />
        public DateTime? Convert(LocalTime? localTime, DateTime? destination, ResolutionContext context)
            => localTime?.LocalTimeToDateTime();

        /// <inheritdoc />
        public LocalTime Convert(DateTime dateTime, LocalTime destination, ResolutionContext context)
            => dateTime.DateTimeToLocalTime();

        /// <inheritdoc />
        public LocalTime? Convert(DateTime? dateTime, LocalTime? destination, ResolutionContext context)
            => dateTime?.DateTimeToLocalTime();
    }

    internal static partial class ConverterExtensions
    {
        internal static TimeSpan LocalTimeToTimeSpan(this LocalTime localTime)
            => new TimeSpan(localTime.TickOfDay);

        internal static LocalTime TimeSpanToLocalTime(this TimeSpan timeSpan)
            => LocalTime.FromTicksSinceMidnight(timeSpan.Ticks);

        internal static DateTime LocalTimeToDateTime(this LocalTime localTime)
            => new LocalDate(1, 1, 1).At(localTime).ToDateTimeUnspecified();

        internal static LocalTime DateTimeToLocalTime(this DateTime dateTime)
            => LocalDateTime.FromDateTime(dateTime).TimeOfDay;
    }
}
