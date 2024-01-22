using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerSpawn2 : MonoBehaviour
{
    public GameObject Roamer;
    private int counter = 0;

    public GameObject RoamerGroup;
    public GameObject RoamerGroupee;

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
    public static float Multiplier = 0.5f;
    public static float ElapsedMultiplier = 1;
    public bool LoadTestDemo = false;

    int Wait = 10000;
    bool FirstRan = true;

    void Start()
    {
        CurrentWaveTimer = WaveTimer;
        CurrentRandomSpawnTimer = RandomSpawnTimer;
        CurrentEliteEnemyTimer = EliteEnemyTimer;
        EnrageLeft = Enrage;
        RandomSpawn(transform.position, 30, 5);
        RandomSpawn(transform.position, 30, 5);
        RandomSpawn(transform.position, 30, 5);

        WaveTimer = 60000;
        WaverTimerMod = 1000;
        BaseWaveEnemyAmount = 20;
        BaseWaveEnemyAmountMod = 10;
        RandomSpawnTimer = 23000;
        CurrentRandomSpawnTimer = 0;
        RandomSpawnTimerMod = 100;
        EliteEnemyTimer = 300000;
        EliteEnemyTimerMod = 1000;
        Enrage = 40;
        EnrageMod = 1;
        CurrentWaveTimer = WaveTimer;
        CurrentRandomSpawnTimer = RandomSpawnTimer;
        CurrentEliteEnemyTimer = EliteEnemyTimer;
        EnrageLeft = Enrage;
        Multiplier = 1;
        ElapsedMultiplier = 1;
        LoadTestDemo = false;
        Wait = 1000;
        FirstRan = false;
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
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (FirstRan == true)
        {
            Wait = 1000;
            FirstRan = false;
        }
        Wait--;
        if (Wait >= 0)
        {
            Debug.Log("ARI");
            return;
        }
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
        if (GetNearRoamers(new Vector2(50, 50)) <= 3 + (int)Difficulty() && Wait <=0)
        {;
            RandomSpawn(transform.position, 45, 20);
        }
        if (GetNearRoamersOfType(new Vector2(55, 55), 1) <= 5 * Difficulty() && Wait <= 0)
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
        for(int i = 0; i < AllPos.Length; i++)
        {
            Spawn(AllPos[i], 1);
        }
        // SpawnRoamerGroup(AllPos, BasePos);
    }
    public float Difficulty()
    {
        float m = 0;
        if (Mathf.Abs((transform.position.x + transform.position.y) / 500) < 0.1f)
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
                return;
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
        var dif = Difficulty();
        switch (Type)
        {
            case 0:
                Man.SetStats(100 * (int)dif, Type, 1 + dif, 1, 15 * dif, 4f * dif, /*playerAffinity=*/0.5f, 5f * dif, 13 * dif);
                break;
            case 1:
                Man.SetStats(90 * (int)dif, Type, 2 + dif, 0.7f, 15 * dif, 4f * dif, /*playerAffinity=*/0.8f, 5f * dif, 8 * dif);
                break;
            case 2:
                Man.SetStats(1000 * (int)dif, Type, 3 + dif, 3, 20 * dif, 4f * dif, /*playerAffinity=*/0.7f, 100f * dif, 70 * dif);
                break;
            case 3:
                Man.SetStats(1000 * (int)dif, Type, 1 + dif, 3.6f, 100 * dif, 4f * dif, /*playerAffinity=*/0.8f, 50f * dif, 120 * dif);
                break;
        }
    }
    public void SpawnRoamerGroup(Vector2[] Vec, Vector3 BasePosition)
    {
        GameObject G = Instantiate(RoamerGroup, new Vector3(BasePosition.x, BasePosition.y, -1), Quaternion.identity);
        G.GetComponent<RoamerWalk>().Animation = false;
        for (int i = 0; i < Vec.Length; i++)
        {
            GameObject G2 = Instantiate(RoamerGroupee, G.transform, true);
            G2.transform.position = new Vector3(Vec[i].x, Vec[i].y, -1);
            G2.GetComponent<RoamerManager>().SetStats(10);
        }
    }
}
