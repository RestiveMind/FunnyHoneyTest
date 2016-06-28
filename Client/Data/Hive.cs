using System;
using System.Xml.Serialization;
using Core.ViewModel;

namespace Client.Data
{
    /// <summary>
    ///     Class, that represent a single Hive
    /// </summary>
    [Serializable]
    public class Hive : NotificationObject
    {
        private int _amountOfBeesInsideHive;
        private int _amountOfGuards;
        private int _amountOfHoney;
        private int _amountOfWorkerBees;

        /// <summary>
        ///     Gets or set hive id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets amount of honey in the hive.
        /// </summary>
        public int AmountOfHoney
        {
            get { return _amountOfHoney; }
            set
            {
                if (value == _amountOfHoney) return;
                _amountOfHoney = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets amount of queens. Always return 1.
        /// </summary>
        public int AmountOfQueens => 1;

        /// <summary>
        ///     Gets or sets amount of guards in the hive.
        /// </summary>
        public int AmountOfGuards
        {
            get { return _amountOfGuards; }
            set
            {
                if (value == _amountOfGuards) return;
                _amountOfGuards = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalAmountOfBees));
            }
        }

        /// <summary>
        ///     Gets or sets amount of workers in the hive.
        /// </summary>
        public int AmountOfWorkerBees
        {
            get { return _amountOfWorkerBees; }
            set
            {
                if (value == _amountOfWorkerBees) return;
                _amountOfWorkerBees = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalAmountOfBees));
            }
        }

        /// <summary>
        ///     Gets or sets amount of bees inside the hive.
        /// </summary>
        public int AmountOfBeesInsideHive
        {
            get { return _amountOfBeesInsideHive; }
            set
            {
                if (value == _amountOfBeesInsideHive) return;
                _amountOfBeesInsideHive = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets total amount of bees in the hive. As sum of <see cref="AmountOfQueens" />, <see cref="AmountOfGuards" /> and
        ///     <see cref="AmountOfWorkerBees" />
        /// </summary>
        [XmlIgnore]
        public long TotalAmountOfBees => AmountOfQueens +
                                         AmountOfGuards +
                                         AmountOfWorkerBees;
    }
}