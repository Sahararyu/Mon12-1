using UnityEngine;

public class Hole : MonoBehaviour
{
    // どのボールを吸い寄せるかをタグで指定
    [SerializeField] private string _tagetTag;

    private void OnTriggerStay(Collider other)
    {
        // コライダーに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject .GetComponent<Rigidbody>();
        // ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        // 純粋な方向を取得
        direction.Normalize();
        // タグに応じてボールに力を加える
        if(other.CompareTag(_tagetTag))
        {
            r.linearVelocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80f, ForceMode.Acceleration);
        }

    }
}
