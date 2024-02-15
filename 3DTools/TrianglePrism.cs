namespace _3DTools;

public class TrianglePrism
{
	public Triangle Base { get;}
	public Triangle Opposite { get; }

	public Triangle BottomA { get; }
	public Triangle BottomB { get; }

	public Triangle LeftA { get; }
	public Triangle LeftB { get; }

	public Triangle RightA { get; }
	public Triangle RightB { get; }

	public TrianglePrism(Triangle baseTriangle, Triangle opposite)
	{
		Base = baseTriangle;
		Opposite = opposite;

		BottomA = new Triangle (baseTriangle.A, opposite.C, baseTriangle.C);
		BottomB = new Triangle (baseTriangle.A, opposite.C, opposite.A);
		LeftA   = new Triangle (baseTriangle.A, opposite.B, baseTriangle.B);
		LeftB   = new Triangle (baseTriangle.A, opposite.B, opposite.A);
		RightA  = new Triangle (baseTriangle.B, opposite.C, baseTriangle.C);
		RightB  = new Triangle (baseTriangle.B, opposite.C, opposite.B);
	}

	public TrianglePrism(Triangle baseTriangle, Vector extrusion)
	{
		Base = baseTriangle;
		Opposite = baseTriangle.Translated(extrusion);

		(BottomA, BottomB) = new Segment {A = Base.A, B = Base.C}.Extrude(extrusion);
		(LeftA, LeftB) = new Segment {A = Base.A, B = Base.B}.Extrude(extrusion);
		(RightA, RightB) = new Segment {A = Base.B, B = Base.C}.Extrude(extrusion);
	}
}
