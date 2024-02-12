namespace _3DTools;

public class Point
{
	private double _x;
	private double _y;
	private double _z;

	public required double X
	{
		get => _x;
		init => _x = value;
	}

	public required double Y
	{
		get => _y;
		init => _y = value;
	}

	public required double Z
	{
		get => _z;
		init => _z = value;
	}

	public Point(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Point Move(Vector vector)
	{
		_x += vector.X;
		_y += vector.Y;
		_z += vector.Z;
		return this;
	}
}
