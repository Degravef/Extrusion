namespace _3DTools;

public class Triangle : IEqualityComparer<Triangle>, IEquatable<Triangle>
{
	public Coordinates A { get; }
	public Coordinates B { get; }
	public Coordinates C { get; }

	public Triangle(Coordinates a, Coordinates b, Coordinates c)
	{
		if (a == b || a == c || b == c)
		{
			throw new ArgumentException("A triangle must have 3 distinct vertices");
		}
		A = a;
		B = b;
		C = c;
	}

	public Triangle Translated(Vector vector)
	{
		return new Triangle(A.Translated(vector), B.Translated(vector), C.Translated(vector));
	}

	public virtual bool Equals(Triangle? o)
	{
		if (ReferenceEquals(null, o)) return false;
		if (ReferenceEquals(this, o)) return true;
		if (A != o.A && A != o.B && A != o.C) return false;
		if (B != o.A && B != o.B && B != o.C) return false;
		if (C != o.A && C != o.B && C != o.C) return false;
		return true;
	}

	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((Triangle) obj);
	}

	public static bool operator==(Triangle left, Triangle right)
	{
		return left.Equals(right);
	}

	public static bool operator!=(Triangle left, Triangle right)
    {
	    return !left.Equals(right);
    }

	public virtual bool Equals(Triangle? x, Triangle? y)
	{
		if (ReferenceEquals(x, y)) return true;
		if (x is null || y is null) return false;
		return x.Equals(y);
	}

	public virtual int GetHashCode(Triangle obj)
	{
		return HashCode.Combine(obj.A, obj.B, obj.C);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(A, B, C);
	}
}
