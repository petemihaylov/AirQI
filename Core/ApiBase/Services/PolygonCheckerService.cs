using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using ApiBase.Models;
using Newtonsoft.Json;

namespace ApiBase.Services
***REMOVED***
    public class Point
    ***REMOVED***
        public float X ***REMOVED*** get; set;***REMOVED***
        public float Y ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***

    public static class PolygonCheckerService
    ***REMOVED***

        public static bool IsInPolygon(List<SlaMarker> collection, double Y, double X)
        ***REMOVED***
            List<Point> points = new List<Point>();

            collection.ForEach(sla =>
            ***REMOVED***
                List<Feature> features = JsonConvert.DeserializeObject<List<Feature>>(sla.LocationBoundaries);

                features.ForEach(f =>
                ***REMOVED***
                    f.geometry.Coordinates[0].ForEach(p =>
                    ***REMOVED***
                        points.Add(new Point()***REMOVED***X = p[0],Y = p[1]***REMOVED***);
                   ***REMOVED***);
               ***REMOVED***);
           ***REMOVED***);

            return PointInPolygon((float) X, (float) Y, points.ToArray());
       ***REMOVED***


        // Determine whether a point is inside a polygon in C#,  July 28, 2014 by Rod Stephens
        // Return True if the point is in the polygon.
        private static bool PointInPolygon(float X, float Y, Point[] Points)
        ***REMOVED***
            // Get the angle between the point and the
            // first and last vertices.
            int max_point = Points.Length - 1;
            float total_angle = GetAngle(
                Points[max_point].X, Points[max_point].Y,
                X, Y,
                Points[0].X, Points[0].Y);

            // Add the angles from the point
            // to each other pair of vertices.
            for (int i = 0; i < max_point; i++)
            ***REMOVED***
                total_angle += GetAngle(
                    Points[i].X, Points[i].Y,
                    X, Y,
                    Points[i + 1].X, Points[i + 1].Y);
           ***REMOVED***

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            // The following statement was changed. See the comments.
            //return (Math.Abs(total_angle) > 0.000001);
            return (Math.Abs(total_angle) > 1);
       ***REMOVED***

        public static float GetAngle(float Ax, float Ay,
    float Bx, float By, float Cx, float Cy)
        ***REMOVED***
            // Get the dot product.
            float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

            // Get the cross product.
            float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

            // Calculate the angle.
            return (float)Math.Atan2(cross_product, dot_product);
       ***REMOVED***

        public static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        ***REMOVED***
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
       ***REMOVED***
        private static float DotProduct(float Ax, float Ay,
    float Bx, float By, float Cx, float Cy)
        ***REMOVED***
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the dot product.
            return (BAx * BCx + BAy * BCy);
       ***REMOVED***
   ***REMOVED***
***REMOVED***

