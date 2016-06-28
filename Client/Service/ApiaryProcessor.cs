using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Client.Data;

namespace Client.Service
{
    /// <summary>
    ///     Static class that contains Tasks for Apiary
    /// </summary>
    internal static class ApiaryProcessor
    {
        /// <summary>
        ///     Task to creates new bees.
        /// </summary>
        /// <param name="apiary">Apiary</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        internal static Task CreateBeesTask(Apiary apiary, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                while (!cancellationToken.IsCancellationRequested)
                {
                    var hive = apiary.Hives[rnd.Next(0, apiary.Hives.Count)];

                    //Decide what kind of bee will be created
                    if (hive.AmountOfGuards == ApiaryDataManager.GetAmountOfGuards(hive.AmountOfWorkerBees))
                        hive.AmountOfWorkerBees++;
                    else
                        hive.AmountOfGuards++;

                    apiary.RaiseNumberOfBeesPropertyChanged();

                    //Adds some delay
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }, cancellationToken);
        }

        /// <summary>
        ///     Task to production honey.
        /// </summary>
        /// <param name="apiary">Apiary</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        internal static Task HoneyProductionTask(Apiary apiary, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                //Hive id and amount of worker bees from it
                var beesOutside = new Dictionary<int, int>(apiary.Hives.Count);
                apiary.Hives.ForEach(
                    hive => beesOutside.Add(hive.Id, hive.AmountOfWorkerBees - hive.AmountOfBeesInsideHive));

                var rnd = new Random(DateTime.Now.Millisecond);
                while (!cancellationToken.IsCancellationRequested)
                {
                    apiary.Hives.ForEach(hive =>
                    {
                        if (hive.AmountOfBeesInsideHive > hive.AmountOfWorkerBees/2)
                        {
                            //take 90% of worker bees
                            hive.AmountOfBeesInsideHive = hive.AmountOfWorkerBees*10/100;
                            beesOutside[hive.Id] = hive.AmountOfWorkerBees - hive.AmountOfBeesInsideHive;
                        }
                    });

                    //bees find hive or not
                    if (rnd.Next()%2 == 0)
                    {
                        //return bees to home
                        var hive = apiary.Hives[rnd.Next(0, apiary.Hives.Count)];
                        var amountToReturn = beesOutside[hive.Id] > hive.AmountOfGuards
                            ? hive.AmountOfGuards
                            : beesOutside[hive.Id];
                        hive.AmountOfBeesInsideHive += amountToReturn;
                        //each bee carries 1 amount of honey
                        hive.AmountOfHoney += amountToReturn;
                    }

                    //Adds some delay
                    Thread.Sleep(50);
                }
            }, cancellationToken);
        }

        /// <summary>
        ///     Task to collect honey.
        /// </summary>
        /// <param name="apiary">Apiary</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        internal static Task CollectHoneyTask(Apiary apiary, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                apiary.Hives.ForEach(hive =>
                {
                    apiary.AmountOfCollectedHoney += hive.AmountOfHoney;
                    hive.AmountOfHoney = 0;
                });
            }, cancellationToken);
        }
    }
}