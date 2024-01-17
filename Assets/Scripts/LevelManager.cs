using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static int targetLevel;
    int currentLevel = -1;
    [SerializeField] GameObject[] terrainPrefabs;
    [SerializeField] GameObject[] terrainStartPrefabs;
    GameObject saveThisTerrain;
    [SerializeField] Vector3[] terrainLocations;
    [SerializeField] Vector3[] terrainStartLocations;
    [SerializeField] Camera cam;

    private void Start()
    {
        SwitchTerrain(targetLevel);
        StartCoroutine(SceneStartTransition());
    }

    private void Update()
    {
        if (currentLevel != targetLevel && currentLevel != -1)
        {
            Debug.Log($"Switching terrain because current level ({currentLevel}) doesnt match target level ({targetLevel})");
            SwitchTerrain(targetLevel);
        }
    }

    public static void EndAndStartNewLevel(int n_targetlevel)
    {
        targetLevel = n_targetlevel;
    }

    private void SwitchTerrain(int n_targetLevel)
    {
        if (currentLevel == -1)
        {
            saveThisTerrain = Instantiate(terrainStartPrefabs[0], terrainStartLocations[0], Quaternion.identity);
            currentLevel = 0;
            currentLevel = n_targetLevel;
            EndAndStartNewLevel(1);
        }
        else
        {
            GameObject[] terrains = GameObject.FindGameObjectsWithTag("Terrain");
            foreach (GameObject terrain in terrains)
            {
                if (terrain != saveThisTerrain)
                {
                    Debug.Log("Destroying terrain");
                    Destroy(terrain);
                }
            }
            Instantiate(terrainPrefabs[n_targetLevel], terrainLocations[n_targetLevel], Quaternion.identity);
            currentLevel = n_targetLevel;
            saveThisTerrain = Instantiate(terrainStartPrefabs[n_targetLevel], terrainStartLocations[n_targetLevel], Quaternion.identity);
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    static public void ResetGame()
    {
        targetLevel = 0;
    }

    IEnumerator SceneStartTransition()
    {
        cam.orthographicSize += 0.07f;
        yield return new WaitForSeconds(0.01f);
        if (cam.orthographicSize < 5)
        {
            StartCoroutine(SceneStartTransition());
        }
        else
        {
            cam.orthographicSize = 5f;
        }
    }
}
