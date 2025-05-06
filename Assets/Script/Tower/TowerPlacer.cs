using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;     // �z�u����^���[�̃v���n�u
    public LayerMask groundLayer;      // �n�ʃ��C���[
    public float checkRadius = 0.5f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, groundLayer))
            {
                TowerPlace place = hit.collider.GetComponent<TowerPlace>();
                if (place != null && !place.isOccupied)
                {
                    // �܂��ݒu����Ă��Ȃ���ΐݒu
                    Vector3 placePos = place.transform.position;

                    PlaceTower(placePos);

                    place.isOccupied = true;
                }
                else
                {
                    Debug.Log("�����ɂ͐ݒu�ł��܂���I");
                }
            }
        }

    }

    void PlaceTower(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }
}
