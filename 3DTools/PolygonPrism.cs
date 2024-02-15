using System.Collections.Immutable;

namespace _3DTools;

public class PolygonPrism
{
	public Polygon Base { get; }
	public Polygon Opposite { get; }

	public ImmutableHashSet<Triangle> Faces { get; }

	public PolygonPrism(Polygon polygon, Vector vector)
	{
		Base = polygon;
		Opposite = Base.Translated(vector);

        ImmutableHashSet<Triangle>.Builder resultBuilder = ImmutableHashSet.CreateBuilder<Triangle>();
        foreach (Segment side in Base.GetSides())
        {
	        (Triangle a,Triangle b) = side.Extrude(vector);
	        resultBuilder.Add(a);
	        resultBuilder.Add(b);
        }
        Faces = resultBuilder.ToImmutable();
	}
}
