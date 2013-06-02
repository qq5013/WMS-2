using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using Frame.Utils.RelaAndCondition;
using MES.BllService;

namespace MES.Common
{
    public class EntitySetting
    {
        public EntitySetting()
        {
            ConditionOperator = ConditionOperator.Equal;
            IsShow = true;
        }

        public bool IsShow { get; set; }

        public int Width { get; set; }

        public string Name { get; set; }

        public Control Control { get; set; }

        public bool Required { get; set; }

        public ConditionOperator ConditionOperator { get; set; }

        public RepositoryItem ColumnEdit { get; set; }

        public bool Readonly { get; set; }
    }

    public class EntitySetting<T> : EntitySetting
    {
        public EntitySetting()
        {
            ConditionOperator = ConditionOperator.Equal;
        }

        public string Code
        {
            get
            {
                try
                {
                    string code = Fun.Body.ToString();
                    return code.Substring(code.IndexOf(".") + 1);
                }
                catch (Exception ex)
                {
                    ex.Process();
                    return string.Empty;
                }
            }
        }

        public LambdaExpression Fun { get; set; }

      
    }
}