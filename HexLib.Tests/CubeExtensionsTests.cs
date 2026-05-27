// Tests/HexLib.Tests/CubeExtensionsTests.cs
using Xunit;
using HexLib.Model;
using HexLib.Extensions;

namespace HexLib.Tests
{
    public class CubeExtensionsTests
    {
        [Fact]
        public void ToAxial_ShouldRoundTripWithToCube()
        {
            var original = new Axial(3, -2);
            var cube = original.ToCube();
            var back = cube.ToAxial();

            Assert.Equal(original.Q, back.Q);
            Assert.Equal(original.R, back.R);
        }

        [Fact]
        public void ToAxial_IntegerCube_MapsCoordinates()
        {
            var cube = new Cube { X = 1, Y = -1, Z = 0 };
            var axial = cube.ToAxial();

            Assert.Equal(1, axial.Q);
            Assert.Equal(-1, axial.R);
        }
    }
}