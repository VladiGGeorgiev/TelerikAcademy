/* 9. Write an expression that checks for given point (x, y) 
 * if it is within the circle K( (1,1), 3) and out of 
 * the rectangle R(top=1, left=-1, width=6, height=2).
*/
using System;

class PointWithinCircleAndRectangle
{
    static void Main()
    {
        sbyte radius = 3;
        sbyte circleX = 1;
        sbyte circleY = 1;

        float pointX = -2f;
        float pointY = 2f;

        bool checkInCircle = (pointX - circleX) * (pointX - circleX) + 
            (pointY - circleY) * (pointY - circleY) < (radius * radius);

        sbyte rectangleX = -1;
        sbyte rectangleY = 1;
        sbyte rectangleWidth = 6;
        sbyte rectangleHeight = 2;

        bool checkInOutOfRectangle = (pointX < rectangleX) && (pointX > (rectangleX + rectangleWidth)) && 
            (pointY > rectangleY) && (pointY < (rectangleY - rectangleHeight));

        if (checkInCircle && checkInOutOfRectangle)
        {
            Console.WriteLine("The point is in the rectangle and out of the circle ");
        }
        else
        {
            Console.WriteLine("Wrong X and Y point.");
        }
    }
}