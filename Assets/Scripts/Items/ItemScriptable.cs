namespace AFSInterview.Items
{
	using UnityEngine;
	
	[CreateAssetMenu(menuName = "AFSInterview/Item", fileName = "Item")]
	public class ItemScriptable : ScriptableObject
	{
		[SerializeField] private string itemName;
		[SerializeField] private int value;
		
		[Header("Consumable")]
		[SerializeField] private bool isConsumable;
		[SerializeField] private int moneyOnUse;
		[SerializeField] private ItemScriptable itemOnUse;

		public string Name => itemName;
		public int Value => value;

		public bool IsConsumable => isConsumable;

		public int MoneyOnUse => moneyOnUse;
		public ItemScriptable ItemOnUse => itemOnUse;

		private void OnValidate()
		{
			if (moneyOnUse != 0 || itemOnUse != null)
				isConsumable = true;
			
			if (moneyOnUse == 0 && itemOnUse == null)
				isConsumable = false;
		}
	}
}