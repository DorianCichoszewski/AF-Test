namespace AFSInterview.Army
{
	using UnityEngine;
	using UnityEngine.UI;
	
	public class Unit : MonoBehaviour
	{
		[SerializeField] private UnitScriptable definition;
		[SerializeField] private Slider slider;
		
		private ArmyController assignedArmy;
		private int currentLife;

		public UnitAttribute Attribute => definition.Attribute;
		public int AttackInterval => definition.AttackInterval;

		public void Init(ArmyController army)
		{
			assignedArmy = army;
			currentLife = definition.MaxHealth;
			gameObject.name = definition.name;
			slider.maxValue = definition.MaxHealth;
			slider.value = currentLife;
		}

		public void TakeDamage(int damage)
		{
			int finalDamage = Mathf.Max(1, damage - definition.Armor);
			currentLife -= finalDamage;
			if (currentLife <= 0)
			{
				Death();
			}
			slider.value = currentLife;
		}

		public void ProcessTurn()
		{
			var enemy = assignedArmy.CombatManager.GetRandomUnitFromOtherArmy(assignedArmy);
			enemy.TakeDamage(definition.GetAttackValue(enemy.Attribute));
		}

		private void Death()
		{
			assignedArmy.RemoveUnit(this);
			gameObject.SetActive(false);
		}
	}
}