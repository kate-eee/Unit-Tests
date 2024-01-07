namespace Lab1;

public class MatrixService
{
    public List<int?> CountNegativesInEachRow(List<List<int>> matrix)
    {
        int width = matrix.Count;
        if (width == 0)
        {
            return new List<int?>();
        }

        int length = matrix[0].Count;
        var res = new List<int?>();
        for (int i = 0; i < width; ++i)
        {
            bool hasZero = false;
            int count = 0;
            for (int j = 0; j < length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    hasZero = true;
                }
                if (matrix[i][j] < 0)
                {
                    ++count;
                }
            }

            if (hasZero)
            {
                res.Add(count);
            }
            else
            {
                res.Add(null);
            }
        }

        return res;
    }

    public List<List<int>> FindSaddlePoints(List<List<int>> matrix)
    {
        int width = matrix.Count;
        if (width == 0)
        {
            return new List<List<int>>();
        }
        int length = matrix[0].Count;
        if (length == 0)
        {
            return new List<List<int>>();
        }

        var columnMinIndexes = new List<List<int>>();
        for (int i = 0; i < length; ++i)
        {
            int? min = null;
            columnMinIndexes.Add(new List<int>());
            for (int j = 0; j < width; ++j)
            {
                if (min == null)
                {
                    min = matrix[j][i];
                }
                else if (min > matrix[j][i])
                {
                    min = matrix[j][i];
                }
            }
            for (int j = 0; j < width; ++j)
            {
                if (matrix[j][i] == min)
                {
                    columnMinIndexes[i].Add(j);
                }
            }

        }
        var rowMaxIndexes = new List<List<int>>();
        for (int i = 0; i < width; ++i)
        {
            int? max = null;
            rowMaxIndexes.Add(new List<int>());
            for (int j = 0; j < length; ++j)
            {
                if (max == null)
                {
                    max = matrix[i][j];
                }
                else if (max < matrix[i][j])
                {
                    max = matrix[i][j];
                }
            }
            for (int j = 0; j < length; ++j)
            {
                if (matrix[i][j] == max)
                {
                    rowMaxIndexes[i].Add(j);
                }
            }

        }

        var res = new List<List<int>>();
        for (int i = 0; i < columnMinIndexes.Count; ++i)
        {
            for (int j = 0; j < columnMinIndexes[i].Count; ++j)
            {
                foreach (var e in rowMaxIndexes[columnMinIndexes[i][j]])
                {
                    if (e == i)
                    {
                        res.Add(new List<int>());
                        res[^1].Add(columnMinIndexes[i][j]);
                        res[^1].Add(i);
                    }
                }
            }
        }

        return res;
    }
}