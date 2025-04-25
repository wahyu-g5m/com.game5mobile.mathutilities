using NUnit.Framework;
using UnityEditor;

namespace Toolbox.Tests
{
    public class MathUtilsTest : Editor
    {
        // Test positive values =====================================================

        [Test]
        public void MapOneInOneToTen_ToTenAndOneHundred_ReturnTen()
        {
            var expected = 10f;
            var actual = MathUtils.Map(1f, 1f, 10f, 10f, 100f);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MapFiveInOneToTen_ToTenAndOneHundred_ReturnFifty()
        {
            var expected = 50f;
            var actual = MathUtils.Map(5f, 1f, 10f, 10f, 100f);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MapTenInOneToTen_ToTenAndOneHundred_ReturnOneHundred()
        {
            var expected = 100f;
            var actual = MathUtils.Map(10f, 1f, 10f, 10f, 100f);

            Assert.AreEqual(expected, actual);
        }

        // Test negative values =====================================================

        [Test]
        public void MapMinusTenInMinusTenToMinusOne_ToTenAndOneHundred_ReturnTen()
        {
            var expected = 10f;
            var actual = MathUtils.Map(-10f, -10f, -1f, 10f, 100f);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MapMinusSixInMinusTenToMinusOne_ToTenAndOneHundred_ReturnFifty()
        {
            var expected = 50f;
            var actual = MathUtils.Map(-6f, -10f, -1f, 10f, 100f);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MapMinusOneInMinusTenToMinusOne_ToTenAndOneHundred_ReturnOneHundred()
        {
            var expected = 100f;
            var actual = MathUtils.Map(-1f, -10f, -1f, 10f, 100f);

            Assert.AreEqual(expected, actual);
        }
    }
}
