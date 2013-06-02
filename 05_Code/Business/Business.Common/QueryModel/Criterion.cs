using System.Runtime.Serialization;

namespace Business.Common.QueryModel
{
    [DataContract]
    public class Criterion
    {
        /// <summary>
        /// Initializes a new instance of the Idiorm.Criterion class.
        /// </summary>
        public Criterion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Idiorm.Criterion class that uses the property name, the value and the operator of the new Idiorm.Criterion.
        /// </summary>
        /// <param name="propertyName">The name of the property to map.</param>
        /// <param name="operator">The operator of the new Idiorm.Criterion object.</param>
        /// <param name="value">The value of the new Idiorm.Criterion object.</param>
        public Criterion(string propertyName, CriteriaOperator @operator, object value)
            : this()
        {
            PropertyName = propertyName;
            Value = value;
            Operator = @operator;
        }

        /// <summary>
        /// Gets or sets the name of the property to be used by the criterion
        /// </summary>
        [DataMember(IsRequired = true)]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the value of the criterion
        /// </summary>
        [DataMember(IsRequired = true)]
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the operator of the criterion
        /// </summary>
        [DataMember(IsRequired = true)]
        public CriteriaOperator Operator { get; set; }
    }
}