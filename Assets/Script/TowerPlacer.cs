using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;     // 配置するタワーのプレハブ
    public LayerMask towerLayer;
    public LayerMask groundLayer;      // 地面レイヤー
    public float checkRadius = 0.5f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 地面をクリックしたら設置
            if (Physics.Raycast(ray, out hit, 100f, groundLayer))
            {

                Vector3 placePosition = hit.point;
                placePosition.y = 0f; // タワーを地面に合わせる

                if (CheckBeFogged(placePosition))
                {
                    Debug.Log("すでにタワーが設置されています！");
                    return;
                }

                PlaceTower(placePosition);
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
