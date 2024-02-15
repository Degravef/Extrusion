using System.Diagnostics.CodeAnalysis;
using static System.Math;

namespace _3DTools;

public record Coordinates()
{
	public required decimal X { get; init; }
	public required decimal Y { get; init; }
	public required decimal Z { get; init; }

	[SetsRequiredMembers]
	public Coordinates(decimal x, decimal y, decimal z) :this()
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Coordinates Translated(Vector vector)
	{
		return new Coordinates(X + vector.X, Y + vector.Y, Z + vector.Z);
	}

	/// <summary>
	/// Checks if a point can be between each of the coordinates.
	/// </summary>
	public bool CanBeBetween(Coordinates a, Coordinates b)
	{
		return X >= Min(a.X, b.X) && X <= Max(a.X, b.X) &&
		       Y >= Min(a.Y, b.Y) && Y <= Max(a.Y, b.Y) &&
               Z >= Min(a.Z, b.Z) && Z <= Max(a.Z, b.Z);
	}

	/// <summary>
	/// Checks if the point is on the line.
	/// </summary>
	public bool IsOnLine(Segment segment)
	{
		return new Vector(this, segment.A).IsCollinearTo(new Vector(this, segment.B));
	}

	/// <summary>
	/// Checks if a point is on the line segment.
	/// </summary>
	public bool IsOnSegment(Segment segment)
	{
		return CanBeBetween(segment.A, segment.B) && IsOnLine(segment);
	}
}
