using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class BulletShoot : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private AmmoUI ui;
    [SerializeField] private InputBridge input;

    public int current = 30;
    public int magSize = 30;
    public int reserves = 360;

    private AudioSource AudioSource;
    public AudioMixerGroup mixer;
    public AudioClip fireSFX;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        if (ui != null)
        {
            ui.Set(current, magSize, reserves);
        }
        else
        {
            Debug.LogWarning("[AmmoSim] AmmoUI reference not set.");
        }
    }


    void Update()
    {
        if (input == null) return;

        // Fire input
        if (input.firePressed && current > 0)
        {
            current--;
            ui.Set(current, magSize, reserves);
            AudioSource.PlayOneShot(fireSFX);
            var it = Instantiate(bullet, transform.position, transform.rotation);
            Debug.Log($"[AmmoSim] Fired! Ammo: {current}/{magSize} ({reserves})");
        }

        // Reload input
        if (input.reloadPressed && current < magSize && reserves > 0)
        {
            int need = magSize - current;
            int take = Mathf.Min(need, reserves);
            current += take;
            reserves -= take;
            ui.Set(current, magSize, reserves);
            Debug.Log($"[AmmoSim] Reloaded! Ammo: {current}/{magSize} ({reserves})");
        }
    }
}
