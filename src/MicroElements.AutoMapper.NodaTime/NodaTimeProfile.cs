// Copyright (c) MicroElements. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using AutoMapper;
using NodaTime;

namespace MicroElements.AutoMapper.NodaTime
{
    /// <summary>
    /// NodaTime converters.
    /// </summary>
    public class NodaTimeProfile : Profile
    {
        private static readonly LocalDateConverter _localDateConverter = new LocalDateConverter();
        private static readonly LocalTimeConverter _localTimeConverter = new LocalTimeConverter();
        private static readonly LocalDateTimeConverter _localDateTimeConverter = new LocalDateTimeConverter();
        private static readonly InstantConverter _instantConverter = new InstantConverter();

        /// <summary>
        /// Initializes a new instance of the <see cref="NodaTimeProfile"/> class.
        /// </summary>
        public NodaTimeProfile()
        {
            // LocalDate
            CreateMap<LocalDate, DateTime>().ConvertUsing(_localDateConverter);
            CreateMap<LocalDate?, DateTime?>().ConvertUsing(_localDateConverter);
            CreateMap<DateTime, LocalDate>().ConvertUsing(_localDateConverter);
            CreateMap<DateTime?, LocalDate?>().ConvertUsing(_localDateConverter);

            // LocalTime
            CreateMap<LocalTime, TimeSpan>().ConvertUsing(_localTimeConverter);
            CreateMap<LocalTime?, TimeSpan?>().ConvertUsing(_localTimeConverter);
            CreateMap<LocalTime, DateTime>().ConvertUsing(_localTimeConverter);
            CreateMap<LocalTime?, DateTime?>().ConvertUsing(_localTimeConverter);
            CreateMap<TimeSpan, LocalTime>().ConvertUsing(_localTimeConverter);
            CreateMap<TimeSpan?, LocalTime?>().ConvertUsing(_localTimeConverter);
            CreateMap<DateTime, LocalTime>().ConvertUsing(_localTimeConverter);
            CreateMap<DateTime?, LocalTime?>().ConvertUsing(_localTimeConverter);

            // LocalDateTime
            CreateMap<LocalDateTime, DateTime>().ConvertUsing(_localDateTimeConverter);
            CreateMap<LocalDateTime?, DateTime?>().ConvertUsing(_localDateTimeConverter);
            CreateMap<DateTime, LocalDateTime>().ConvertUsing(_localDateTimeConverter);
            CreateMap<DateTime?, LocalDateTime?>().ConvertUsing(_localDateTimeConverter);

            // Instant
            CreateMap<Instant, DateTime>().ConvertUsing(_instantConverter);
            CreateMap<Instant?, DateTime?>().ConvertUsing(_instantConverter);
            CreateMap<Instant, DateTimeOffset>().ConvertUsing(_instantConverter);
            CreateMap<Instant?, DateTimeOffset?>().ConvertUsing(_instantConverter);
            CreateMap<DateTime, Instant>().ConvertUsing(_instantConverter);
            CreateMap<DateTime?, Instant?>().ConvertUsing(_instantConverter);
            CreateMap<DateTimeOffset, Instant>().ConvertUsing(_instantConverter);
            CreateMap<DateTimeOffset?, Instant?>().ConvertUsing(_instantConverter);
        }
    }
}
