namespace _3DTools;

using Math;

public class Vector
{
	public decimal X { get; }
	public decimal Y { get; }
	public decimal Z { get; }

	public Vector(decimal x, decimal y, decimal z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Vector(Coordinates origin, Coordinates destination):
		this(destination.X - origin.X, destination.Y - origin.Y, destination.Z - origin.Z) { }

	public Vector(Direction direction, decimal magnitude)
	{
		X = magnitude * DeciMath.Cos(direction.PolarAngle) * DeciMath.Sin(direction.AzimuthalAngle);
		Y = magnitude * DeciMath.Cos(direction.PolarAngle) * DeciMath.Cos(direction.AzimuthalAngle);
		Z = magnitude * DeciMath.Sin(direction.PolarAngle);
	}

	public bool IsCollinearTo(Vector other)
	{
		// TODO take epsilon into account
		return X / other.X == Y / other.Y && Y / other.Y == Z / other.Z;
	}
}
