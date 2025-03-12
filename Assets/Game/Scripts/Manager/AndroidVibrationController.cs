using UnityEngine;
using UnityEngine.Android;

public class AndroidVibrationController : MonoBehaviour
{
    private static AndroidJavaObject vibrator;
    private static bool hasVibrator;

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.VIBRATE"))
        {
            Permission.RequestUserPermission("android.permission.VIBRATE");
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
            hasVibrator = vibrator.Call<bool>("hasVibrator");
        }
#endif

    }

    /// <summary>
    /// Kiểm tra thiết bị có hỗ trợ rung hay không.
    /// </summary>
    public static bool IsVibratorAvailable()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return hasVibrator;
#else
        return false;
#endif
    }

    /// <summary>
    /// Bật hoặc tắt rung.
    /// </summary>
    public static void EnableVibration(bool enable)
    {
        PlayerPrefs.SetInt("VibrationEnabled", enable ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Kiểm tra xem rung có đang được bật hay không.
    /// </summary>
    public static bool IsVibrationEnabled()
    {
        return PlayerPrefs.GetInt("VibrationEnabled", 1) == 1;
    }

    /// <summary>
    /// Rung thiết bị trong khoảng thời gian nhất định (ms).
    /// </summary>
    public static void Vibrate(long milliseconds)
    {
        if (!IsVibrationEnabled()) return; // Kiểm tra trước khi rung

#if UNITY_ANDROID && !UNITY_EDITOR
        if (IsVibratorAvailable())
        {
            if (AndroidVersion() >= 26)
            {
                vibrator.Call("vibrate", new long[] { 0, milliseconds }, -1);
            }
            else
            {
                vibrator.Call("vibrate", milliseconds);
            }
        }
#endif
    }

    /// <summary>
    /// Rung với một mẫu pattern và cường độ rung.
    /// </summary>
    /// <param name="pattern">Mảng thời gian rung và nghỉ.</param>
    /// <param name="amplitude">Cường độ rung (chỉ hỗ trợ trên Android 26 trở lên).</param>
    /// <param name="repeat">Số lần lặp lại pattern (-1 nếu không lặp).</param>
    public static void VibratePattern(long[] pattern, int repeat = -1, int amplitude = 255)
    {
        if (!IsVibrationEnabled()) return; // Kiểm tra trước khi rung

#if UNITY_ANDROID && !UNITY_EDITOR
        if (IsVibratorAvailable())
        {
            if (AndroidVersion() >= 26)
            {
                vibrator.Call("vibrate", pattern, repeat);
            }
            else
            {
                vibrator.Call("vibrate", pattern, repeat);
            }
        }
#endif
    }

    /// <summary>
    /// Tắt rung ngay lập tức.
    /// </summary>
    public static void CancelVibration()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (IsVibratorAvailable())
        {
            vibrator.Call("cancel");
        }
#endif
    }

    /// <summary>
    /// Lấy phiên bản Android hiện tại.
    /// </summary>
    private static int AndroidVersion()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass version = new AndroidJavaClass("android.os.Build$VERSION"))
        {
            return version.GetStatic<int>("SDK_INT");
        }
#else
        return 0;
#endif
    }
}