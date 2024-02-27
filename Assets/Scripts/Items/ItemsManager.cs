namespace AFSInterview.Items
{
	using TMPro;
	using UnityEngine;

	public class ItemsManager : MonoBehaviour
	{
		[SerializeField] private InventoryController inventoryController;
		[SerializeField] private int itemSellMaxValue;

		[SerializeField] private TextMeshProUGUI moneyText;
		[SerializeField] private ItemsSpawner itemsSpawner;
		[SerializeField] private LayerMask itemLayerMask;

		private void Start()
		{
			moneyText.text = "Money: " + inventoryController.Money;
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
				TryPickUpItem();

			if (Input.GetKeyDown(KeyCode.Space))
			{
				inventoryController.SellAllItemsUpToValue(itemSellMaxValue);
				moneyText.text = "Money: " + inventoryController.Money;
			}
		}

		private void TryPickUpItem()
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out var hit, 100f, itemLayerMask) || !hit.collider.TryGetComponent<IItemHolder>(out var itemHolder))
				return;
			
			var item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);
            Debug.Log("Picked up " + item.Name + " with value of " + item.Value + " and now have " + inventoryController.ItemsCount + " items");
		}
	}
}