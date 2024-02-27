namespace AFSInterview.Army
{
	using TMPro;
	using UnityEngine;
	
	public class CombatUIManager : MonoBehaviour
	{
		[SerializeField]
		private CombatManager combatManager;

		[SerializeField] private TextMeshProUGUI turnText;
		[SerializeField] private TextMeshProUGUI nextUnitText;

		private void Start()
		{
			combatManager.onNext += Next;
			combatManager.onEnd += End;
			Next();
		}

		private void Next()
		{
			turnText.text = $"Turn {combatManager.Timeline.CurrentTurnIndex}";
			
			var nextUnit = combatManager.Timeline.NextUnit;
			nextUnitText.text = $"Next unit: {nextUnit.name} from {nextUnit.AssignedArmy.name}";
		}

		private void End()
		{
			nextUnitText.gameObject.SetActive(false);
		}
	}
}