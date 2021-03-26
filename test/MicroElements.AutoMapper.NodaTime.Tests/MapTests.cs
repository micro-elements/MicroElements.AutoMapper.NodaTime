using System;
using AutoMapper;
using FluentAssertions;
using NodaTime;
using Xunit;

namespace MicroElements.AutoMapper.NodaTime.Tests
{
    public class MapTests
    {
        private Mapper Mapper { get; } = new(
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<NodaTimeProfile>();
            }));

        [Fact]
        public void ConfigurationShouldBeValid()
        {
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        DateTime CreateDateTime() => new DateTime(2021, 03, 26, 22, 34, 35);
        DateTime CreateDateNoTime() => new DateTime(2021, 03, 26);
        DateTime CreateDateTimeUtc() => new DateTime(2021, 03, 26, 22, 34, 35, DateTimeKind.Utc);
        DateTimeOffset CreateDateTimeOffset() => new DateTimeOffset(2021, 03, 26, 22, 34, 35, TimeSpan.FromHours(0));
        Instant CreateInstant() => Instant.FromDateTimeUtc(CreateDateTimeUtc());
        LocalDate CreateLocalDate() => new LocalDate(2021, 03, 26);
        LocalDateTime CreateLocalDateTime() => new LocalDateTime(2021, 03, 26, 22, 34, 35);


        [Fact]
        public void LocalDate()
        {
            Mapper.Map<DateTime, LocalDate>(CreateDateTime()).Should().Be(CreateLocalDate());
            Mapper.Map<LocalDate, DateTime>(CreateLocalDate()).Should().Be(CreateDateNoTime());
        }

        [Fact]
        public void LocalTime()
        {
            Mapper.Map<LocalTime, TimeSpan>(new LocalTime(22, 34, 35)).Should().Be(new TimeSpan(22, 34, 35));
            Mapper.Map<TimeSpan, LocalTime>(new TimeSpan(22, 34, 35)).Should().Be(new LocalTime(22, 34, 35));

            Mapper.Map<LocalTime, DateTime>(new LocalTime(22, 34, 35)).Should().Be(new DateTime(1, 1, 1, 22, 34, 35));
            Mapper.Map<DateTime, LocalTime>(new DateTime(1111, 11, 11, 22, 34, 35)).Should().Be(new LocalTime(22, 34, 35));
        }

        [Fact]
        public void LocalDateTime()
        {
            Mapper.Map<DateTime, LocalDateTime>(CreateDateTime()).Should().Be(CreateLocalDateTime());
            Mapper.Map<LocalDateTime, DateTime>(CreateLocalDateTime()).Should().Be(CreateDateTime());
        }

        [Fact]
        public void InstantTests()
        {
            Mapper.Map<Instant, DateTime>(CreateInstant()).Should().Be(CreateDateTimeUtc());
            Mapper.Map<DateTime, Instant>(CreateDateTimeUtc()).Should().Be(CreateInstant());

            Mapper.Map<Instant, DateTimeOffset>(CreateInstant()).Should().Be(CreateDateTimeOffset());
            Mapper.Map<DateTimeOffset, Instant>(CreateDateTimeOffset()).Should().Be(CreateInstant());
        }
    }
}
