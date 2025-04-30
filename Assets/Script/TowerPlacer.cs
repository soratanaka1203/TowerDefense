using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;     // �z�u����^���[�̃v���n�u
    public LayerMask towerLayer;
    public LayerMask groundLayer;      // �n�ʃ��C���[
    public float checkRadius = 0.5f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // �n�ʂ��N���b�N������ݒu
            if (Physics.Raycast(ray, out hit, 100f, groundLayer))
            {

                Vector3 placePosition = hit.point;
                placePosition.y = 0f; // �^���[��n�ʂɍ��킹��

                if (CheckBeFogged(placePosition))
                {
                    Debug.Log("���łɃ^���[���ݒu����Ă��܂��I");
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

    bool CheckBeFogged(Vector3 pos)�@//���̃^���[���߂��ɂ��邩�m�F
    {
        return Physics.CheckSphere(pos, checkRadius, towerLayer);
    }
}
