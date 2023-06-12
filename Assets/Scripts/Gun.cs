using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _bulletSpeed = 1000f;
    [SerializeField] private float _spread = 0f;

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

        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
        {
            float distance = 75;
            targetPoint = ray.GetPoint(distance);
        }
        Vector3 dirWithoutSpread = targetPoint - _bulletPoint.position;

        float x = Random.Range(-_spread, _spread);
        float y = Random.Range(-_spread, _spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);
        GameObject bullet = Instantiate(_bulletPrefab, _bulletPoint.position, Quaternion.identity);
        bullet.transform.forward = dirWithSpread.normalized;
        bullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * _bulletSpeed, ForceMode.Impulse);

        Destroy(bullet, 1);
    }
}
