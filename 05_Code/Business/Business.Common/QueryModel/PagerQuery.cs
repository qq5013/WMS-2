using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Business.Common.QueryModel
{
    [DataContract]
    [Serializable]
    public sealed class PagerQuery
    {
        private List<Criterion> _criteria = new List<Criterion>();

        private QueryOperator _operator = QueryOperator.And;

        private string _domainObjectName;

        private string _selectedPropertyNameList;

        private string _orderedPropertyName;

        private OrderClause.OrderClauseCriteria _orderType;

        private string _primaryPropertyName;

        private int _pageSize;

        private int _pageCount;

        [DataMember(IsRequired = true)]
        public List<Criterion> Criteria
        {
            set { _criteria = value; }
            get { return _criteria; }
        }

        [DataMember(IsRequired = true)]
        public QueryOperator Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        [DataMember(IsRequired = true)]
        public string DomainObjectName
        {
            set { _domainObjectName = value; }
            get { return _domainObjectName; }
        }

        [DataMember(IsRequired = true)]
        public string SelectedPropertyNameList
        {
            set { _selectedPropertyNameList = value; }
            get { return _selectedPropertyNameList; }
        }

        [DataMember(IsRequired = true)]
        public string OrderedPropertyName
        {
            set { _orderedPropertyName = value; }
            get { return _orderedPropertyName; }
        }

        [DataMember(IsRequired = true)]
        public OrderClause.OrderClauseCriteria OrderType
        {
            set { _orderType = value; }
            get { return _orderType; }
        }

        [DataMember(IsRequired = true)]
        public string PrimaryPropertyName
        {
            set { _primaryPropertyName = value; }
            get { return _primaryPropertyName; }
        }

        [DataMember(IsRequired = true)]
        public int PageSize
        {
            set { _pageSize = value; }
            get { return _pageSize; }
        }

        [DataMember(IsRequired = true)]
        public int PageCount
        {
            set { _pageCount = value; }
            get { return _pageCount; }
        }

        public PagerQuery(string domainObjectName, string primaryPropertyName, string selectedPropertyNameList, string orderedPropertyName, OrderClause.OrderClauseCriteria orderType, int pageSize, int pageCount, List<Criterion> criterionList)
        {
            _domainObjectName = domainObjectName;
            _primaryPropertyName = primaryPropertyName;
            _selectedPropertyNameList = selectedPropertyNameList;
            _orderedPropertyName = orderedPropertyName;
            _orderType = orderType;
            _pageSize = pageSize;
            _pageCount = pageCount;
            _criteria = criterionList;
        }

        public string ToSqlCondition()
        {
            //return base.ToString();
            string condition = string.Empty;
            foreach (Criterion criterion in Criteria)
            {
                var value = criterion.Value;

                if (criterion.Value is string || criterion.Value is DateTime)
                {
                    value = "'" + criterion.Value + "'";
                }

                if (criterion.Value is bool)
                {
                    if ((bool)criterion.Value)
                        value = 1.ToString();
                    else
                        value = 0.ToString();
                }

                if (criterion.Value is object[])
                {
                    object[] list = criterion.Value as object[];
                    string subString = string.Empty;

                    foreach (var item in list)
                    {
                        if (item is string)
                        {
                            if (subString == string.Empty)
                                subString = "'" + item + "'";
                            else
                                subString = subString + ", " + "'" + item + "'";
                        }
                        if (item is int)
                        {
                            if (subString == string.Empty)
                                subString = item.ToString();
                            else
                                subString = subString + ", " + item.ToString();
                        }
                    }
                    value = " (" + subString + ") ";
                }
                if (criterion.Operator == CriteriaOperator.IsNotNull || criterion.Operator == CriteriaOperator.IsNull)
                {
                    value = string.Empty;
                }


                if (condition != string.Empty)
                    condition = condition + ConvertQueryOperator(Operator);

                condition = condition + criterion.PropertyName + ConvertOperator(criterion.Operator) + value;
            }

            if (string.IsNullOrEmpty(condition))
            {
                condition = " 1 = 1 ";
            }

            return condition;
        }

        public static string ConvertQueryOperator(QueryOperator queryOperator)
        {
            string result = string.Empty;

            switch (queryOperator)
            {
                case QueryOperator.And:
                    {
                        result = " AND ";
                        break;
                    }
                case QueryOperator.Or:
                    {
                        result = " OR ";
                        break;
                    }
            }

            return result;
        }

        public static string ConvertOperator(CriteriaOperator criteriaOperator)
        {
            string result = string.Empty;

            switch (criteriaOperator)
            {
                case CriteriaOperator.Equal:
                    {
                        result = " = ";
                        break;
                    }
                case CriteriaOperator.GreaterThan:
                    {
                        result = " > ";
                        break;
                    }
                case CriteriaOperator.GreaterThanOrEqual:
                    {
                        result = " >= ";
                        break;
                    }
                case CriteriaOperator.IsNotNull:
                    {
                        result = " IS NOT NULL ";
                        break;
                    }
                case CriteriaOperator.IsNull:
                    {
                        result = " IS NULL ";
                        break;
                    }
                case CriteriaOperator.LesserThan:
                    {
                        result = " < ";
                        break;
                    }
                case CriteriaOperator.LesserThanOrEqual:
                    {
                        result = " <= ";
                        break;
                    }
                case CriteriaOperator.Like:
                    {
                        result = " LIKE ";
                        break;
                    }
                case CriteriaOperator.NotEqual:
                    {
                        result = " <> ";
                        break;
                    }
                case CriteriaOperator.NotLike:
                    {
                        result = " NOT LIKE ";
                        break;
                    }
                case CriteriaOperator.In:
                    {
                        result = " IN ";
                        break;
                    }
            }

            return result;
        }

        public static string ConvertOrderClauseCriteria(OrderClause.OrderClauseCriteria criteria)
        {
            string result = string.Empty;

            switch (criteria)
            {
                case OrderClause.OrderClauseCriteria.Ascending:
                    {
                        result = "0";
                        break;
                    }
                case OrderClause.OrderClauseCriteria.Descending:
                    {
                        result = "1";
                        break;
                    }
            }

            return result;
        }
    }
}