using System.Runtime.Serialization;
using System;

namespace Business.Common.QueryModel
{
    /// <summary>
    /// Represents an order imposed upon a result set. 
    /// </summary>
    [DataContract]
    [Serializable]
    public class OrderClause
    {
        #region OrderClauseCriteria enum

        /// <summary>
        /// Specifies the criterion of a Idiorm.OrderClause
        /// </summary>
        public enum OrderClauseCriteria
        {
            /// <summary>
            /// An operator that represents an "ascending" criterion.
            /// </summary>
            Ascending,

            /// <summary>
            /// An operator that represents a "descending" criterion.
            /// </summary>
            Descending
        }

        #endregion

        private OrderClauseCriteria _criterion;
        private string _propertyName;

        /// <summary>
        /// Initializes a new instance of the Idiorm.OrderClause class.
        /// </summary>
        /// <param name="propertyName">The name of the property to order for.</param>
        /// <param name="criteria">The operator of the new Idiorm.OrderClause object.</param>
        public OrderClause(string propertyName, OrderClauseCriteria criteria)
        {
            _propertyName = propertyName;
            _criterion = criteria;
        }

        /// <summary>
        /// Gets the name of the property to map
        /// </summary>
        [DataMember(IsRequired = true)]
        public string PropertyName
        {
            set { _propertyName = value; }
            get { return _propertyName; }
        }

        /// <summary>
        /// Gets the ordering criterion of the clause
        /// </summary>
        [DataMember(IsRequired = true)]
        public OrderClauseCriteria Criterion
        {
            set { _criterion = value; }
            get { return _criterion; }
        }
    }
}