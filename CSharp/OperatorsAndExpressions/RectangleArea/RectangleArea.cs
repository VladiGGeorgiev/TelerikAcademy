/* 3. Write an expression that calculates rectangle’s area by given width and height.
*/
using System;

class RectangleArea
{
    static void Main()
    {
        int rectangleWidth = 5;
        int rectangleHeight = 10;

        int rectangleArea = rectangleHeight * rectangleWidth;
        Console.WriteLine("The rectangle area is: {0}", rectangleArea);
    }
}
