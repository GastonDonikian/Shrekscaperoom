using UnityEngine;

public class GranadeThrowController : MonoBehaviour
{
    [SerializeField] private float _throwForce = 50f;
    [SerializeField] private GameObject _granadePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
         ThrowGranade();   
        }
    }

    private void ThrowGranade()
    {
        //spawn de granada
        GameObject granade = Instantiate(_granadePrefab, transform.position + transform.forward, transform.rotation);
        //acceso al rigidbody
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        //aplicar fuerza
        rb.AddForce(transform.forward * _throwForce, ForceMode.VelocityChange);
    }
}
