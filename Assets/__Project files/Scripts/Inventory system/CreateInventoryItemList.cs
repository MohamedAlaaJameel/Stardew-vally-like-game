using UnityEngine;
using System.Collections;
using UnityEditor;

//[CreateAssetMenu(menuName = "SoData/inventory/Inventory Item List")]
public class CreateInventoryItemList
{
     [MenuItem("Assets/Create/SoData/inventory/Inventory Item List")]
    public static InventoryItemList Create()
    {
        InventoryItemList asset = ScriptableObject.CreateInstance<InventoryItemList>();

        AssetDatabase.CreateAsset(asset, "Assets/__Project files/SO data/Items-Bags/InventoryItemList.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}