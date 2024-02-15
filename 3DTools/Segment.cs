namespace _3DTools;

public class Segment
{
	public required Coordinates A { get; init; }
	public required Coordinates B { get; init; }

	public (Triangle, Triangle) Extrude(Vector magnitude)
	{
		return (new Triangle(A, B.Translated(magnitude), A),
		        new Triangle(B, B.Translated(magnitude), B));
	}

	/// <summary>
	/// Checks if the point is on the line and between A and B.
	/// </summary>
	public bool Contains(Coordinates point)
	{
		return point.IsOnSegment(this);
	}

	/// <summary>
	/// Checks if the line is on the line and between A and B.
	/// </summary>
	public bool Contains(Segment segment)
	{
		return Contains(segment.A) || Contains(segment.B);
	}

	/// <summary>
	/// Checks if 2 Segments overlap and thus can make a bigger segment.
	/// </summary>
	public bool Overlaps(Segment segment)
	{
		return Contains(segment.A) ^ Contains(segment.B); //xor
	}

	public bool IsOnLine(Segment segment)
	{
		return Contains(segment.A) && Contains(segment.B);
	}
}
