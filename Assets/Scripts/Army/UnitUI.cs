namespace AFSInterview.Army
{
	using UnityEngine;
	using UnityEngine.UI;

	public class UnitUI : MonoBehaviour
	{
		[SerializeField] private Unit unit;

		[SerializeField]
		private Slider slider;
		
		private void Start()
		{
			slider.maxValue = unit.Definition.MaxHealth;
			slider.value = unit.CurrentLife;
			unit.onLifeChanged += UnitLifeChanged;
		}

		private void UnitLifeChanged(int currentLife)
		{
			slider.value = currentLife;
		}
	}
}