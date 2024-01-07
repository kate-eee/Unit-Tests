namespace Lab1;

public class ArrayService
{
    public double ProductOfPositives(double[] array)
    {
        double productOfPositives = 1.0;
        foreach (double num in array)
        {
            if (num > 0)
            {
                productOfPositives *= num;
            }
        }

        return productOfPositives;
    }

    public double SumBeforeMin(double[] array)
    {
        int? minElementIndex = null;
        for (int i = 0; i < array.Length; i++)
        {
            if (minElementIndex is null)
            {
                minElementIndex = i;
            }
            else if (array[i] < array[(int)minElementIndex])
            {
                minElementIndex = i;
            }
        }
        double sumBeforeMin = 0.0;
        for (int i = 0; i < minElementIndex; i++)
        {
            sumBeforeMin += array[i];
        }

        return sumBeforeMin;
    }

    public double[] EvenIndexElementsSorted(double[] array)
    {
        return array.Where((value, index) => index % 2 == 0).OrderBy(x => x).ToArray();
    }

    public double[] OddIndexElementsSorted(double[] array)
    {
        return array.Where((value, index) => index % 2 != 0).OrderBy(x => x).ToArray();
    }
}