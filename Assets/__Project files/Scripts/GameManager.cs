using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GameManager : MonoBehaviour
{

 



   [SerializeField] Transform playerTransform;
   [SerializeField] float ObjectsHighlightDistance;


    static List<Collider2D> lastHighlightedObjects =new List<Collider2D>();


    #region UnityCallbacks
    private void FixedUpdate()
    {
        HighLightAllNearGameObjects();
    } 
    #endregion



    void HighLightAllNearGameObjects()
    {
        if (playerTransform == null)
        {
            Debug.Log($"Player transform is missing from level manager");
            return;
        }
        Vector2 pos = playerTransform.position;
        Collider2D[] allColliders = Physics2D.OverlapCircleAll(pos, ObjectsHighlightDistance);

        if (!allColliders.IsAny())
        {
            return;
        }
        IEnumerable<Collider2D> highlights = allColliders.Where(collider => collider != null && collider.GetComponent<IHighlightable>() != null);

        if (highlights.IsAny())
        {
            foreach (var item in highlights)
            {
                if (!lastHighlightedObjects.Contains(item))
                {
                    lastHighlightedObjects.Add(item);
                }
                item.GetComponent<IHighlightable>().HighlightOn();
            }
        }
        else
        {
            if (lastHighlightedObjects.IsAny())
            {
                var last = lastHighlightedObjects.Where(obj => obj != null);
                if (last.IsAny())
                {
                    foreach (var item in last)
                    {
                        item.GetComponent<IHighlightable>().HighlightOff();
                    }
                    lastHighlightedObjects.Clear();
                }
            }
        }
    }

}
