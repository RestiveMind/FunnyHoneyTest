using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Core.ViewModel;

namespace Client.Data
{
    /// <summary>
    ///     Class, that represent an apiary
    /// </summary>
    public class Apiary : NotificationObject
    {
        private long _amountOfCollectedHoney;

        /// <summary>
        ///     Create a new instance of <see cref="Apiary" /> class.
        /// </summary>
        public Apiary()
            : this(new List<Hive>(0))
        {
        }

        /// <summary>
        ///     Create a new instance of <see cref="Apiary" /> class.
        /// </summary>
        public Apiary(IEnumerable<Hive> hives)
        {
            Hives = new List<Hive>(hives);
        }

        /// <summary>
        ///     Gets or sets the collection of hives
        /// </summary>
        [XmlArray("Hives")]
        [XmlArrayItem("Hive")]
        public List<Hive> Hives { get; set; }

        /// <summary>
        ///     Gets the total number of bees
        /// </summary>
        public long NumberOfBees => Hives.Sum(h => h.TotalAmountOfBees);

        /// <summary>
        ///     Gets the total number of hives
        /// </summary>
        public int HivesCount => Hives.Count;

        /// <summary>
        ///     Gets the total amount of collected honey
        /// </summary>
        public long AmountOfCollectedHoney
        {
            get { return _amountOfCollectedHoney; }
            set
            {
                if (value == _amountOfCollectedHoney) return;
                _amountOfCollectedHoney = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Raise PropertyChanged event for NumberOfBees property.
        /// </summary>
        internal void RaiseNumberOfBeesPropertyChanged()
        {
            OnPropertyChanged(nameof(NumberOfBees));
        }
    }
}