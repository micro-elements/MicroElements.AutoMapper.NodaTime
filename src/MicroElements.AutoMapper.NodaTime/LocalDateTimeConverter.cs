// Copyright (c) MicroElements. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using AutoMapper;
using NodaTime;
using NodaTime.Extensions;

namespace MicroElements.AutoMapper.NodaTime
{
    /// <summary>
    /// Converts <see cref="LocalDateTime"/> to <see cref="DateTime"/> and back.
    /// </summary>
    public class LocalDateTimeConverter :
        ITypeConverter<LocalDateTime, DateTime>,
        ITypeConverter<LocalDateTime?, DateTime?>,
        ITypeConverter<DateTime, LocalDateTime>,
        ITypeConverter<DateTime?, LocalDateTime?>
    {
        /// <inheritdoc />
        public DateTime Convert(LocalDateTime localDateTime, DateTime destination, ResolutionContext context)
            => localDateTime.ToDateTimeUnspecified();

        /// <inheritdoc />
        public DateTime? Convert(LocalDateTime? localDateTime, DateTime? destination, ResolutionContext context)
            => localDateTime?.ToDateTimeUnspecified();

        /// <inheritdoc />
        public LocalDateTime Convert(DateTime dateTime, LocalDateTime destination, ResolutionContext context)
            => dateTime.ToLocalDateTime();

        /// <inheritdoc />
        public LocalDateTime? Convert(DateTime? dateTime, LocalDateTime? destination, ResolutionContext context)
            => dateTime?.ToLocalDateTime();
    }
}
