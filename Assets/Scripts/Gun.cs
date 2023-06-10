using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private float _bulletSpeed = 600f;

    private void Update()
    {
        if (_input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    private void Shoot()
    {
        Debug.Log("shoot!");
        GameObject bullet = Instantiate(_bulletPrefab, _bulletPoint.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed);
        Destroy(bullet, 1);
    }
}
