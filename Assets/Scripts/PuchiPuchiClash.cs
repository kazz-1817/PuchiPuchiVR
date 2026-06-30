using System.Collections;
using UnityEngine;

public class PuchiPuchiClash : MonoBehaviour
{
    [Header("破裂したときの音")]
    public AudioSource popSound;

    [Header("復活するまでの秒数")]
    public float respawnTime = 3.0f;

    // すでに破裂したかを判定するフラグ
    private bool isPopped = false;

    // 最初の大きさを記憶しておくための変数
    private Vector3 originalScale;

    void Start()
    {
        // ゲーム開始時に、この物体の元のサイズを記憶しておく
        originalScale = transform.localScale;
    }

    // 破裂させるための命令
    public void Pop()
    {
        // すでに破裂していたら何もしない
        if (isPopped) return;

        isPopped = true;

        // 音を鳴らす
        if (popSound != null)
        {
            popSound.Play();
        }

        // 見た目をペシャンコにする（Y軸方向を潰す）
        transform.localScale = new Vector3(originalScale.x, 0.1f, originalScale.z);

        // 指定秒数後に復活させるタイマー処理をスタート
        StartCoroutine(RespawnBubble());
    }

    // 復活のためのタイマー処理
    private IEnumerator RespawnBubble()
    {
        // Unity上の「復活するまでの秒数」で設定した時間だけ待機する
        yield return new WaitForSeconds(respawnTime);

        // 元のサイズに戻し、再び破裂できるようにフラグを戻す
        transform.localScale = originalScale;
        isPopped = false;
    }

    // （保険）手動で何かがぶつかっただけでも破裂させたい場合
    private void OnTriggerEnter(Collider other)
    {
        // 当たった相手が指や手（Pokeなど）であれば破裂させる
        if (other.name.Contains("Poke") || other.name.Contains("Hand") || other.CompareTag("Player"))
        {
            Pop();
        }
    }
}