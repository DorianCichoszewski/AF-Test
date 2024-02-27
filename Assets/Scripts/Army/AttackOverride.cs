namespace AFSInterview.Army
{
	using System;
	using UnityEngine;
	
	[Serializable]
	public struct AttackOverride
	{
		[HideInInspector]
		public string name;
		public UnitAttribute attribute;
		public int attackValue;

		public void SetName()
		{
			name = Enum.GetName(typeof(UnitAttribute), attribute);
		}
	}
}