using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerSpawn2 : MonoBehaviour
{
    public GameObject Roamer;
    public static int RoamerCount = 0;
    public static float DifficultyMod = 1;
    public static float Mod = 0;
    public int MaxRoamers = 10;
    public static float CurrentDifficulty = 0;
    private int counter = 0;


    //Waves
    int WaveTimer = 60000;
    int CurrentWaveTimer;
    int WaverTimerMod = 1000;
    int BaseWaveEnemyAmount = 20;
    int BaseWaveEnemyAmountMod = 10;

    //Random Spawn
    int RandomSpawnTimer = 23000;
    int CurrentRandomSpawnTimer = 0;
    int RandomSpawnTimerMod = 100;

    //Elite Enemies
    int EliteEnemyTimer = 300000;
    int CurrentEliteEnemyTimer;
    int EliteEnemyTimerMod = 1000;
    int Enrage = 40;
    int EnrageLeft;
    int EnrageMod = 1;

    //Difficulty
    //easy = 0.75, normal = 1, hard = 1.5
    public static int Multiplier = 1;
    public static float ElapsedMultiplier = 1;
    public bool LoadTestDemo = false;

    void Start()
    {
        CurrentWaveTimer = WaveTimer;
        CurrentRandomSpawnTimer = RandomSpawnTimer;
        CurrentEliteEnemyTimer = EliteEnemyTimer;
        EnrageLeft = Enrage;
        if (LoadTestDemo)
        {
            MakeRing(/*radius=*/25, /*count=*/50);
        }
    }

    void MakeRing(float radius, int count)
    {
        for (var i = 0.0f; i < 6.28; i += 6.28f / count)
        {
            Spawn(new Vector2(radius * Mathf.Sin(i), radius * Mathf.Cos(i)), 0);
        }
    }
    GameObject Make(Vector3 pos)
    {
        var m = Instantiate(Roamer, transform);
        m.name = "spawnedRoamer" + counter;
        m.transform.position = pos;
        counter++;
        return m;

    }
    void FixedUpdate()
    {
        CurrentWaveTimer -= (int)Difficulty();
        CurrentRandomSpawnTimer -= (int)Difficulty();
        CurrentEliteEnemyTimer -= (int)Difficulty();
        if (CurrentWaveTimer <= 0)
        {
            WaveTimer -= (int)(WaverTimerMod * Difficulty());
            CurrentWaveTimer = WaveTimer;
            BaseWaveEnemyAmountMod += (BaseWaveEnemyAmountMod / (int)(3 * Difficulty()));
            BaseWaveEnemyAmount += BaseWaveEnemyAmountMod;
            SpawnWave(BaseWaveEnemyAmount, transform.position, 60, 30 - ((int)Difficulty()), 3);
        }
        if (CurrentRandomSpawnTimer <= 0)
        {
            RandomSpawnTimer -= (RandomSpawnTimerMod * (int)Difficulty());
            CurrentRandomSpawnTimer = RandomSpawnTimer;
            RandomSpawn(transform.position, 45, 19);
        }
        if (GetNearRoamers(new Vector2(50, 50)) <= 3 + (int)Difficulty())
        {
            RandomSpawn(transform.position, 45, 20);
        }
        if (GetNearRoamersOfType(new Vector2(55, 55), 1) <= 5 * Difficulty())
        {
            CurrentWaveTimer -= (int)Random.Range(1, 3 * Difficulty());
        }
        if (EnrageLeft <= 0)
        {
            Enrage -= EnrageMod + (int)Difficulty();
            EnrageLeft = Enrage;
            Spawn(RandomSpawnPosition(transform.position, 100, 60), 3);
        }
        if (CurrentEliteEnemyTimer <= 0)
        {
            EliteEnemyTimer -= EliteEnemyTimerMod * (int)Difficulty();
            CurrentEliteEnemyTimer = EliteEnemyTimer;
            Spawn(RandomSpawnPosition(transform.position, 90, 40), 2);
        }
        ElapsedMultiplier += 0.000001f;
        //Debug.Log(Difficulty());
        //Time.timeScale = 10f;
    }
    public void SpawnWave(int EnemyAmount, Vector2 PlayerPosition, int Range, int ReqPlayerOffset, float GroupSeperation)
    {
        Vector2 BasePos = RandomSpawnPosition(PlayerPosition, Range / 2, ReqPlayerOffset / 2);
        Vector2[] AllPos = new Vector2[EnemyAmount];
        int rows = Random.Range(4, 10);
        Vector2 LoopVec = new Vector2(BasePos.x - ((GroupSeperation * rows) / 2), BasePos.y - ((GroupSeperation * rows) / 2));
        int loop = 0;
        float Basex = BasePos.x - ((GroupSeperation * rows) / 2);
        for (int i = 0; i < EnemyAmount; i++)
        {
            for (int i1 = 0; i1 < rows; i1++)
            {
                LoopVec.x += GroupSeperation + Random.Range(0, .7f);
                AllPos[loop] = LoopVec;
                loop++;
                if (loop >= EnemyAmount - 1)
                {
                    break;
                }
            }
            LoopVec.x = Basex;
            LoopVec.y += GroupSeperation + Random.Range(0, 0.7f);
            if (loop >= EnemyAmount - 1)
            {
                break;
            }
        }
        for (int i = 0; i < EnemyAmount; i++)
        {
            Spawn(AllPos[i], 1);
        }
    }
    public float Difficulty()
    {
        float m = 0;
        if ((Mathf.Abs((transform.position.x + transform.position.y) / 500) < 0.1f))
        {
            m = 1;
        }
        else
        {
            m = Mathf.Abs((transform.position.x + transform.position.y) / 500);
        }
        return ElapsedMultiplier * Multiplier * m;
    }
    public void RandomSpawn(Vector2 PlayerPosition, int Range, int ReqPlayerOffset)
    {
        Range /= 2;
        int loop = 0;
        while (true)
        {
            loop++;
            Vector2 Chosen = new Vector2(Random.Range(PlayerPosition.x - Range, PlayerPosition.x + Range), Random.Range(PlayerPosition.y - Range, PlayerPosition.y + Range));
            if (CheckSpawnConditions(Chosen, PlayerPosition, ReqPlayerOffset / 2))
            {
                Spawn(Chosen, 0);
            }
            if (loop == 100)
            {
                return;
            }
        }
    }
    public Vector2 RandomSpawnPosition(Vector2 PlayerPosition, int Range, int ReqPlayerOffset)
    {
        Range /= 2;
        int loop = 0;
        while (true)
        {
            loop++;
            Vector2 Chosen = new Vector2(Random.Range(PlayerPosition.x - Range, PlayerPosition.x + Range), Random.Range(PlayerPosition.y - Range, PlayerPosition.y + Range));
            if (CheckSpawnConditions(Chosen, PlayerPosition, ReqPlayerOffset / 2))
            {
                return Chosen;
            }
            if (loop == 100)
            {
                return new Vector2(0, 0);
            }
        }
    }
    public bool CheckSpawnConditions(Vector2 Chosen, Vector2 BasePosition, int ReqPlayerOffset)
    {
        if (Chosen.x >= BasePosition.x + ReqPlayerOffset || Chosen.x <= BasePosition.x - ReqPlayerOffset)
        {
            if (Chosen.y >= BasePosition.y + ReqPlayerOffset || Chosen.y <= BasePosition.y - ReqPlayerOffset)
            {
                if (GetComponent<LightMeter>().LightIntensityAtPoint(Chosen) <= 0.1f)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public int GetNearRoamers(Vector2 Near)
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Roamer");
        int Amt = 0;
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Mathf.Abs(Enemies[i].transform.position.x - transform.position.x) <= Near.x && Mathf.Abs(Enemies[i].transform.position.y - transform.position.y) <= Near.y)
            {
                Amt++;
            }
        }
        return Amt;
    }
    public int GetNearRoamersOfType(Vector2 Near, int Type)
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Roamer");
        int Amt = 0;
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Mathf.Abs(Enemies[i].transform.position.x - transform.position.x) <= Near.x && Mathf.Abs(Enemies[i].transform.position.y - transform.position.y) <= Near.y && Enemies[i].GetComponent<RoamerManager>().Type == Type)
            {
                Amt++;
            }
        }
        return Amt;
    }
    public void Spawn(Vector2 Position, int Type)
    {
        GameObject Roam = Make(new Vector3(Position.x, Position.y));
        RoamerManager Man = Roam.GetComponent<RoamerManager>();
        switch (Type)
        {
            case 0:
                Man.SetStats(100 * (int)Difficulty(), Type, 3 + Difficulty(), 1, 15 * Difficulty(), 0.1f * Difficulty(), 0.2f * Difficulty() / 100, 1.3f * Difficulty(), 13 * Difficulty());
                break;
            case 1:
                Man.SetStats(90 * (int)Difficulty(), Type, 2 + Difficulty(), 0.7f, 15 * Difficulty(), 0.3f * Difficulty(), 0.2f * Difficulty() / 100, 2.5f * Difficulty(), 8 * Difficulty());
                break;
            case 2:
                Man.SetStats(1000 * (int)Difficulty(), Type, 4 + Difficulty(), 3, 20 * Difficulty(), 1f * Difficulty(), 0.4f * Difficulty() / 100, 5f * Difficulty(), 70 * Difficulty());
                break;
            case 3:
                Man.SetStats(1000 * (int)Difficulty(), Type, 5 + Difficulty(), 3.6f, 100 * Difficulty(), 2f * Difficulty(), 1f * Difficulty() / 100, 100f * Difficulty(), 120 * Difficulty());
                break;
        }
    }
}
