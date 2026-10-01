using System;

namespace Rectangles;

public static class RectanglesTask
{
    // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        // Между замкнутыми отрезками [aStart, aEnd] и [bStart, bEnd] есть общая точка
        // тогда и только тогда, когда начало одного не больше конца другого и наоборот.
        return HasCommonPoint(r1.Left, r1.Right, r2.Left, r2.Right) &&
               HasCommonPoint(r1.Top, r1.Bottom, r2.Top, r2.Bottom);
    }

    // Площадь пересечения прямоугольников
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        return OverlapLength(r1.Left, r1.Right, r2.Left, r2.Right) *
               OverlapLength(r1.Top, r1.Bottom, r2.Top, r2.Bottom);
    }

    // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
    // Иначе вернуть -1
    // Если прямоугольники совпадают, можно вернуть номер любого из них.
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        if (IsInside(r1, r2))
            return 0; // r1 внутри r2 (или прямоугольники совпадают)
        if (IsInside(r2, r1))
            return 1; // r2 внутри r1
        return -1;
    }

    // Есть ли у отрезков [aStart, aEnd] и [bStart, bEnd] общая точка
    private static bool HasCommonPoint(int aStart, int aEnd, int bStart, int bEnd)
    {
        return Math.Max(aStart, bStart) <= Math.Min(aEnd, bEnd);
    }

    // Длина перекрытия отрезков [aStart, aEnd] и [bStart, bEnd] (0, если общего нет)
    private static int OverlapLength(int aStart, int aEnd, int bStart, int bEnd)
    {
        return Math.Max(0, Math.Min(aEnd, bEnd) - Math.Max(aStart, bStart));
    }

    // Целиком ли inner лежит внутри outer (границы считаются частью прямоугольника)
    private static bool IsInside(Rectangle inner, Rectangle outer)
    {
        return outer.Left <= inner.Left &&
               outer.Top <= inner.Top &&
               inner.Right <= outer.Right &&
               inner.Bottom <= outer.Bottom;
    }
}
