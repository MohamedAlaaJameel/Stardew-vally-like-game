using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public List<GameObject> ItemsPrefabs;
    // Start is called before the first frame update
    private void OnEnable()
    {
       PlaceHolder. SpawnItem += SpawnItem;
    }
    private void OnDisable()
    {
        PlaceHolder.SpawnItem -= SpawnItem;
    }
    void SpawnItem(InventoryItem item,Vector2 location) //todo Item id instead of name
    {
        string itemName = item.itemName;
        if (ItemsPrefabs!=null&& ItemsPrefabs.Count>0)
        {
  
            IEnumerable<GameObject> itemPrefab = ItemsPrefabs.Where(prefab => prefab.name == itemName);
            if (itemPrefab.IsAny())
            {
                if (itemPrefab.Count()>1)
                {
                    Debug.LogError("you have 2 prefabs with the same name");
                }
                if (item.isStackable)
                {
                    for (int i = 0; i < item.NumofStackeditems; i++)
                    {
                        var angle = i * Mathf.PI * 2 / item.NumofStackeditems;
                        var pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 1.5f;
                        Instantiate(itemPrefab.First()).transform.position = pos+location; //new Vector3(location.x+(i+1)/2, location.y, 0);

                    }
                }
                else
                {
                    Instantiate(itemPrefab.First()).transform.position = location;

                }
            }
            else
            {
                Debug.LogError("Item not found    ItemsPrefabs on ItemSpawnManager ");
            }
        }
    }
}
