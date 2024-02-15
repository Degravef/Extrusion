using System.Collections.Immutable;

namespace _3DTools.Extensions;

public static class ImmutableHashSetBuilderExtension
{
	public static void AddOrMerge(this ImmutableHashSet<Segment>.Builder builder, Segment segment)
	{
		Segment? onSameLine = builder.FirstOrDefault(l => l.IsOnLine(segment));
		if (onSameLine is not null)
		{
			if (onSameLine.Overlaps(segment))
            {
	            Segment merged = MergeSegments(onSameLine, segment);
                builder.Remove(onSameLine);
                builder.Add(merged);
            }
            else if (segment.Contains(onSameLine))
            {
	            builder.Remove(onSameLine);
	            builder.Add(segment);
            }
		}
		else
		{
			builder.Add(segment);
		}
	}

	private static Segment MergeSegments(Segment a, Segment b)
	{
		var resultA = new Segment{A = a.A, B = b.B};
		var resultB = new Segment{A = b.A, B = a.B};
		return resultA.Contains(resultB) ? resultA : resultB;
	}
}
