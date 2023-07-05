using UnityEngine;

public class GranadeThrowController : MonoBehaviour
{
    [SerializeField] private float _throwForce = 50f;
    [SerializeField] private GameObject _granadePrefab;
    private bool thrown = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !thrown)
        {
            thrown = true;
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
        rb.AddForce(transform.forward * _throwForce + transform.up * _throwForce /2, ForceMode.VelocityChange);
    }
}
