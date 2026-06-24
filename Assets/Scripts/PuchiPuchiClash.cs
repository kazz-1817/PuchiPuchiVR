using UnityEngine;

public class PuchiPuchiClash : MonoBehaviour
{
    [Header("破裂したときの音")]
    public AudioSource popSound;

    // すでに破裂したかを判定するフラグ（2回連続で鳴らないようにするため）
    private bool isPopped = false;

    // 破裂させるための命令（kazzさんのPoke機能から呼び出せるように public にします）
    public void Pop()
    {
        // すでに破裂していたら何もしない
        if (isPopped) return;

        isPopped = true;

        // 1. Miyuさんが見つけてくれた音を鳴らす！
        if (popSound != null)
        {
            popSound.Play();
        }

        // 2. 見た目をペシャンコにする（Y軸方向を潰す）
        transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);

        // ※もしオブジェクトごと完全に消滅させたい場合は、上の行の代わりに Destroy(gameObject); と書きます
    }

    // （保険）もし手動で何かがぶつかっただけでも破裂させたい場合
    private void OnTriggerEnter(Collider other)
    {
        // 当たった相手が指や手（Pokeなど）であれば破裂させる
        if (other.name.Contains("Poke") || other.name.Contains("Hand") || other.CompareTag("Player"))
        {
            Pop();
        }
    }
}