using FluentAssertions;

using Riok.Mapperly.Abstractions;

namespace Mapperly;
//https://mapperly.riok.app/docs/configuration/queryable-projections/
public class Basics
{
    [Fact]
    public void BasicMapping()
    {
        DateTime when = new(1969, 4, 20);
        Car car = new() { Make = "Ford", Model = "Bronco", Manufactured = when };
        CarDto dto = car.MapCarToCarDto();
        dto.Make.Should().Be("Ford");
        dto.Year.Should().Be(1969);
        dto.Summary.Should().Be("Ford Bronco from 1969");
    }
}

public class Car
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateTime Manufactured { get; set; }
}

public class CarDto
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }

    public string Summary { get; set; } = string.Empty;
}

[Mapper]
public static partial class CarMapper
{

    public static CarDto MapCarToCarDto(this Car car)
    {
        CarDto r = CarToCarDto(car);
        r.Summary = $"{r.Make} {r.Model} from {r.Year}";
        return r;

    }
    private static int ManufacturedToYear(DateTime t)
    {
        return t.Year;
    }

    [MapProperty(nameof(Car.Manufactured), nameof(CarDto.Year))]
    private static partial CarDto CarToCarDto(Car car);
}