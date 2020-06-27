using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Enemy;
using Assets.Scripts.Level;

public class Help_Script : MonoBehaviour
{
    public static int cnt_Murder; // Кол-во убийств
    public static int SelectGG; // Выбранный герой
    public static int CntBullet; // Кол-во выпущенных пуль
    public static int CntMobs;
    public static int CntHP = 3;
    public static int AllMoney = 1000;
    public static int Money = 1000;
    public static bool EndGame = false, IsPause = false;

    public static List<Boolean> Weapons = new List<bool> {true, false, false};
    public static List<float> DamageMultipliers = new List<float> { 1f, 1f, 1f };
    public static int CurrentWeapon = 0;

    public static int CrossbowPrice = 1000, RiflePrice = 1500;
    public static int CrossbowDamagePrice = 100, CrossbowRatePrice = 100;
    public static int RifleDamagePrice = 100, RifleRatePrice = 100;

    public static Level CurrentLevel = new Level(4, new Dictionary<MobType, double>
    {
        {MobType.Skeleton, 1}
    });

    public static Level BonusLevel = new Level(5, new Dictionary<MobType, double> {{MobType.Cow, 1}}, 3);

    //Массив рекордов
    public static int[] Records = new int[1];

    //Имя папки и файла для сохранения
    private static string FolderName = Application.dataPath + "/User_Data";
    private static string FName = FolderName + @"/" + "save.hy";
    private static System.Random rnd = new System.Random();

    public static void RunLevel()
    {
        EndGame = false;
        IsPause = false;
        CurrentLevel.RunLevel();
    }

    public static void NewLevel(bool bonus = false)
    {
        CurrentLevel = bonus ? BonusLevel : CreateNewLevel();
        AllMoney = Money;
    }

    public static void ResetStats()
    {
        CntHP = 3;
        cnt_Murder = 0;
        AllMoney = 0;
        Money = 0;
        CurrentWeapon = 0;
        Weapons = new List<bool> { true, false, false };
        DamageMultipliers = new List<float> { 1f, 1f, 1f };

        CurrentLevel = new Level(4, new Dictionary<MobType, double>
        {
            {MobType.Skeleton, 1}
        });
    }

    public static void RestartLevel()
    {
        Money = AllMoney;
        CntHP = 3;
        CurrentLevel.RunLevel();
    }

    public static Level CreateNewLevel()
    {
        var wavesCount = rnd.Next(CurrentLevel.Waves.Count, (int) (CurrentLevel.Waves.Count * 1.5));
        return new Level(wavesCount, CreateProportions());
    }

    private static Dictionary<MobType, double> CreateProportions()
    {
        var skeletonProportion = rnd.NextDouble();
        var besProportion = 1 - skeletonProportion;

        return new Dictionary<MobType, double>
        {
            {MobType.Skeleton, skeletonProportion},
            {MobType.Bes, besProportion}
        };
    }

    //Сохранение массива рекордов в файл
    public static void SaveRecords()
    {
        if (!Directory.Exists(FolderName)) Directory.CreateDirectory(FolderName);

        BinaryFormatter bf = new BinaryFormatter();

        FileStream F = File.OpenWrite(FName);

        bf.Serialize(F, Records);

        F.Close();
    }

    //Загрузка массива рекордов из файла
    public static void LoadRecords()
    {
        if (File.Exists(FName))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream F = File.OpenRead(FName);

            Records = (int[]) bf.Deserialize(F);

            F.Close();
        }
    }

    public static void Save_Records()
    {
        if (Records[0] < cnt_Murder)
        {
            Records[0] = cnt_Murder;
            SaveRecords();
        }
    }
}