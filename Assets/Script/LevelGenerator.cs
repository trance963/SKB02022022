using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] BlobPrefabs;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBwtweenPlatforms;
    public Coal coal;
    public float ExtraH = 0.25f;

    public void Awake()
    {
        int levelIndex = coal.LevelIndex;
        Random random = new Random(levelIndex); // генерация по индексу
        int platformsCount = RandomRange(random, MinPlatforms, MaxPlatforms + 1);

        for (int i=0; i < platformsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, BlobPrefabs.Length);
            Vector3 position = new Vector3(RandomRange(random, 0.5f, -0.5f), 15 + ExtraH, DistanceBwtweenPlatforms * i + 25);
            Quaternion rotation = Quaternion.Euler(0, RandomRange(random, 0f, 360f), 0);
            Instantiate(BlobPrefabs[prefabIndex], position, rotation, transform);
        }
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }
}
