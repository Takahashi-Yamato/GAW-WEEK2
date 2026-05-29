using System.Collections;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    [Header("弾のプレハブ")]
    public GameObject bulletPrefab;

    [Header("銃口")]
    public Transform muzzle;

    [Header("カメラ")]
    public Camera cam;

    [Header("弾速")]
    public float bulletSpeed = 40f;

    [Header("最大距離")]
    public float maxDistance = 200f;

    [Header("弾数")]
    public int maxAmmo = 30;
    public int currentAmmo;

    [Header("リロード時間")]
    public float reloadTime = 2f;

    public bool isReloading = false;

    /// <summary>
    /// 初期化（弾数リセット）
    /// </summary>
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    /// <summary>
    /// 入力処理（射撃・リロード）
    /// </summary>
    void Update()
    {
        if (isReloading) return;

        // リロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        // 射撃
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    /// <summary>
    /// クロスヘア（画面中央）に向かって弾を発射する
    /// </summary>
    void Shoot()
    {
        // 弾切れチェック
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        currentAmmo--;

        // 画面中央からレイを飛ばす
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Vector3 targetPoint;

        // ヒット判定（敵・壁など）
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * maxDistance;
        }

        // 銃口からターゲットへ方向計算
        Vector3 direction = (targetPoint - muzzle.position).normalized;

        // 弾生成
        GameObject bullet = Instantiate(
            bulletPrefab,
            muzzle.position,
            Quaternion.LookRotation(direction)
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 弾の速度設定
        rb.velocity = direction * bulletSpeed;
    }

    /// <summary>
    /// リロード処理（一定時間待って弾を回復）
    /// </summary>
    IEnumerator Reload()
    {
        isReloading = true;

        // リロード時間待機
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
    }
}