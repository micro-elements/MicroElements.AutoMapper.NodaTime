# MicroElements.AutoMapper.NodaTime
Allows to use NodaTime with AutoMapper.

## Statuses
[![License](https://img.shields.io/github/license/micro-elements/MicroElements.AutoMapper.NodaTime.svg)](https://raw.githubusercontent.com/micro-elements/MicroElements.AutoMapper.NodaTime/master/LICENSE)
[![NuGetVersion](https://img.shields.io/nuget/v/MicroElements.AutoMapper.NodaTime.svg)](https://www.nuget.org/packages/MicroElements.AutoMapper.NodaTime)
![NuGetDownloads](https://img.shields.io/nuget/dt/MicroElements.AutoMapper.NodaTime.svg)
[![MyGetVersion](https://img.shields.io/myget/micro-elements/v/MicroElements.AutoMapper.NodaTime.svg)](https://www.myget.org/feed/micro-elements/package/nuget/MicroElements.AutoMapper.NodaTime)

[![Build](https://github.com/micro-elements/MicroElements.AutoMapper.NodaTime/actions/workflows/github_build_and_publish.yml/badge.svg)](https://github.com/micro-elements/MicroElements.AutoMapper.NodaTime/actions/workflows/github_build_and_publish.yml)
[![Travis](https://img.shields.io/travis/micro-elements/MicroElements.AutoMapper.NodaTime/master.svg?logo=travis)](https://travis-ci.org/micro-elements/MicroElements.AutoMapper.NodaTime)
[![Coverage Status](https://img.shields.io/coveralls/micro-elements/MicroElements.AutoMapper.NodaTime.svg)](https://coveralls.io/r/micro-elements/MicroElements.AutoMapper.NodaTime)
[![Gitter](https://img.shields.io/gitter/room/micro-elements/MicroElements.AutoMapper.NodaTime.svg)](https://gitter.im/micro-elements/MicroElements.AutoMapper.NodaTime)

## Installation

### Package Reference:

```
dotnet add package MicroElements.AutoMapper.NodaTime
```

## Usage

``` csharp
var mapper = new Mapper(
    new MapperConfiguration(cfg =>
    {
        // Adds NodaTime converters to AutoMapper.
        cfg.AddProfile<NodaTimeProfile>();
    }));

var localDateTime = new LocalDateTime(2020, 03, 26, 23, 34, 45);
var dateTime = mapper.Map<LocalDateTime, DateTime>(localDateTime);
```

## Build
Linux: Run `build.sh`

## License
This project is licensed under the MIT license. See the [LICENSE] file for more info.


[LICENSE]: https://raw.githubusercontent.com/micro-elements/MicroElements.AutoMapper.NodaTime/master/LICENSE
