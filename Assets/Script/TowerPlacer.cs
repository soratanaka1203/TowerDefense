using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;     // 配置するタワーのプレハブ
    public LayerMask towerLayer;
    public LayerMask groundLayer;      // 地面レイヤー
    public float checkRadius = 0.5f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                TowerPlace place = hit.collider.GetComponent<TowerPlace>();
                if (place != null && !place.isOccupied)
                {
                    // まだ設置されていなければ設置
                    Vector3 placePos = place.transform.position;

                    PlaceTower(placePos);

                    place.isOccupied = true;
                }
                else
                {
                    Debug.Log("ここには設置できません！");
                }
            }
        }

    }

    void PlaceTower(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }

    bool CheckBeFogged(Vector3 pos)　//他のタワーが近くにあるか確認
    {
        return Physics.CheckSphere(pos, checkRadius, towerLayer);
    }
}
