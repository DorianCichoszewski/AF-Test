namespace AFSInterview.Items
{
	using UnityEngine;
	
	public class ItemsSpawner : MonoBehaviour
	{
		[SerializeField] private Transform itemSpawnParent;
		[SerializeField] private GameObject itemPrefab;
		[SerializeField] private BoxCollider itemSpawnArea;
		[SerializeField] private float itemSpawnInterval;
		
		private float nextItemSpawnTime;

		private void Update()
		{
			if (Time.time >= nextItemSpawnTime)
				SpawnNewItem();
		}
		
		private void SpawnNewItem()
		{
			nextItemSpawnTime = Time.time + itemSpawnInterval;
			
			var spawnAreaBounds = itemSpawnArea.bounds;
			var position = new Vector3(
				Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
				0f,
				Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
			);
			
			Instantiate(itemPrefab, position, Quaternion.identity, itemSpawnParent);
		}
	}
}