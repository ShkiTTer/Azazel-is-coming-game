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
    public static int CntMobs = 10;
    public static bool EndGame = false, IsPause = false;

    public static Level CurrentLevel = new Level(4, new Dictionary<MobType, double>
    {
        {MobType.Skeleton, 1}
    });

    public static Level BonusLevel = new Level(5, new Dictionary<MobType, double> {{MobType.Cow, 1}}, 2);

    //Массив рекордов
    public static int[] Records = new int[1];

    //Имя папки и файла для сохранения
    private static string FolderName = Application.dataPath + "/User_Data";
    private static string FName = FolderName + @"/" + "save.hy";
    private static System.Random rnd = new System.Random();

    public static void RunLevel()
    {
        CurrentLevel.RunLevel();
    }

    public static void NewLevel(bool bonus = false)
    {
        CurrentLevel = bonus ? BonusLevel : CreateNewLevel();
    }

    public static void ResetStats()
    {
        CurrentLevel = new Level(4, new Dictionary<MobType, double>
        {
            {MobType.Skeleton, 1}
        });
    }

    public static void RestartLevel()
    {
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