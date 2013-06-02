using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Business.Common.QueryModel
{
    [DataContract]
    [Serializable]
    public sealed class Query
    {
        private List<Criterion> _criteria = new List<Criterion>();
        private List<OrderClause> _orderClauses = new List<OrderClause>();
        private List<Query> _subQueries = new List<Query>();
        private QueryOperator _operator = QueryOperator.And;

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
        public List<Query> SubQueries
        {
            set { _subQueries = value; }
            get { return _subQueries; }
        }

        [DataMember(IsRequired = true)]
        public List<OrderClause> OrderClauses
        {
            set { _orderClauses = value; }
            get { return _orderClauses; }
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

                if (criterion.Value is Nullable)
                {
                    value = "'" + criterion.Value + "'";
                    Framework.Core.Logger.LogHelper.WriteDebugLog("Value is null");
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
                condition = " 1=1 ";
            }
            foreach (var item in SubQueries)
            {
                item.OrderClauses = new List<OrderClause>();
                condition = condition + ConvertQueryOperator(Operator) + "(" + item.ToSqlCondition() + ")";
            }
            string orderString = string.Empty;
            foreach (var clause in OrderClauses)
            {
                string propertyName = clause.PropertyName;
                string criterion = ConvertOrderClauseCriteria(clause.Criterion);

                if (orderString == string.Empty)
                    orderString = propertyName + " " + criterion;
                else
                    orderString = orderString + ", " + propertyName + " " + criterion;
            }

            if (orderString == string.Empty)
                return condition;
            else
                return condition + " ORDER BY " + orderString;
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
                        result = "ASC";
                        break;
                    }
                case OrderClause.OrderClauseCriteria.Descending:
                    {
                        result = "DESC";
                        break;
                    }
            }

            return result;
        }
    }
}