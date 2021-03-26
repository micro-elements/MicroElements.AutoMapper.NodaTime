// Copyright (c) MicroElements. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using AutoMapper;
using NodaTime;

namespace MicroElements.AutoMapper.NodaTime
{
    /// <summary>
    /// Converts <see cref="LocalDate"/> to <see cref="DateTime"/> and back.
    /// </summary>
    public class LocalDateConverter :
        ITypeConverter<LocalDate, DateTime>,
        ITypeConverter<LocalDate?, DateTime?>,
        ITypeConverter<DateTime, LocalDate>,
        ITypeConverter<DateTime?, LocalDate?>
    {
        /// <inheritdoc />
        public DateTime Convert(LocalDate localDate, DateTime destination, ResolutionContext context)
            => localDate.ToDateTimeUnspecified();

        /// <inheritdoc />
        public DateTime? Convert(LocalDate? localDate, DateTime? destination, ResolutionContext context)
            => localDate?.ToDateTimeUnspecified();

        /// <inheritdoc />
        public LocalDate Convert(DateTime dateTime, LocalDate destination, ResolutionContext context)
            => new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);

        /// <inheritdoc />
        public LocalDate? Convert(DateTime? dateTime, LocalDate? destination, ResolutionContext context)
            => dateTime == null ? (LocalDate?)null : Convert(dateTime.Value, default, context);
    }
}
