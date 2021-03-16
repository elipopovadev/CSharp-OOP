namespace PointInRectangle
{
    class Rectangle
    {
        public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            this.TopLeftPoint = topLeftPoint;
            this.BottomRightPoint = bottomRightPoint;
        }

        public Point TopLeftPoint  { get; set; }
        public Point BottomRightPoint { get; set; }

        public bool Contains (Point point)
        {
            bool XIsInside = false;
            bool YIsInside = false;
            if ( point.X >= TopLeftPoint.X && point.X <= BottomRightPoint.X)
            {
                XIsInside = true;
            }

            if(point.Y <= TopLeftPoint.Y && point.Y >= BottomRightPoint.Y)
            {
                YIsInside = true;
            }

            return XIsInside && YIsInside;
        }
    }
}
