using Lab1;
using Xunit;

namespace Lab1Tests;

public class MatrixServiceTests
{
    public static IEnumerable<object[]> TestCountNegativesInEachRowData()
    {
        yield return new object[]
        {
            new List<List<int>>
            {
                new List<int>() { 1, 2, 9, 3, -6, -4, 7 },
                new List<int>() { -5, 0, 7, 8, -8, 6, 1 },
                new List<int>() { 3, 0, 5, 3, 4, 9, -4 },
                new List<int>() { -6, 0, -1, 0, -9, 8, -5 },
            },
            new List<int?>()
            {
                null, 2, 1, 4,
            }
        };

        yield return new object[]
        {
            new List<List<int>>
            {
                new List<int>() { 5, 4, 1, -5, -5, -2, -6, 2, 4 },
                new List<int>() { 5, -1, -8, 4, 5, -2, -3, -5, 5 },
                new List<int>() { 6, -3, 2, -6, 3, 3, 8, 1, -5 },
                new List<int>() { 7, 5, 2, -3, -2, 4, -9, -6, 2 },
            },
            new List<int?>()
            {
                null, null, null, null,
            }
        };

        yield return new object[]
        {
            new List<List<int>>
            {

            },
            new List<int?>()
            {

            }
        };
    }

    public static IEnumerable<object[]> TestFindSaddlePointsData()
    {
        yield return new object[]
        {
            new List<List<int>>
            {
                new List<int>() { 1, 2, 9, 3 },
                new List<int>() { -5, 0, -1, -2 },
                new List<int>() { 1, 0, 5, 3 },
                new List<int>() { -6, 0, -1, 0 },
            },
            new List<List<int>>()
            {
                new List<int>() { 1, 1 },
                new List<int>() { 3, 1 },
            }
        };

        yield return new object[]
        {
            new List<List<int>>
            {
                new List<int>() { 5, 4, 1, -5, -5, -2, -6, 2, 4 },
                new List<int>() { 5, -1, -8, 4, 5, -2, -3, -5, 5 },
                new List<int>() { 6, -3, 2, -6, 3, 3, 8, 1, -5 },
                new List<int>() { 7, 5, 2, -3, -2, 4, -9, -6, 2 },
            },
            new List<List<int>>()
            {
                new List<int>() { 0, 0 },
                new List<int>() { 1, 0 },
            }
        };

        yield return new object[]
        {
            new List<List<int>>
            {
                new List<int>() { 7, 4, 1, -5, -5, -2, -6, 2, 4 },
                new List<int>() { 8, -1, -8, 4, 5, -2, -3, -5, 5 },
                new List<int>() { 6, -3, 2, -6, 3, 3, 8, 1, -5 },
                new List<int>() { 7, 5, 2, -3, -2, 4, -9, -6, 2 },
            },
            new List<List<int>>()
            {

            }
        };

        yield return new object[]
        {
            new List<List<int>>
            {
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
            },
            new List<List<int>>()
            {

            }
        };

        yield return new object[]
        {
            new List<List<int>>
            {

            },
            new List<List<int>>()
            {

            }
        };
    }

    [Theory]
    [MemberData(nameof(TestCountNegativesInEachRowData))]
    public void CountNegativesInEachRow_ShouldReturnCorrectResult(
        List<List<int>> matrix,
        List<int?> correctResult)
    {
        var service = new MatrixService();

        var result = service.CountNegativesInEachRow(matrix);

        Assert.Equal(correctResult.Count, result.Count);
        for (int i = 0; i < correctResult.Count; ++i)
        {
            Assert.Equal(correctResult[i], result[i]);
        }
    }

    [Theory]
    [MemberData(nameof(TestFindSaddlePointsData))]
    public void FindSaddlePoints_ShouldReturnCorrectResult(
        List<List<int>> matrix,
        List<List<int>> correctResult)
    {
        var service = new MatrixService();

        var result = service.FindSaddlePoints(matrix);

        Assert.Equal(correctResult.Count, result.Count);
        for (int i = 0; i < correctResult.Count; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                Assert.Equal(correctResult[i][j], result[i][j]);
            }
        }
    }
}