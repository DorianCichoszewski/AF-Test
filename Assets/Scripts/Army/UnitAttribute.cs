using System;

namespace AFSInterview.Army
{
	[Flags]
	public enum UnitAttribute
	{
		Light = 1 << 0,
		Armored = 1 << 1,
		Mechanical = 1 << 2,
	}
}