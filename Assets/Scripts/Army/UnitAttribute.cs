namespace AFSInterview.Army
{
	using System;
	
	[Flags]
	public enum UnitAttribute
	{
		Light = 1 << 0,
		Armored = 1 << 1,
		Mechanical = 1 << 2,
	}
}