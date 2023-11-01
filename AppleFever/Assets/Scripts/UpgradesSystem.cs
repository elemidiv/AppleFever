using UnityEngine;

public class UpgradesSystem : MonoBehaviour
{
    [HideInInspector] public int CurrentL1;
    [HideInInspector] public int CurrentL2;
    [HideInInspector] public int CurrentL3;
    [HideInInspector] public int CurrentL4;

    private void Awake()
    {
        CurrentL1 = PlayerPrefs.GetInt("uSpeed", 0);
        CurrentL2 = PlayerPrefs.GetInt("uMood", 0);
        CurrentL3 = PlayerPrefs.GetInt("uRegeneration", 0);
        CurrentL4 = PlayerPrefs.GetInt("uResistance", 0);
    }

    //Functions that set the level of each upgrade, also the new coin amount
    public void SetSpeed(int Level, int coin)
    {
        PlayerPrefs.SetInt("uSpeed", Level);
        PlayerPrefs.SetInt("Coin", coin);
    }
    public void SetMood(int Level, int coin)
    {
        PlayerPrefs.SetInt("uMood", Level);
        PlayerPrefs.SetInt("Coin", coin);
    }
    public void SetRegeneration(int Level, int coin)
    {
        PlayerPrefs.SetInt("uRegeneration", Level);
        PlayerPrefs.SetInt("Coin", coin);
    }
    public void SetResistance(int Level, int coin)
    {
        PlayerPrefs.SetInt("uResistance", Level);
        PlayerPrefs.SetInt("Coin", coin);
    }


    //Functions that get the statistic of each upgrade
    public float GetSpeed()
    {
        return 6 + 0.1f * PlayerPrefs.GetInt("uSpeed", 0);
    }
    public float GetMood()
    {
        return 100 + 1.3f * PlayerPrefs.GetInt("uMood", 0);
    }
    public float GetRegeneration()
    {
        return 0.5f + 0.1f * PlayerPrefs.GetInt("uRegeneration", 0);
    }
    public int GetResistance()
    {
        return 0 + 1 * PlayerPrefs.GetInt("uResistance", 0);
    }
}
