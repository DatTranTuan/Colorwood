using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : Singleton<ToggleManager>
{
    [SerializeField] private Toggle musicToggle, musicToggle2;
    [SerializeField] private GameObject musicOn, musicOff, musicOn2, musicOff2;

    [SerializeField] private Toggle soundToggle, soundToggle2;
    [SerializeField] private GameObject soundOn, soundOff, soundOn2, soundOff2;

    [SerializeField] private Toggle hapticToggle, hapticToggle2;
    [SerializeField] private GameObject hapticOn, hapticOff, hapticOn2, hapticOff2;

    public Toggle HapticToggle => hapticToggle;
    public Toggle MusicToggle => musicToggle;
    public Toggle SoundToggle => soundToggle;

    public Toggle MusicToggle2 { get => musicToggle2; set => musicToggle2 = value; }
    public Toggle SoundToggle2 { get => soundToggle2; set => soundToggle2 = value; }
    public Toggle HapticToggle2 { get => hapticToggle2; set => hapticToggle2 = value; }

    private void Awake()
    {
        // Kiểm tra null trước khi gán sự kiện
        if (MusicToggle != null) MusicToggle.onValueChanged.AddListener(CheckMusicToggle);
        if (MusicToggle2 != null) MusicToggle2.onValueChanged.AddListener(CheckMusicToggle);

        if (SoundToggle != null) SoundToggle.onValueChanged.AddListener(CheckSoundToggle);
        if (SoundToggle2 != null) SoundToggle2.onValueChanged.AddListener(CheckSoundToggle);

        if (HapticToggle != null) HapticToggle.onValueChanged.AddListener(CheckHapticToggle);
        if (HapticToggle2 != null) HapticToggle2.onValueChanged.AddListener(CheckHapticToggle);

      
    }

    /// <summary>
    /// Kiểm tra và cập nhật trạng thái của Music Toggle
    /// </summary>
    private void CheckMusicToggle(bool isOn)
    {
        UpdateToggleState(musicToggle, MusicToggle2, isOn, musicOn, musicOff, musicOn2, musicOff2);

        if (isOn) SoundManager.Instance.Play("BG");
        else SoundManager.Instance.Stop("BG");

        SaveBool("Music", isOn);
    }

    /// <summary>
    /// Kiểm tra và cập nhật trạng thái của Sound Toggle
    /// </summary>
    private void CheckSoundToggle(bool isOn)
    {
        UpdateToggleState(soundToggle, SoundToggle2, isOn, soundOn, soundOff, soundOn2, soundOff2);

        if (isOn) SoundManager.Instance.TurnOnVolume();
        else SoundManager.Instance.TurnOffVolume();

        SaveBool("Sound", isOn);
    }

    /// <summary>
    /// Kiểm tra và cập nhật trạng thái của Haptic Toggle
    /// </summary>
    private void CheckHapticToggle(bool isOn)
    {
        UpdateToggleState(hapticToggle, HapticToggle2, isOn, hapticOn, hapticOff, hapticOn2, hapticOff2);

        AndroidVibrationController.EnableVibration(isOn);
        SaveBool("Haptic", isOn);
    }

    /// <summary>
    /// Cập nhật trạng thái của toggle và các UI liên quan
    /// </summary>
    private void UpdateToggleState(Toggle toggle1, Toggle toggle2, bool isOn, GameObject on1, GameObject off1, GameObject on2, GameObject off2)
    {
        if (toggle1 != null) toggle1.isOn = isOn;
        if (toggle2 != null) toggle2.isOn = isOn;

        if (on1 != null) on1.SetActive(isOn);
        if (off1 != null) off1.SetActive(!isOn);
        if (on2 != null) on2.SetActive(isOn);
        if (off2 != null) off2.SetActive(!isOn);
    }

    /// <summary>
    /// Load trạng thái toggle từ PlayerPrefs
    /// </summary>
    public void LoadStatus(string key, Toggle toggle1, Toggle toggle2)
    {
        bool value = LoadBool(key, true);
        if (toggle1 != null) toggle1.isOn = value;
        if (toggle2 != null) toggle2.isOn = value;
    }

    /// <summary>
    /// Lưu một giá trị bool vào PlayerPrefs.
    /// </summary>
    private void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Lấy giá trị bool từ PlayerPrefs.
    /// </summary>
    private bool LoadBool(string key, bool defaultValue = true)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }
}
