using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int levelID;
    public bool isLocked;
}
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private List<Level> levels = new List<Level>();
    private void Awake()
    {
        Instance = this; 
        UnlockLevel(5);
        UnlockLevel(8);
    } 
    public void UnlockLevel(int levelID)
    {
        Level tempLevel = levels.Find(level => level.levelID == levelID);
        if (tempLevel != null)
        { 
            tempLevel.isLocked = false;
        }
    }
    public bool IsLevelLocked(int levelID)
    {
        Level tempLevel = levels.Find(level => level.levelID == levelID);
        if (tempLevel != null)
        {
            return tempLevel.isLocked;
        }
        return false;
    }
    public void SaveLevel(int levelID)
    {
        int save = IsLevelLocked(levelID) == true ? 1 : 0;
        PlayerPrefs.SetInt("Level" + levelID.ToString(), save);
    }
    public bool GetLevel(int levelID)
    {
        int status = PlayerPrefs.GetInt("Level" + levelID.ToString());
        return  status == 1 ? true : false;
    }
}
