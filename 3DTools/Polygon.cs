using System.Collections.Immutable;
using _3DTools.Extensions;

namespace _3DTools;

public class Polygon : IEqualityComparer<Polygon>, IEquatable<Polygon>
{
	public ImmutableHashSet<Triangle> Triangles { get; }

	public Polygon(ImmutableHashSet<Triangle> triangles, bool checkPlane = false)
	{
		// disabled by default for performance
		if (checkPlane && !IsOnSamePlane(triangles.ToArray()))
		{
			throw new ArgumentException("The triangles must be on the same plane.");
		}

		Triangles = triangles;
	}

	public Polygon Translated(Vector vector)
	{
		var resultBuilder = ImmutableHashSet.CreateBuilder<Triangle>();
		foreach (Triangle triangle in Triangles)
		{
			resultBuilder.Add(triangle.Translated(vector));
		}

		return new Polygon(resultBuilder.ToImmutable());
	}

	public ImmutableHashSet<Segment> GetSides()
	{
		//TODO This won't work for every polygon, like a pentacle.
        var resultBuilder = ImmutableHashSet.CreateBuilder<Segment>();
        foreach (Triangle triangle in Triangles)
        {
	        resultBuilder.AddOrMerge(new Segment {A = triangle.A, B = triangle.B});
        }
        return resultBuilder.ToImmutable();
	}

	private static bool IsOnSamePlane(params Triangle[] triangles)
	{
		//TODO
		return triangles.Length > 0;
	}

	public virtual bool Equals(Polygon? right)
	{
		if (ReferenceEquals(null, right)) return false;
		return Triangles.Count == right.Triangles.Count &&
		       Triangles.All(triangle => right.Triangles.Contains(triangle));
	}

	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((Polygon) obj);
	}

	public virtual bool Equals(Polygon? x, Polygon? y)
	{
		if (ReferenceEquals(x, y)) return true;
		if (x is null || y is null) return false;
		return x.Equals(y);
	}

	public virtual int GetHashCode(Polygon obj)
	{
		return obj.GetHashCode();
	}

	public override int GetHashCode()
    {
        return HashCode.Combine(Triangles);
    }
}
