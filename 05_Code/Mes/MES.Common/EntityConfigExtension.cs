using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Frame.Utils.Contract;
using Frame.Utils.RelaAndCondition;
using MES.BllService;

namespace MES.Common
{
    public static class EntityConfigExtension
    {
        public static List<EntitySetting<T>> Setting<T, TResult>(this List<EntitySetting<T>> settings,
                                                                 Expression<Func<T, TResult>> fun,
                                                                 EntitySetting s) where T : IBaseEntity
        {
            var setting = new EntitySetting<T>
                {
                    Fun = fun,
                    Name = s.Name,
                    Width = s.Width,
                    IsShow = s.IsShow,
                    Control = s.Control,
                    Required = s.Required,
                    ConditionOperator = s.ConditionOperator,
                    ColumnEdit = s.ColumnEdit,
                    Readonly = s.Readonly
                };


            settings.Add(setting);
            return settings;
        }

        public static Condition Condition<T>(this List<EntitySetting<T>> settings, Condition condition)
        {
            settings.ForEach(s =>
                {
                    if (s.Control is LookUpEdit)
                    {
                        object editValue = (s.Control as LookUpEdit).EditValue;
                        if (editValue == null) return;
                        var d = (int) editValue;
                        if (d > 0)
                            condition = condition &
                                        new BaseCondition(new EntityColumn(s.Code), s.ConditionOperator, d);
                    }
                    else if (s.Control is TextEdit)
                    {
                        if (!String.IsNullOrEmpty(s.Control.Text.Trim()))
                            if (s.ConditionOperator == ConditionOperator.Like)
                            {
                                condition = condition &
                                            new BaseCondition(new EntityColumn(s.Code), s.ConditionOperator,
                                                              "%" + s.Control.Text + "%");
                            }
                            else
                                condition = condition &
                                            new BaseCondition(new EntityColumn(s.Code), s.ConditionOperator,
                                                              s.Control.Text);
                    }
                });
            return condition;
        }


        public static void ClearValue<T>(this List<EntitySetting<T>> settings)
        {
            settings.ForEach(c =>
                {
                    if (c != null && c.Control is BaseEdit)
                    {
                        (c.Control as BaseEdit).EditValue = null;
                    }
                });
        }

        public static void DataFromEntity<T>(this List<EntitySetting<T>> settings, T t)
        {
            settings.ForEach(c =>
                {
                    if (c == null || !(c.Control is BaseEdit)) return;
                    PropertyInfo propertyInfo = typeof (T).GetProperty(c.Code);
                    object editValue = propertyInfo.GetValue(t, new object[0]);
                    (c.Control as BaseEdit).EditValue = editValue;
                });
        }

        public static void DataToEntity<T>(this List<EntitySetting<T>> settings, T t)
        {
            settings.ForEach(c =>
                {
                    if (c == null || !(c.Control is BaseEdit)) return;
                    PropertyInfo propertyInfo = typeof (T).GetProperty(c.Code);
                    object editValue = (c.Control as BaseEdit).EditValue;
                    if (propertyInfo.PropertyType == typeof (DateTime))
                    {
                        if (editValue != null)
                        {
                            var value = (DateTime) Convert.ChangeType(editValue, propertyInfo.PropertyType);
                            if (value < DateTimeHelper.Min)
                                value = DateTimeHelper.Min;
                            propertyInfo.SetValue(t, value, new object[0]);
                        }
                        else
                        {
                            propertyInfo.SetValue(t, DateTimeHelper.Min, new object[0]);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (editValue != null)
                            {
                                object value = Convert.ChangeType(editValue, propertyInfo.PropertyType);
                                propertyInfo.SetValue(t, value, new object[0]);
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.Process();
                        }
                    }
                });


            foreach (PropertyInfo propertyInfo in typeof (T).GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite && propertyInfo.PropertyType == typeof (DateTime))
                {
                    try
                    {
                        var dateTime = (DateTime) propertyInfo.GetValue(t, new object[0]);
                        if (dateTime < DateTimeHelper.Min)
                        {
                            propertyInfo.SetValue(t, DateTimeHelper.Min, new object[0]);
                        }
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }
            }
        }

        public static List<EntitySetting<T>> SetGridColumn<T>(this List<EntitySetting<T>> settings, GridView view)
        {
            PropertyInfo[] propertyInfos = typeof (T).GetProperties();

            for (int index = 0; index < settings.Count; index++)
            {
                EntitySetting<T> setting = settings[index];
                string columnName = setting.Code;
                try
                {
                    GridColumn gridColumn = view.Columns[columnName];
                    PropertyInfo propertyInfo = Array.Find(propertyInfos, c => c.Name == columnName);
                    if (propertyInfo.PropertyType == typeof (DateTime))
                    {
                        gridColumn.ColumnEdit = new RepositoryItemDateEdit
                            {
                                MinValue = new DateTime(1900, 1, 1),
                                NullDate = new DateTime(1900, 1, 1),
                                NullText = "-"
                            };
                        gridColumn.DisplayFormat.FormatType = FormatType.Custom;
                        gridColumn.DisplayFormat.FormatString = "yyyy-MM-dd";
                    }
                    gridColumn.Caption = setting.Name;
                    gridColumn.Width = setting.Width;
                    gridColumn.VisibleIndex = index + 1;
                    gridColumn.Visible = setting.IsShow;
                    if (setting.ColumnEdit != null)
                    {
                        gridColumn.ColumnEdit = setting.ColumnEdit;
                    }
                }
                catch (Exception exception)
                {
                    exception.Process();
                }
            }

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (settings.Find(c => c.Code == propertyInfo.Name) == null)
                {
                    string columnName = propertyInfo.Name;
                    try
                    {
                        view.Columns[columnName].Caption = propertyInfo.Name;
                        view.Columns[columnName].Width = 100;
                        view.Columns[columnName].VisibleIndex = 99;
                        view.Columns[columnName].Visible = false;
                    }
                    catch (Exception exception)
                    {
                        exception.Process();
                    }
                }
            }

            try
            {
                view.Columns["OperationName"].VisibleIndex = 99;
                view.Columns["OperationName"].Visible = false;
            }
            catch (Exception exception)
            {
                exception.Process();
            }

            try
            {
                view.Columns["TempId"].VisibleIndex = 99;
                view.Columns["TempId"].Visible = false;
            }
            catch (Exception exception)
            {
                exception.Process();
            }
            return settings;
        }

        public static bool Validate<T>(this List<EntitySetting<T>> settings, ErrorProvider validator)
        {
            bool result = true;
            validator.Clear();
            foreach (var setting in settings)
            {
                if (setting.Required && String.IsNullOrEmpty(setting.Control.Text))
                {
                    validator.SetError(setting.Control, "请填写" + setting.Name + "。");
                    result = false;
                }
            }

            return result;
        }

        public static T Mapper<T>(this object obj) where T : new()
        {
            var t = new T();
            if (obj == null)
            {
                return t;
            }
            List<PropertyInfo> propertyInfos = typeof (T).GetProperties().ToList();
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    PropertyInfo find =
                        propertyInfos.Find(
                            c =>
                            c.PropertyType == propertyInfo.PropertyType && c.Name == propertyInfo.Name && c.CanWrite);
                    if (find != null)
                    {
                        find.SetValue(t, propertyInfo.GetValue(obj, new object[0]), new object[0]);
                    }
                }
            }
            return t;
        }

        public static void Mapper<T, T2>(this IEnumerable<T> obj, IList<T2> to) where T : new() where T2 : new()
        {
            foreach (T variable in obj)
            {
                to.Add(Mapper<T2>(variable));
            }
        }
    }
}