using UnityEngine;

public class Hole : MonoBehaviour
{
    // �ǂ̃{�[�����z���񂹂邩���^�O�Ŏw��
    [SerializeField] private string _tagetTag;

    private void OnTriggerStay(Collider other)
    {
        // �R���C�_�[�ɐG��Ă���I�u�W�F�N�g��Rigidbody�R���|�[�l���g���擾
        Rigidbody r = other.gameObject .GetComponent<Rigidbody>();
        // �{�[�����ǂ̕����ɂ��邩���v�Z
        Vector3 direction = other.gameObject.transform.position - transform.position;
        // �����ȕ������擾
        direction.Normalize();
        // �^�O�ɉ����ă{�[���ɗ͂�������
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
