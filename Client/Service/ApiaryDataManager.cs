using System;
using System.Collections.Generic;
using System.IO;
using Client.Data;
using Client.Properties;
using Core.Service;

namespace Client.Service
{
    /// <summary>
    ///     Service to load or generate the Apiary
    /// </summary>
    internal static class ApiaryDataManager
    {
        private static readonly string CachePath;

        static ApiaryDataManager()
        {
            CachePath = GetCacheFilePath();
        }

        private static string GetCacheFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FunnyHoney\\data.xml");
        }

        private static Apiary GenerateApiary()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var hivesCount = Settings.Default.HivesCount;
            var hives = new List<Hive>(hivesCount);
            for (var i = 0; i < hivesCount; i++)
            {
                var amountOfWorkerBees = random.Next(
                    Settings.Default.BeesCountMin,
                    Settings.Default.BeesCountMax);
                var amountOfGuards = GetAmountOfGuards(amountOfWorkerBees);

                hives.Add(new Hive
                {
                    Id = i + 1,
                    AmountOfWorkerBees = amountOfWorkerBees,
                    AmountOfBeesInsideHive = amountOfWorkerBees,
                    AmountOfGuards = amountOfGuards
                });
            }
            return new Apiary(hives);
        }

        internal static int GetAmountOfGuards(int amountOfWorkerBees)
        {
            return Settings.Default.PercentageOfGuards*amountOfWorkerBees/100;
        }

        /// <summary>
        ///     Load Apiary from cache or generate new by config.
        /// </summary>
        /// <returns></returns>
        internal static Apiary Load()
        {
            return File.Exists(CachePath) ? CacheHelper.Load<Apiary>(CachePath) : GenerateApiary();
        }

        /// <summary>
        ///     Save Apiary into cache.
        /// </summary>
        /// <param name="apiary"></param>
        internal static void Save(Apiary apiary)
        {
            CacheHelper.Save(apiary, CachePath);
        }
    }
}