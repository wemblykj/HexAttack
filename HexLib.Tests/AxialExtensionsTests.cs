using Xunit;
using HexLib.Model;
using HexLib.Extensions;

namespace HexLib.Tests
{
    public class AxialExtensionsTests
    {
        [Fact]
        public void ToCube_ShouldConvertCoordinates()
        {
            var axial = new Axial(2, -1);
            var cube = axial.ToCube();

            Assert.Equal(2, cube.X);
            Assert.Equal(-1, cube.Y);
            Assert.Equal(axial.S, cube.Z);
        }

        [Fact]
        public void Add_ShouldAddCoordinates()
        {
            var a = new Axial(1, 2);
            var b = new Axial(3, -1);

            var result = a.Add(b);

            Assert.Equal(4, result.Q);
            Assert.Equal(1, result.R);
        }

        [Fact]
        public void Subtract_ShouldSubtractCoordinates()
        {
            var a = new Axial(1, 2);
            var b = new Axial(3, -1);

            var result = a.Subtract(b);

            Assert.Equal(-2, result.Q);
            Assert.Equal(3, result.R);
        }

        [Fact]
        public void Distance_ShouldReturnCorrectDistance()
        {
            var a = new Axial(0, 0);
            var b = new Axial(2, -1);

            var distance = a.Distance(b);

            // distance = (|0-2| + |0-(-1)| + |0-(-1)|) / 2 = (2 + 1 + 1) / 2 = 2
            Assert.Equal(2, distance);
        }

        [Fact]
        public void ToUnitDirection_ShouldNormalizeToUnit()
        {
            var a = new Axial(2, 0);
            var unit = a.ToUnitDirection();

            Assert.Equal(1, unit.Q);
            Assert.Equal(0, unit.R);
        }

        [Fact]
        public void ToUnitDirection_ZeroVector_ReturnsZero()
        {
            var zero = new Axial(0, 0);
            var result = zero.ToUnitDirection();

            Assert.Equal(0, result.Q);
            Assert.Equal(0, result.R);
        }
    }
}