using Lab1;
using Xunit;

namespace Lab1Tests;

public class ArrayServiceTests
{
    public static IEnumerable<object[]> TestProductOfPositivesData()
    {
        yield return new object[]
        {
            new double[]
            {
                -2.0, -7.0, 8.0, 4.0, 43.0, 4.0, 0.0, -32.0, 342.0, 94.0
            },
            176942592.0,
        };

        yield return new object[]
        {
            new double[]
            {
                -2.334, -7.854, 8.546, 4.654654, 43.64564, 4.6456, 0.0, -32.6546, 342.6546, 94.65646
            },
            261601238.77844024,
        };

        yield return new object[]
        {
            new double[]
            {
                63.26886294698997, -80.559391782926, 43.74789015511541,
                8.77831932208074, -5.903705312456853, 19.32926119052936,
                69.98867708649402, 44.98002430542496, -73.38849906345492, 71.04020429261013

            },
            105032921106.27675,
        };

        yield return new object[]
        {
            new double[]
            {

            },
            1,
        };
    }

    public static IEnumerable<object[]> TestSumBeforeMinData()
    {
        yield return new object[]
        {
            new double[]
            {
                -2.0, -7.0, 8.0, 4.0, 43.0, 4.0, 0.0, -32.0, 342.0, 94.0
            },
            50.0,
        };

        yield return new object[]
        {
            new double[]
            {
                -2.334, -7.854, 8.546, 4.654654, 43.64564, 4.6456, 0.0, -32.6546, 342.6546, 94.65646
            },
            51.303894,
        };

        yield return new object[]
        {
            new double[]
            {
                -2534535.334, -7.854, 8.546, 4.654654, 43.64564, 4.6456, 0.0, -32.6546, 342.6546, 94.65646
            },
            0.0,
        };
    }

    public static IEnumerable<object[]> TestEvenIndexElementsSortedData()
    {
        yield return new object[]
        {
            new double[]
            {
                -2.0, -7.0, 8.0, 4.0, 43.0, 4.0, 0.0, -32.0, 342.0, 94.0,
            },
            new double[]
            {
                -2.0, 0.0, 8.0, 43.0, 342.0,
            }
        };

        yield return new object[]
        {
            new double[]
            {
                61.12795266585314, 24.39418022504173, 1.8079440936371483,
                77.87112281262236, 7.021910803999598, 72.92995572131707,
                33.34196801556111, 32.97504857878335, 90.9916199582278, 15.638955358791652

            },
            new double[]
            {
                1.8079440936371483, 7.021910803999598, 33.34196801556111,
                61.12795266585314, 90.9916199582278
            }
        };

        yield return new object[]
        {
            new double[]
            {

            },
            new double[]
            {

            }
        };
    }

    public static IEnumerable<object[]> TestOddIndexElementsSortedData()
    {
        yield return new object[]
        {
            new double[]
            {
                -2.0, -7.0, 8.0, 4.0, 43.0, 4.0, 0.0, -32.0, 342.0, 94.0,
            },
            new double[]
            {
                -32.0, -7.0, 4.0, 4.0, 94.0,
            }
        };

        yield return new object[]
        {
            new double[]
            {
                61.12795266585314, 24.39418022504173, 1.8079440936371483,
                77.87112281262236, 7.021910803999598, 72.92995572131707,
                33.34196801556111, 32.97504857878335, 90.9916199582278, 15.638955358791652

            },
            new double[]
            {
                15.638955358791652, 24.39418022504173, 32.97504857878335,
                72.92995572131707, 77.87112281262236
            }
        };

        yield return new object[]
        {
            new double[]
            {
                61.12795266585314,
            },
            new double[]
            {

            }
        };
    }

    [Theory]
    [MemberData(nameof(TestProductOfPositivesData))]
    public void ProductOfPositives_ShouldReturnCorrectResult(
        double[] array,
        double correctResult)
    {
        var service = new ArrayService();

        double result = service.ProductOfPositives(array);

        Assert.Equal(correctResult, result);
    }

    [Theory]
    [MemberData(nameof(TestSumBeforeMinData))]
    public void SumBeforeMin_ShouldReturnCorrectResult(
        double[] array,
        double correctResult)
    {
        var service = new ArrayService();

        double result = service.SumBeforeMin(array);

        Assert.Equal(correctResult, result);
    }

    [Theory]
    [MemberData(nameof(TestEvenIndexElementsSortedData))]
    public void EvenIndexElementsSorted_ShouldReturnCorrectResult(
        double[] array,
        double[] correctResult)
    {
        var service = new ArrayService();

        double[] result = service.EvenIndexElementsSorted(array);

        Assert.Equal(correctResult.Length, result.Length);
        for (int i = 0; i < correctResult.Length; ++i)
        {
            Assert.Equal(correctResult[i], result[i]);
        }
    }

    [Theory]
    [MemberData(nameof(TestOddIndexElementsSortedData))]
    public void OddIndexElementsSorted_ShouldReturnCorrectResult(
        double[] array,
        double[] correctResult)
    {
        var service = new ArrayService();

        double[] result = service.OddIndexElementsSorted(array);

        Assert.Equal(correctResult.Length, result.Length);
        for (int i = 0; i < correctResult.Length; ++i)
        {
            Assert.Equal(correctResult[i], result[i]);
        }
    }
}