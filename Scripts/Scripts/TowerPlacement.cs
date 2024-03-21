using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab;  // Reference to the tower prefab
    public Transform nodesParent;   // Reference to the parent object containing node GameObjects
    private RaycastHit2D hit; // Store the hit information

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            // If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                if (hit.collider.transform.IsChildOf(nodesParent))
                {
                    PlaceTower();
                }
            }
        }
    }

    void PlaceTower()
    {
        if (ScoreManager.money >= 100)
        {
            ScoreManager.money -= 100; // Deduct 100 from ScoreManager.money
            Instantiate(towerPrefab, hit.point, Quaternion.identity);
            Debug.Log("Tower placed!");
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }
}
