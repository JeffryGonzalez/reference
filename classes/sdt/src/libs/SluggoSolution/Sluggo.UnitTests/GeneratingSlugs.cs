using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using NSubstitute;

namespace Sluggo.UnitTests;
public class GeneratingSlugs
{
    private readonly SlugGenerator _slugGenerator;

    public GeneratingSlugs()
    {
   
        _slugGenerator = new SlugGenerator();
    }

    [Theory]
    [InlineData("bird", "bird")]
    [InlineData("BiRd", "bird")]
    [InlineData(" bIrd   ", "bird")]
    [InlineData("dog-stuff", "dog-stuff")]

    public async Task CanGenerateSlugsFrom(string input, string expected)
    {
       
        var slug = await _slugGenerator.GenerateSlugAsync(input, _ => Task.FromResult(true));

        Assert.Equal(expected, slug);
    }

    [Theory]
    [InlineData("bird", "bird-a")]
    [InlineData("dog", "dog-z")]

    public async Task NeedsUniqueSlugs(string input, string expected)
    {
        var cb = Substitute.For<Func<string, Task<bool>>>();
        cb("bird-a").Returns(true);
        cb("dog-z").Returns(true);
        var slug = await _slugGenerator.GenerateSlugAsync(input, cb);

        Assert.Equal(expected, slug);
    }

    [Fact]
    public async Task FallsBackToGuid()
    {
        var cb = Substitute.For<Func<string, Task<bool>>>();
        cb(Arg.Any<string>()).Returns(false);
        var slug = await _slugGenerator.GenerateSlugAsync("pizza",cb);

        Assert.StartsWith("pizza", slug);
        var lengthOfGuid = Guid.NewGuid().ToString().Length;
        Assert.Equal(5  + lengthOfGuid, slug.Length);
    }

}
