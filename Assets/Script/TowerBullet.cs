using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public void Attack(Collider collider, int damage)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = collider.transform.position;
        float height = 5.0f; 
        Vector3 midPoint = (startPosition + targetPosition) / 2 + Vector3.up * height;
        Vector3[] path = new Vector3[] { startPosition, midPoint, targetPosition };

        transform.DOPath(path, 0.5f, PathType.CatmullRom)
            .SetEase(Ease.Linear)
            .OnComplete(() => {
                collider.GetComponent<Health>().GetDamage(damage);
                Destroy(gameObject,2f);
            });
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Instantiate(GameAssets.Instance?.TowerBulletLandingPage,transform.position, Quaternion.identity);
        }
    }
}
