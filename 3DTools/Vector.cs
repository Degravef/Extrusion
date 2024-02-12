namespace _3DTools;

public class Vector
{
	public required double X { get; set; }

	public required double Y { get; set; }

	public required double Z { get; set; }

	public Vector(double x, double y, int z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Vector(Direction direction, double magnitude)
	{
		X = magnitude * Math.Sin(direction.PolarAngle) * Math.Cos(direction.AzimuthalAngle);
		Y = magnitude * Math.Sin(direction.PolarAngle) * Math.Sin(direction.AzimuthalAngle);
		Z = magnitude * Math.Cos(direction.PolarAngle);
	}
}
