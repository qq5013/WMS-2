/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         CommonAPI.cs
// 文件功能描述：   通用操作接口
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using Frame.Utils.Contract;
using Frame.Utils.Log;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using MES.Enum;
using MES.Execute.Controls;
using MES.Execute.Properties;

namespace MES.Execute.Common
{
    /// <summary>
    ///     通用操作库
    /// </summary>
    public static class CommonApi
    {
        /// <summary>
        ///     记录日志
        /// </summary>
        public static ILogger Logger = new FileLogger();

        /// <summary>
        ///     物料追踪
        /// </summary>
        private static IEntityService<MaterielTrace> _materielTraceService;

        /// <summary>
        ///     当前用户
        /// </summary>
        private static User _currentUser;

        /// <summary>
        ///     当前工位
        /// </summary>
        private static ProductStation _currentProductStation;

        /// <summary>
        ///     权限
        /// </summary>
        private static List<Permission> _permissions;

        private static object[] _emptyTypes = new object[0];

        /// <summary>
        ///     当前工序
        /// </summary>
        public static Process CurrentProcess { get; set; }

        /// <summary>
        ///     当前工位
        /// </summary>
        public static ProductStation CurrentProductStation
        {
            get
            {
                string setting = ConfigurationManager.AppSettings["ProductStation"];
                // 如果工位有配置，则当前工位设为改工位
                if (!String.IsNullOrEmpty(setting))
                {
                    _currentProductStation = ServiceBloker.GetService<ProductStation>().Find(c => c.Code == setting);
                }
                return _currentProductStation;
            }
            set { _currentProductStation = value; }
        }

        /// <summary>
        ///     默认单位
        /// </summary>
        public static int DefaultMeasureId
        {
            get { return 1; }
        }

        /// <summary>
        ///     当前工序控件
        /// </summary>
        public static UcProcessNormal CurrentProcessControl { get; set; }

        /// <summary>
        ///     统一显示错误
        /// </summary>
        /// <param name="error"></param>
        public static void ShowError(string error)
        {
            MessageBox.Show(error);
        }

        /// <summary>
        ///     显示对话框
        /// </summary>
        /// <param name="control">对话框内控件</param>
        /// <param name="text">标题</param>
        public static void ShowDialog(this UserControl control, string text)
        {
            control.Dock = DockStyle.Fill;
            var form = new Form
                {
                    Controls = {control},
                    FormBorderStyle = FormBorderStyle.Fixed3D,
                    ShowInTaskbar = false,
                    Text = text,
                    StartPosition = FormStartPosition.CenterScreen,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    Size = new Size(1366, 768),
                    WindowState = FormWindowState.Maximized
                };
            var closing = control as ICheckClosing;
            // 当关闭的时候检查数据是否未保存，如果未保存则询问是否要保存
            if (closing != null)
            {
                form.Closing += (sender, e) =>
                    {
                        // 如果数据未改变则关闭
                        if (!closing.DataChanged) return;
                        switch (
                            MessageBox.Show(closing.Title + Resources.DataChangedSaveSuccess, Resources.Notice,
                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button1))
                        {
                            case DialogResult.Cancel:
                                e.Cancel = true;
                                break;
                            case DialogResult.Yes:
                                // 如果选择保存且保存失败，则不关闭
                                if (!closing.Save()) e.Cancel = true;
                                break;
                            case DialogResult.No:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    };
            }

            form.ShowDialog();
        }

        /// <summary>
        ///     选择订单 绑定单据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buttonEdit"></param>
        /// <param name="title"></param>
        /// <param name="setOrderCode"></param>
        /// <param name="types"></param>
        /// <param name="status"></param>
        public static void BindOrder<T>(this ButtonEdit buttonEdit, string title, SetOrderCode setOrderCode, int[] types,
                                        int[] status)
            where T : UserControl, IInitControl, IOrderControl, new()
        {
            buttonEdit.ButtonClick += (sender, e) =>
                {
                    var control = new T
                        {
                            OpenMode = OpenMode.SingleSelect,
                            Types = types,
                            Status = status
                        };
                    // 如果没有设置单据号方法传入，则给buttonEdit赋值
                    if (setOrderCode == null)
                    {
                        control.SetOrderCode = code => { buttonEdit.EditValue = code; };
                    }
                    else
                    {
//如果有设置单据号方法传入，则调用
                        control.SetOrderCode = setOrderCode;
                    }

                    // 控件初始化
                    control.Init();
                    control.Dock = DockStyle.Fill;
                    var form = new Form
                        {
                            Controls = {control},
                            FormBorderStyle = FormBorderStyle.Fixed3D,
                            ShowInTaskbar = false,
                            Text = title,
                            StartPosition = FormStartPosition.CenterParent,
                            Size = new Size(1366, 768)
                        };


                    form.ShowDialog();
                };
        }

        /// <summary>
        ///     隐藏查询按钮
        /// </summary>
        /// <param name="barManager"></param>
        public static void HideInNotQuery(this BarManager barManager)
        {
            foreach (BarItem item in barManager.Items)
            {
                // 如果为查询按钮则隐藏
                if (item.Name != "btnQuery")
                    item.Visibility = BarItemVisibility.Never;
            }
        }

        /// <summary>
        ///     绑定单据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buttonEdit"></param>
        /// <param name="title"></param>
        public static void BindOrder<T>(this ButtonEdit buttonEdit, string title)
            where T : UserControl, IInitControl, IOrderControl, new()
        {
            BindOrder<T>(buttonEdit, title, null, null, null);
        }

        /// <summary>
        ///     显示Tab页
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="control"></param>
        /// <param name="text"></param>
        /// <param name="menuId"></param>
        public static void ShowPage(this XtraTabControl tabControl, UserControl control, string text, object menuId)
        {
            ShowPage(tabControl, control, text, DefaultBoolean.Default, menuId);
        }

        /// <summary>
        ///     显示Tab页
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="control"></param>
        /// <param name="text"></param>
        /// <param name="showCloseButton"></param>
        /// <param name="menuId"></param>
        public static void ShowPage(this XtraTabControl tabControl, UserControl control, string text,
                                    DefaultBoolean showCloseButton, object menuId)
        {
            control.Dock = DockStyle.Fill;
            XtraTabPage page = null;
            // 根据菜单id找到菜单对应Page
            if (null != menuId)
            {
                page = tabControl.TabPages.ToList().Find(c => c.Tag == menuId);
            }
            // 如果page不存在着新建
            if (page == null)
            {
                page = new XtraTabPage
                    {Controls = {control}, Text = text, ShowCloseButton = showCloseButton, Tag = menuId};
                tabControl.TabPages.Add(page);
                tabControl.Visible = true;
            }

            tabControl.SelectedTabPage = page;
        }

        /// <summary>
        ///     绑定供应商
        /// </summary>
        /// <param name="repositoryItemLookUpEdit"></param>
        public static void BindVendor(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = ServiceBloker.GetService<Vendor>().GetAll(new QueryInfo());
            repositoryItemLookUpEdit.DisplayMember = "Name";
            repositoryItemLookUpEdit.ValueMember = "VendorId";
            repositoryItemLookUpEdit.NullText = "";
        }

        /// <summary>
        ///     绑定供应商
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindVendor(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<Vendor>().GetAll(new QueryInfo());
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "VendorId";
            repositoryItemGridLookUpEdit.NullText = "";
            repositoryItemGridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code
                        }
                });
        }

        /// <summary>
        ///     绑定供应商
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindVendor(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "VendorId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮作用清空控件内容
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Vendor>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定度量单位
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindMeasure(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "MeasureId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Edit)
            //{
            //    gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            //    gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
            //    {
            //        if (e.Button.Kind == ButtonPredefines.Plus)
            //        {
            //            new UcVendorList().ShowDialog("新建供应商");
            //        }
            //    };
            //}
            //if (controlMode == ControlMode.Query)
            //{
            //    gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            //    gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
            //    {
            //        if (e.Button.Kind == ButtonPredefines.Delete && gridLookUpEdit.Properties.ReadOnly==false)
            //        {
            //            gridLookUpEdit.EditValue = null;
            //        }
            //    };
            //}
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Measure>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定用户
        /// </summary>
        /// <param name="repositoryItemLookUpEdit"></param>
        public static void BindUser(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = ServiceBloker.GetService<User>().GetAll(new QueryInfo());
            repositoryItemLookUpEdit.DisplayMember = "Name";
            repositoryItemLookUpEdit.ValueMember = "UserId";
            repositoryItemLookUpEdit.NullText = "";
        }

        /// <summary>
        ///     绑定用户
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindUser(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "UserId";
            repositoryItemGridLookUpEdit.NullText = "";
            repositoryItemGridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Description",
                            Caption = Resources.description,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<User>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定客户
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindCustomer(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "CustomerId";
            repositoryItemGridLookUpEdit.NullText = "";
            repositoryItemGridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<Customer>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定部门
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindDepartment(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "DepartmentId";
            repositoryItemGridLookUpEdit.NullText = "";
            repositoryItemGridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<Department>().GetAll(new QueryInfo());
        }


        //public static void BindUser(this LookUpEdit lookUpEdit, ControlMode controlMode)
        //{
        //    lookUpEdit.Properties.DataSource = ServiceHelper.GetService<User>().GetAll(new QueryInfo());
        //    lookUpEdit.Properties.DisplayMember = "Name";
        //    lookUpEdit.Properties.ValueMember = "UserId";
        //    lookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
        //}

        /// <summary>
        ///     绑定用户
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <param name="roles"></param>
        public static void BindUser(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode, List<string> roles)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "UserId";


            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Description",
                            Caption = Resources.description,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能清空控件内容
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            if (roles == null || roles.Count == 0)
            {
                // 如果角没有角色则绑定全体用户
                gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<User>().GetAll(new QueryInfo());
            }
            else
            {
                // 否则绑定角色对应用户
                List<int> roleIds =
                    ServiceBloker.GetService<Role>().FindAll(c => roles.Contains(c.Code)).Select(c => c.RoleId).
                                  ToList();
                if (roleIds.Count > 0)
                {
                    // 角色Id存在绑定对应用户
                    List<int> userIds =
                        ServiceBloker.GetService<UserInRole>().FindAll(c => roleIds.Contains(c.RoleId)).Select(
                            c => c.UserId).ToList();
                    // 如果用户列表存在则绑定
                    if (userIds.Count > 0)
                        gridLookUpEdit.Properties.DataSource =
                            ServiceBloker.GetService<User>().FindAll(c => userIds.Contains(c.UserId));
                }
            }
        }

        /// <summary>
        ///     绑定客户
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindCustomer(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name"; //名称
            gridLookUpEdit.Properties.ValueMember = "CustomerId"; //客户Id


            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Customer>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定部门
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindDepartment(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "DepartmentId";


            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Department>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定运输方式
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindShipVia(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "ShipViaId";


            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<ShipVia>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定产线
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindProductLine(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "ProductLineId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Description",
                            Caption = Resources.description,
                            Visible = true,
                            VisibleIndex = 3
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<ProductLine>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定工序
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <param name="productStationId"></param>
        public static void BindProcess(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode, int productStationId)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "Code";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            if (gridLookUpEdit.Properties.View.Columns.Count == 0)
                gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                    {
                        new GridColumn
                            {
                                FieldName = "Name",
                                Caption = Resources.name,
                                Visible = true,
                                VisibleIndex = 1
                            },
                        new GridColumn
                            {
                                FieldName = "Code",
                                Caption = Resources.code,
                                Visible = true,
                                VisibleIndex = 2
                            }
                    });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }

            int[] processIds =
                ServiceBloker.GetService<ProcessInProductStation>().FindAll(
                    c => c.ProductStationId == productStationId).Select
                    (c => c.ProcessId).ToArray();

            List<Process> list = processIds.Length == 0
                                     ? new List<Process>()
                                     : ServiceBloker.GetService<Process>().GetAll(new QueryInfo
                                         {
                                             Condition =
                                                 new EntityColumn(
                                                     "ProcessId").In
                                                     (processIds) &
                                                 new EntityColumn("Type") ==
                                                 ProcessType.Normal,
                                             CompositorList =
                                                 new List<Compositor>
                                                     {
                                                         new Compositor
                                                             {
                                                                 Column =
                                                                     new EntityColumn
                                                                                      ("Sequence"),
                                                                 SortDirection
                                                                     =
                                                                     ListSortDirection
                                                                                      .
                                                                                      Ascending
                                                             }
                                                     }
                                         });

            gridLookUpEdit.Properties.DataSource = list;
            gridLookUpEdit.EditValue = ConfigurationManager.AppSettings["Process"];
        }

        /// <summary>
        ///     绑定工位
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindProductStation(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "ProductStationId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<ProductStation>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定车间
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindWorkShop(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "WorkShopId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<WorkShop>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定产品分类
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindProductCategory(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "ProductCategoryId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<ProductCategory>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定仓库
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindWarehouse(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "WarehouseId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Warehouse>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定软件版本
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindSoftware(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "SoftwareId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Software>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定结果
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindResult(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "ResultId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            //{
            //    gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            //    gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
            //    {
            //        // 定义删除按钮功能，清空控件数据
            //          if (e.Button.Kind == ButtonPredefines.Delete && gridLookUpEdit.Properties.ReadOnly == false)
            //        {
            //            gridLookUpEdit.EditValue = null;
            //        }
            //    };
            //}
            gridLookUpEdit.Properties.DataSource = new[]
                {
                    new {Name = "合格", ResultId = 1},
                    new {Name = "不合格", ResultId = 2}
                };
            gridLookUpEdit.EditValue = 1;
        }

        /// <summary>
        ///     绑定产品
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <param name="isMateriel"></param>
        public static void BindProduct(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode, bool isMateriel)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "ProductId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            ColumnEdit =
                                new RepositoryItemGridLookUpEdit
                                    {
                                        DisplayMember = "Name",
                                        ValueMember =
                                            "ProductCategoryId",
                                        DataSource =
                                            ServiceBloker.GetService
                                                                <ProductCategory>().GetAll(
                                                                    new QueryInfo())
                                    },
                            FieldName = "ProductCategoryId",
                            Caption = Resources.Category,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource =
                ServiceBloker.GetService<Product>().FindAll(c => c.IsMateriel == isMateriel);
        }

        /// <summary>
        ///     绑定产品
        /// </summary>
        /// <param name="riglueProductName"></param>
        /// <param name="riglueProductCode"></param>
        /// <param name="isMateriel"></param>
        public static void BindProduct(RepositoryItemGridLookUpEdit riglueProductName,
                                       RepositoryItemGridLookUpEdit riglueProductCode, bool isMateriel)
        {
            riglueProductName.DisplayMember = "Name";
            riglueProductName.ValueMember = "ProductId";

            riglueProductCode.DisplayMember = "Code";
            riglueProductCode.ValueMember = "ProductId";

            List<Product> products = ServiceBloker.GetService<Product>().FindAll(c => c.IsMateriel == isMateriel);

            riglueProductName.DataSource = products;
            riglueProductCode.DataSource = products;
        }

        /// <summary>
        ///     绑定库位
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <param name="warehouseId"></param>
        public static void BindLocation(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode, int warehouseId)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "LocationId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Location>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定支付方式
        /// </summary>
        /// <param name="repositoryItemLookUpEdit"></param>
        public static void BindPayment(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = ServiceBloker.GetService<Payment>().GetAll(new QueryInfo());
            repositoryItemLookUpEdit.DisplayMember = "Name";
            repositoryItemLookUpEdit.ValueMember = "PaymentId";
            repositoryItemLookUpEdit.NullText = "";
        }

        /// <summary>
        ///     绑定支付方式
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindPayment(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<Payment>().GetAll(new QueryInfo());
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "PaymentId";
            repositoryItemGridLookUpEdit.NullText = "";
        }

        /// <summary>
        ///     绑定送货地址
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindDeliveryAddress(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<DeliveryAddress>()
                                                                   .GetAll(new QueryInfo());
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "DeliveryAddressId";
            repositoryItemGridLookUpEdit.NullText = "";
        }

        /// <summary>
        ///     绑定运货方式
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindShipVia(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<ShipVia>().GetAll(new QueryInfo());
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "ShipViaId";
            repositoryItemGridLookUpEdit.NullText = "";
        }

        /// <summary>
        ///     绑定单位
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindMeasure(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DataSource = ServiceBloker.GetService<Measure>().GetAll(new QueryInfo());
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "MeasureId";
            repositoryItemGridLookUpEdit.NullText = "";
        }

        /// <summary>
        ///     绑定SKU
        /// </summary>
        /// <param name="riglueSkuCategoryName"></param>
        /// <param name="riglueSkuName"></param>
        /// <param name="riglueSkuCode"></param>
        /// <param name="riglueSkuSpec"></param>
        /// <param name="riglueSkuModel"></param>
        /// <param name="riglueColor"></param>
        /// <param name="isMateriel"></param>
        public static void BindSku(RepositoryItemGridLookUpEdit riglueSkuCategoryName,
                                   RepositoryItemGridLookUpEdit riglueSkuName,
                                   RepositoryItemGridLookUpEdit riglueSkuCode,
                                   RepositoryItemGridLookUpEdit riglueSkuSpec,
                                   RepositoryItemGridLookUpEdit riglueSkuModel, RepositoryItemGridLookUpEdit riglueColor,
                                   bool isMateriel)
        {
            riglueSkuCategoryName.DisplayMember = "CategoryName";
            riglueSkuCategoryName.ValueMember = "SkuId";
            riglueSkuCategoryName.NullText = "";
            riglueSkuCategoryName.Buttons[0].Visible = false;


            riglueSkuName.DisplayMember = "Name";
            riglueSkuName.ValueMember = "SkuId";
            riglueSkuName.NullText = "";
            riglueSkuName.Buttons[0].Visible = false;

            riglueSkuCode.DisplayMember = "Code";
            riglueSkuCode.ValueMember = "SkuId";
            riglueSkuCode.NullText = "";
            riglueSkuCode.Buttons[0].Visible = false;

            riglueSkuSpec.DisplayMember = "Spec";
            riglueSkuSpec.ValueMember = "SkuId";
            riglueSkuSpec.NullText = "";
            riglueSkuSpec.Buttons[0].Visible = false;

            riglueSkuModel.DisplayMember = "Model";
            riglueSkuModel.ValueMember = "SkuId";
            riglueSkuModel.NullText = "";
            riglueSkuModel.Buttons[0].Visible = false;

            riglueColor.DisplayMember = "Color";
            riglueColor.ValueMember = "SkuId";
            riglueColor.NullText = "";
            riglueColor.Buttons[0].Visible = false;


            //riglueSkuCode.View.Columns.AddRange(new[]
            //                                        {
            //                                            new GridColumn
            //                                                {
            //                                                    FieldName = "CategoryName",
            //                                                    Caption = Resources.Category,
            //                                                    Visible = true,
            //                                                    VisibleIndex = 1
            //                                                },
            //                                            new GridColumn
            //                                                {
            //                                                    FieldName = "Name",
            //                                                    Caption = Resources.name,
            //                                                    Visible = true,
            //                                                    VisibleIndex = 1
            //                                                },
            //                                            new GridColumn
            //                                                {
            //                                                    FieldName = "Code",
            //                                                    Caption = Resources.code,
            //                                                    Visible = true,
            //                                                    VisibleIndex = 1
            //                                                },
            //                                            new GridColumn
            //                                                {
            //                                                    FieldName = "Spec",
            //                                                    Caption = Resources.Spec,
            //                                                    Visible = true,
            //                                                    VisibleIndex = 2
            //                                                },
            //                                            new GridColumn
            //                                                {
            //                                                    FieldName = "Model",
            //                                                    Caption = Resources.Model,
            //                                                    Visible = true,
            //                                                    VisibleIndex = 2
            //                                                },
            //                                            new GridColumn
            //                                                {
            //                                                    FieldName = "Color",
            //                                                    Caption = Resources.Color,
            //                                                    Visible = true,
            //                                                    VisibleIndex = 2
            //                                                }
            //                                        });


            List<SkuInfo> skuInfos = ServiceBloker.GetQuery<SkuInfo>().FindAll(t => t.IsMateriel == isMateriel);
            riglueSkuCategoryName.DataSource = skuInfos;
            riglueSkuCode.DataSource = skuInfos;
            riglueSkuModel.DataSource = skuInfos;
            riglueSkuName.DataSource = skuInfos;
            riglueSkuSpec.DataSource = skuInfos;
            riglueColor.DataSource = skuInfos;
            //if (isMateriel)
            //{
            //    riglueSkuCode.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            //    riglueSkuCode.ButtonClick += (sender, e) =>
            //                                     {
            //                                         if (e.Button.Index == 1)
            //                                         {
            //                                             var ucSkuList = new UcSkuList();
            //                                             ucSkuList.Init();
            //                                             var form = new Form
            //                                                            {
            //                                                                Controls = {ucSkuList},
            //                                                                Size = new Size(250, 230),
            //                                                                Text = "新增物料SKU信息",
            //                                                                ShowInTaskbar = false,
            //                                                                ShowIcon = false,
            //                                                                StartPosition =
            //                                                                    FormStartPosition.CenterScreen
            //                                                            };

            //                                             form.ShowDialog();
            //                                             List<SkuInfo> skuInfos2 =
            //                                                 ServiceHelper.GetQuery<SkuInfo>().FindAll(
            //                                                     t => t.IsMateriel == isMateriel, null);
            //                                             riglueSkuCategoryName.DataSource = skuInfos2;
            //                                             riglueSkuCode.DataSource = skuInfos2;
            //                                             riglueSkuModel.DataSource = skuInfos2;
            //                                             riglueSkuName.DataSource = skuInfos2;
            //                                             riglueSkuSpec.DataSource = skuInfos2;
            //                                             riglueColor.DataSource = skuInfos2;
            //                                         }
            //                                     };
            //}
        }

        /// <summary>
        ///     绑定SKU
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        /// <param name="isMateriel"></param>
        public static void BindSku(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit, bool isMateriel)
        {
            repositoryItemGridLookUpEdit.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.ValueMember = "SkuId";
            repositoryItemGridLookUpEdit.NullText = "";

            repositoryItemGridLookUpEdit.PopupFormSize = new Size(500, 350);

            repositoryItemGridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "CategoryName",
                            Caption = Resources.Category,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Spec",
                            Caption = Resources.Spec,
                            Visible = true,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Model",
                            Caption = Resources.Model,
                            Visible = true,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Color",
                            Caption = Resources.Color,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            IEntityQuery<SkuInfo> query = ServiceBloker.GetQuery<SkuInfo>();
            List<SkuInfo> skuInfos = query.FindAll(t => t.IsMateriel == isMateriel, null);
            repositoryItemGridLookUpEdit.DataSource = skuInfos;

            repositoryItemGridLookUpEdit.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            repositoryItemGridLookUpEdit.ButtonClick += (sender, e) =>
                {
                    // 定义第一个按钮选择物料
                    if (e.Button.Index == 1)
                    {
                        var ucSkuList = new UcSkuList();
                        ucSkuList.Init();
                        var form = new Form
                            {
                                Controls = {ucSkuList},
                                Size = new Size(250, 230),
                                Text = "新增物料SKU信息",
                                ShowInTaskbar = false,
                                ShowIcon = false,
                                StartPosition =
                                    FormStartPosition.
                                        CenterScreen
                            };

                        form.ShowDialog();
                        List<SkuInfo> skuInfos2 =
                            ServiceBloker.GetQuery<SkuInfo>().FindAll(
                                t => t.IsMateriel == isMateriel);
                        repositoryItemGridLookUpEdit.DataSource = skuInfos2;
                        //if (ucSkuList.Result != 0)
                        //{
                        //    repositoryItemGridLookUpEdit.d = ucSkuList.Result;
                        //}
                    }
                };
        }

        /// <summary>
        ///     绑定SKU
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <param name="isMateriel"></param>
        public static void BindSku(this GridLookUpEdit repositoryItemGridLookUpEdit, ControlMode controlMode,
                                   bool isMateriel)
        {
            BindSku(repositoryItemGridLookUpEdit, controlMode, isMateriel, null);
        }

        /// <summary>
        ///     绑定SKU
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <param name="isMateriel"></param>
        /// <param name="traceTypes"></param>
        public static void BindSku(this GridLookUpEdit repositoryItemGridLookUpEdit, ControlMode controlMode,
                                   bool isMateriel, TraceType[] traceTypes)
        {
            BindSku(repositoryItemGridLookUpEdit, controlMode,
                    isMateriel, traceTypes, null);
        }

        /// <summary>
        ///     绑定SKU
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <param name="isMateriel"></param>
        /// <param name="traceTypes"></param>
        /// <param name="skuIds"></param>
        public static void BindSku(this GridLookUpEdit repositoryItemGridLookUpEdit, ControlMode controlMode,
                                   bool isMateriel, TraceType[] traceTypes, List<int> skuIds)
        {
            repositoryItemGridLookUpEdit.Properties.DisplayMember = "Name";
            repositoryItemGridLookUpEdit.Properties.ValueMember = "SkuId";
            repositoryItemGridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query
                                                                   ? Resources.all
                                                                   : Resources.plsSelect;
            repositoryItemGridLookUpEdit.Properties.PopupFormSize = new Size(500, 350);

            repositoryItemGridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "CategoryName",
                            Caption = Resources.Category,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Spec",
                            Caption = Resources.Spec,
                            Visible = true,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Model",
                            Caption = Resources.Model,
                            Visible = true,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Color",
                            Caption = Resources.Color,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                repositoryItemGridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                repositoryItemGridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind ==
                            ButtonPredefines.Delete)
                        {
                            repositoryItemGridLookUpEdit.
                                EditValue = null;
                        }
                    };
            }
            IEntityQuery<SkuInfo> query = ServiceBloker.GetQuery<SkuInfo>();
            List<SkuInfo> skuInfos;
            if (traceTypes != null && traceTypes.Length > 0)
            {
                List<TraceType> types = traceTypes.ToList();
                if (skuIds == null || skuIds.Count == 0) //如果Sku不存在着绑定对应数据
                    skuInfos = query.FindAll(t => t.IsMateriel == isMateriel && types.Contains(t.TraceType), null);
                else
                {
                    // 如果Sku存在则绑定Sku数据
                    skuInfos =
                        query.FindAll(
                            t => t.IsMateriel == isMateriel && types.Contains(t.TraceType) && skuIds.Contains(t.SkuId),
                            null);
                }
            }
            else
            {
                if (skuIds == null || skuIds.Count == 0) // 如果Sku不存在，则返回所有
                    skuInfos = query.FindAll(t => t.IsMateriel == isMateriel, null);
                else
                {
// 如果Sku存在则返回Sku'对应
                    skuInfos = query.FindAll(t => t.IsMateriel == isMateriel && skuIds.Contains(t.SkuId), null);
                }
            }


            repositoryItemGridLookUpEdit.Properties.DataSource = skuInfos;

            repositoryItemGridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            repositoryItemGridLookUpEdit.ButtonClick += (sender, e) =>
                {
                    // 按钮2对应选择物料
                    if (e.Button.Index == 1)
                    {
                        var ucSkuList = new UcSkuList();
                        ucSkuList.Init();
                        var form = new Form
                            {
                                Controls = {ucSkuList},
                                Size = new Size(250, 230),
                                Text = "新增物料SKU信息",
                                ShowInTaskbar = false,
                                ShowIcon = false,
                                StartPosition =
                                    FormStartPosition.
                                        CenterScreen
                            };

                        form.ShowDialog();
                        List<SkuInfo> skuInfos2 =
                            ServiceBloker.GetQuery<SkuInfo>().FindAll(
                                t => t.IsMateriel == isMateriel, null);
                        repositoryItemGridLookUpEdit.Properties.DataSource =
                            skuInfos2;
                        // 如果Sku返回不为空，着赋值
                        if (ucSkuList.Result != 0)
                        {
                            repositoryItemGridLookUpEdit.EditValue =
                                ucSkuList.Result;
                        }
                    }
                };
        }

        /// <summary>
        ///     绑定支付
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindPayment(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "PaymentId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<Payment>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定收货地址
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void BindDeliveryAddress(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "DeliveryAddressId";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetService<DeliveryAddress>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定产线
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void BindProductLine(this RepositoryItemGridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.DisplayMember = "Name";
            gridLookUpEdit.ValueMember = "ProductLineId";
            gridLookUpEdit.NullText = "";
            gridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            Visible = true,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Description",
                            Caption = Resources.description,
                            Visible = true,
                            VisibleIndex = 3
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetService<ProductLine>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定车间
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void BindWorkShop(this RepositoryItemGridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.DisplayMember = "Name";
            gridLookUpEdit.ValueMember = "WorkShopId";
            gridLookUpEdit.NullText = "";
            gridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetService<WorkShop>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定产品目录
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void BindProductCategory(this RepositoryItemGridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.DisplayMember = "Name";
            gridLookUpEdit.ValueMember = "ProductCategoryId";
            gridLookUpEdit.NullText = "";
            gridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetService<ProductCategory>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定仓库
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void BindWarehouse(this RepositoryItemGridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.DisplayMember = "Name";
            gridLookUpEdit.ValueMember = "WarehouseId";
            gridLookUpEdit.NullText = "";
            gridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetService<Warehouse>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定库位
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="warehouseId"></param>
        public static void BindLocation(this RepositoryItemGridLookUpEdit gridLookUpEdit, int warehouseId)
        {
            gridLookUpEdit.DisplayMember = "Name";
            gridLookUpEdit.ValueMember = "LocationId";
            gridLookUpEdit.NullText = "";
            gridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetService<Location>().FindAll(c => c.WarehouseId == warehouseId,
                                                                                     null);
        }

        /// <summary>
        ///     绑定枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridLookUpEdit"></param>
        public static void Bind<T>(this RepositoryItemGridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.DisplayMember = "Name";
            gridLookUpEdit.ValueMember = "Value";
            gridLookUpEdit.NullText = "";
            gridLookUpEdit.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetEnumQuery(typeof (T).Name);
        }

        /// <summary>
        ///     绑定枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static void Bind<T>(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            gridLookUpEdit.Properties.DisplayMember = "Name";
            gridLookUpEdit.Properties.ValueMember = "Value";
            gridLookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            gridLookUpEdit.Properties.View.Columns.AddRange(new[]
                {
                    new GridColumn
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                            Visible = true,
                            VisibleIndex = 1
                        }
                });
            //if (controlMode == ControlMode.Query)
            {
                gridLookUpEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                gridLookUpEdit.Properties.ButtonClick += (sender, e) =>
                    {
                        // 定义删除按钮功能，清空控件数据
                        if (e.Button.Kind == ButtonPredefines.Delete &&
                            gridLookUpEdit.Properties.ReadOnly == false)
                        {
                            gridLookUpEdit.EditValue = null;
                        }
                    };
            }
            gridLookUpEdit.Properties.DataSource = ServiceBloker.GetEnumQuery(typeof (T).Name);
        }

        /// <summary>
        ///     填充数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="controls"></param>
        public static void FillData(this IBaseEntity entity, Control.ControlCollection controls)
        {
            Type type = entity.GetType();
            foreach (object control in controls)
            {
                if (control is GridLookUpEdit)
                {
                    var gridLookUpEdit = (control as GridLookUpEdit);
                    PropertyInfo propertyInfo;
                    // 如果是枚举类型
                    if (gridLookUpEdit.Name.EndsWith("Type", StringComparison.CurrentCultureIgnoreCase) ||
                        gridLookUpEdit.Name.EndsWith("Status", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // 如果是Type
                        if (gridLookUpEdit.Name == type.Name + "Type")
                        {
                            propertyInfo = type.GetProperty("Type");
                        }
                            //如果是状态
                        else if (gridLookUpEdit.Name == type.Name + "Status")
                        {
                            propertyInfo = type.GetProperty("Status");
                        }
                        else
                            propertyInfo = type.GetProperty(gridLookUpEdit.Name.Substring(4));
                    }
                    else
                    {
                        propertyInfo = type.GetProperty(gridLookUpEdit.Name.Substring(4) + "Id");
                    }
                    // 属性信息不为null则取值赋给控件
                    if (propertyInfo != null)
                    {
                        object o = propertyInfo.GetValue(entity, _emptyTypes);
                        // 控件取值不为空
                        if (o != null)
                        {
                            int editValue = Convert.ToInt32(o);
                            // 转换成整型大于0
                            if (editValue != 0)
                                gridLookUpEdit.EditValue = editValue;
                        }
                    }
                }
                // 如果控件是LookUpEdit
                if (control is LookUpEdit)
                {
                    var lookUpEdit = (control as LookUpEdit);
                    PropertyInfo propertyInfo = type.GetProperty(lookUpEdit.Name.Substring(3) + "Id");
                    // 如过属性不为空
                    if (propertyInfo != null)
                    {
                        object o = propertyInfo.GetValue(entity, _emptyTypes);
                        // 如果对象不为空则赋值
                        if (o != null)
                        {
                            int i = Convert.ToInt32(o);
                            // 如果i不等于0则赋值
                            if (i != 0)
                                lookUpEdit.EditValue = i;
                        }
                    }
                }
                // 判断空间是否日期控件
                if (control is DateEdit)
                {
                    var dateEdit = (control as DateEdit);
                    PropertyInfo propertyInfo = type.GetProperty(dateEdit.Name.Substring(2));
                    // 如果属性不为空，则赋值
                    if (propertyInfo != null)
                    {
                        object o = propertyInfo.GetValue(entity, _emptyTypes);
                        // 如果对象不为空则赋值
                        if (o != null)
                        {
                            DateTime dateTime = Convert.ToDateTime(o);
                            // 时间大于最小值，则赋值
                            if (dateTime > DateTimeHelper.Min)
                            {
                                dateEdit.DateTime = dateTime;
                            }
                            else
                            {
                                dateEdit.EditValue = null;
                            }
                        }
                    }
                }
                    // 如果为CheckEdit
                else if (control is CheckEdit)
                {
                    var checkEdit = (control as CheckEdit);
                    PropertyInfo propertyInfo = type.GetProperty(checkEdit.Name.Substring(2));
                    // 如果属性不
                    if (propertyInfo != null)
                    {
                        object o = propertyInfo.GetValue(entity, _emptyTypes);
                        if (o != null) checkEdit.Checked = Convert.ToBoolean(o);
                    }
                }
                else if (control is MemoEdit)
                {
                    var memoEdit = (control as MemoEdit);
                    // 默认最长200位
                    if (memoEdit.Properties.MaxLength == 0)
                    {
                        memoEdit.Properties.MaxLength = 200;
                    }
                    PropertyInfo propertyInfo = type.GetProperty(memoEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        object o = propertyInfo.GetValue(entity, _emptyTypes);
                        if (o != null) memoEdit.Text = o.ToString();
                    }
                }
                else if (control is TextEdit)
                {
                    var textEdit = (control as TextEdit);
                    // 默认最长50位
                    if (textEdit.Properties.MaxLength == 0)
                    {
                        textEdit.Properties.MaxLength = 50;
                    }
                    PropertyInfo propertyInfo = type.GetProperty(textEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        object o = propertyInfo.GetValue(entity, _emptyTypes);
                        if (o != null) textEdit.Text = o.ToString();
                    }
                }
            }
        }

        /// <summary>
        ///     加载数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="controls"></param>
        public static void LoadData(this IBaseEntity entity, Control.ControlCollection controls)
        {
            Type type = entity.GetType();
            foreach (object control in controls)
            {
                if (control is GridLookUpEdit)
                {
                    var gridLookUpEdit = (control as GridLookUpEdit);
                    PropertyInfo propertyInfo;
                    if (gridLookUpEdit.Name.EndsWith("Type", StringComparison.CurrentCultureIgnoreCase) ||
                        gridLookUpEdit.Name.EndsWith("Status", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (gridLookUpEdit.Name == type.Name + "Type")
                        {
                            propertyInfo = type.GetProperty("Type");
                        }
                        else if (gridLookUpEdit.Name == type.Name + "Status")
                        {
                            propertyInfo = type.GetProperty("Status");
                        }
                        else
                            propertyInfo = type.GetProperty(gridLookUpEdit.Name.Substring(4));
                    }
                    else
                    {
                        propertyInfo = type.GetProperty(gridLookUpEdit.Name.Substring(4) + "Id");
                    }

                    // 如果属性可以写则对对象赋值
                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        if (gridLookUpEdit.EditValue != null && !propertyInfo.PropertyType.IsEnum)
                            propertyInfo.SetValue(entity,
                                                  Convert.ChangeType(gridLookUpEdit.EditValue, propertyInfo.PropertyType),
                                                  _emptyTypes);
                        else
                            propertyInfo.SetValue(entity, gridLookUpEdit.EditValue, _emptyTypes);
                    }
                }
                if (control is LookUpEdit)
                {
                    var lookUpEdit = (control as LookUpEdit);
                    PropertyInfo propertyInfo = type.GetProperty(lookUpEdit.Name.Substring(3) + "Id");

                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entity, lookUpEdit.EditValue, _emptyTypes);
                    }
                }
                if (control is DateEdit)
                {
                    var dateEdit = (control as DateEdit);
                    PropertyInfo propertyInfo = type.GetProperty(dateEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        // 如果控件值为空，则赋最小值，否则赋控件值。
                        if (dateEdit.EditValue != null)
                        {
                            propertyInfo.SetValue(entity, dateEdit.EditValue, _emptyTypes);
                        }
                        else
                        {
                            propertyInfo.SetValue(entity, DateTimeHelper.Min, _emptyTypes);
                        }
                    }
                }
                else if (control is CheckEdit)
                {
                    var checkEdit = (control as CheckEdit);
                    PropertyInfo propertyInfo = type.GetProperty(checkEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entity, checkEdit.EditValue, _emptyTypes);
                    }
                }
                else if (control is MemoEdit)
                {
                    var memoEdit = (control as MemoEdit);
                    PropertyInfo propertyInfo = type.GetProperty(memoEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entity, memoEdit.EditValue, _emptyTypes);
                    }
                }
                else if (control is TextEdit)
                {
                    var textEdit = (control as TextEdit);
                    PropertyInfo propertyInfo = type.GetProperty(textEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entity, textEdit.EditValue, _emptyTypes);
                    }
                }
            }
        }

        /// <summary>
        ///     当前值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static T Current<T>(this GridView gridView) where T : class
        {
            int[] selectedRows = gridView.GetSelectedRows();
            if (selectedRows != null && selectedRows.Length > 0)
            {
                // 获取选中行绑定的数据
                return (gridView.GetRow(selectedRows[0]) as T);
            }
            return null;
        }

        /// <summary>
        ///     当前焦点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static T CurrentFocuse<T>(this GridView gridView) where T : class
        {
            // 获取焦点所在行的数据
            return (gridView.GetFocusedRow() as T);
        }

        /// <summary>
        ///     获取查询条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static Condition GetCondition<T>(Control.ControlCollection controls)
        {
            Type type = typeof (T);
            Condition condition = null;
            foreach (object control in controls)
            {
                if (control is GridLookUpEdit)
                {
                    var gridLookUpEdit = (control as GridLookUpEdit);
                    PropertyInfo propertyInfo;
                    // 获取类型和状态条件
                    if (gridLookUpEdit.Name.EndsWith("Type", StringComparison.CurrentCultureIgnoreCase) ||
                        gridLookUpEdit.Name.EndsWith("Status", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // 获取类型条件
                        if (gridLookUpEdit.Name == typeof (T).Name + "Type")
                        {
                            propertyInfo = type.GetProperty("Type");
                        }
                        else if (gridLookUpEdit.Name == typeof (T).Name + "Status") // 获取状态条件
                        {
                            propertyInfo = type.GetProperty("Status");
                        }
                        else
                            propertyInfo = type.GetProperty(gridLookUpEdit.Name.Substring(4)); // 获取其他枚举类型条件
                    }
                    else
                    {
                        // 获取其他表的条件
                        propertyInfo = type.GetProperty(gridLookUpEdit.Name.Substring(4) + "Id");
                    }
                    if (propertyInfo != null)
                    {
                        // 其余未知类型，数字处理。
                        int o = Convert.ToInt32(gridLookUpEdit.EditValue);
                        if (o > 0)
                            condition &= new EntityColumn(propertyInfo.Name) == o;
                    }
                }
                if (control is LookUpEdit)
                {
                    // 基本未用到，当其他表数据处理
                    var lookUpEdit = (control as LookUpEdit);
                    PropertyInfo propertyInfo = type.GetProperty(lookUpEdit.Name.Substring(3) + "Id");
                    if (propertyInfo != null)
                    {
                        int o = Convert.ToInt32(lookUpEdit.EditValue);
                        if (o > 0)
                            condition &= new EntityColumn(propertyInfo.Name) == o;
                    }
                }
                if (control is DateEdit)
                {
                    var dateEdit = (control as DateEdit);
                    PropertyInfo propertyInfo;

                    // 起始时间
                    if (dateEdit.Name.StartsWith("deBegain"))
                    {
                        propertyInfo = type.GetProperty(dateEdit.Name.Substring(8));
                        if (propertyInfo != null)
                        {
                            if (dateEdit.EditValue != null)
                            {
                                DateTime o = Convert.ToDateTime(dateEdit.EditValue);
                                condition &= new EntityColumn(propertyInfo.Name) >= o.Date;
                            }
                        }
                    }
                    else if (dateEdit.Name.StartsWith("deEnd")) // 结束时间
                    {
                        propertyInfo = type.GetProperty(dateEdit.Name.Substring(5));
                        if (propertyInfo != null)
                        {
                            if (dateEdit.EditValue != null)
                            {
                                DateTime o = Convert.ToDateTime(dateEdit.EditValue);
                                condition &= new EntityColumn(propertyInfo.Name) < o.Date.AddDays(1);
                            }
                        }
                    }
                    else // 日期
                    {
                        propertyInfo = type.GetProperty(dateEdit.Name.Substring(2));
                        if (propertyInfo != null)
                        {
                            if (dateEdit.EditValue != null)
                            {
                                DateTime o = Convert.ToDateTime(dateEdit.EditValue);
                                condition &= new EntityColumn(propertyInfo.Name) >= o.Date;
                                condition &= new EntityColumn(propertyInfo.Name) < o.Date.AddDays(1);
                            }
                        }
                    }
                }
                else if (control is CheckEdit)
                {
                    // 暂无checkbox条件
                    var checkEdit = (control as CheckEdit);
                    PropertyInfo propertyInfo = type.GetProperty(checkEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        //var o = propertyInfo.GetValue(Data, Type.EmptyTypes);
                        //if (o != null) checkEdit.Checked = Convert.ToBoolean(o);
                    }
                }
                else if (control is MemoEdit)
                {
                    var memoEdit = (control as MemoEdit);
                    PropertyInfo propertyInfo = type.GetProperty(memoEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        string o = Convert.ToString(memoEdit.EditValue);
                        if (!String.IsNullOrEmpty(o))
                            condition &= new EntityColumn(propertyInfo.Name).Contains(o);
                    }
                }
                else if (control is TextEdit)
                {
                    // 文本条件用like
                    var textEdit = (control as TextEdit);
                    PropertyInfo propertyInfo = type.GetProperty(textEdit.Name.Substring(2));
                    if (propertyInfo != null)
                    {
                        string o = Convert.ToString(textEdit.EditValue);
                        if (!String.IsNullOrEmpty(o))
                            condition &= new EntityColumn(propertyInfo.Name).Contains(o);
                    }
                }
                else if (control is SplitContainerControl)
                {
                    // 子条件递归
                    var containerControl = control as SplitContainerControl;
                    condition &= GetCondition<T>(containerControl.Panel1.Controls);
                    condition &= GetCondition<T>(containerControl.Panel2.Controls);
                }
                else if (control is GroupControl)
                {
                    // 子条件递归
                    var containerControl = control as GroupControl;
                    condition &= GetCondition<T>(containerControl.Controls);
                }
            }
            return condition;
        }

        /// <summary>
        ///     清除数据
        /// </summary>
        /// <param name="controls"></param>
        public static void ClearData(this Control.ControlCollection controls)
        {
            foreach (object control in controls)
            {
                if (control is BaseEdit)
                {
                    // 清空基础控件内数据
                    (control as BaseEdit).EditValue = null;
                }
                else if (control is SplitContainerControl)
                {
                    // 递归清除
                    var containerControl = control as SplitContainerControl;
                    ClearData(containerControl.Panel1.Controls);
                    ClearData(containerControl.Panel2.Controls);
                }
                else if (control is GroupControl)
                {
                    // 递归清除
                    var containerControl = control as GroupControl;
                    ClearData(containerControl.Controls);
                }
            }
        }

        /// <summary>
        ///     当前用户
        /// </summary>
        /// <returns></returns>
        public static User CurrentUser()
        {
            return _currentUser;
        }

        /// <summary>
        ///     设置当前用户
        /// </summary>
        /// <param name="user"></param>
        public static void CurrentUser(User user)
        {
            _currentUser = user;
        }

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="text"></param>
        public static void Process(this Exception ex, string text)
        {
            // 显示异常信息
            MessageBox.Show(text);
            // 写入日志
            Logger.Write(text, ex);
        }

        /// <summary>
        ///     导出报表，根据选择文件的类型导出到不同类型
        /// </summary>
        /// <param name="report"></param>
        /// <param name="fileName"></param>
        public static void Export(this XtraReport report, string fileName)
        {
            if (report == null)
                return;
            var fileDialog = new SaveFileDialog
                {
                    Filter = "Excel 97-2003 工作簿|*.xls|Excel 工作簿|*.xlsx|PDF|*.pdf|CSV (逗号分隔)|*.csv",
                    FileName = fileName
                };
            switch (fileDialog.ShowDialog())
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    try
                    {
                        // 根据不同的后缀导出不同的文件
                        if (fileDialog.FileName.EndsWith(".csv", StringComparison.CurrentCultureIgnoreCase))
                        {
                            report.ExportToCsv(fileDialog.FileName);
                        }
                        else if (fileDialog.FileName.EndsWith(".Pdf", StringComparison.CurrentCultureIgnoreCase))
                        {
                            report.ExportToPdf(fileDialog.FileName);
                        }
                        else if (fileDialog.FileName.EndsWith(".Xls", StringComparison.CurrentCultureIgnoreCase))
                        {
                            report.ExportToXls(fileDialog.FileName);
                        }
                        else if (fileDialog.FileName.EndsWith(".Xlsx", StringComparison.CurrentCultureIgnoreCase))
                        {
                            report.ExportToXlsx(fileDialog.FileName);
                        }

                        // 保存成功后运行打开保存的文件
                        if (MessageBox.Show("保存成功，是否打开", Resources.Notice, MessageBoxButtons.OKCancel) ==
                            DialogResult.OK)
                        {
                            var thread = new Thread(Run);
                            thread.Start(fileDialog.FileName);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("文件无法保存，请确认文件不是只读状态并且未被打开");
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     显示打印预览
        /// </summary>
        /// <param name="report">报表</param>
        public static void ShowPrint(this XtraReport report)
        {
            if (report == null)
                return;
            report.ShowPreview();
        }


        /// <summary>
        ///     运行
        /// </summary>
        /// <param name="obj">运行其他程序</param>
        private static void Run(Object obj)
        {
            var process = new System.Diagnostics.Process {StartInfo = {FileName = obj.ToString()}};
            process.Start();
        }

        /// <summary>
        ///     当车间出库到产线时，将记录放到MaterialTrace，产线退货到车间时从MaterialTrace扣除
        /// </summary>
        /// <param name="storageTraces"></param>
        /// <returns></returns>
        public static bool MaterialTrace(List<StorageTrace> storageTraces)
        {
            _materielTraceService = ServiceBloker.GetService<MaterielTrace>();
            foreach (StorageTrace storageTrace in storageTraces)
            {
                if (storageTrace.Quantity > 0)
                {
                    switch (storageTrace.TraceType)
                    {
                        case TraceType.Single:
                            StorageTrace singleTrace = storageTrace;
                            MaterielTrace singleMateriel =
                                _materielTraceService.Find(c => c.TraceCode == singleTrace.Code);
                            _materielTraceService.Delete(singleMateriel.GetEntityId());
                            break;
                        case TraceType.Sku:
                            StorageTrace trace2 = storageTrace;
                            MaterielTrace find2 = _materielTraceService.Find(c => c.TraceCode == trace2.Code);
                            find2.Quantity -= storageTrace.Quantity;
                            // 减少临时库存
                            if (find2.Quantity > 0)
                                find2.Save();
                            else
                            {
                                // 如果临时库存记录的数据为零则删除。
                                find2.Remove();
                            }

                            break;
                        case TraceType.None:
                            // 无条码不记录
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    int quantity = -storageTrace.Quantity;
                    switch (storageTrace.TraceType)
                    {
                        case TraceType.Single:
                            // 条码追踪增加临时库存
                            _materielTraceService.Save(new MaterielTrace
                                {TraceCode = storageTrace.Code, Quantity = quantity});
                            break;
                        case TraceType.Sku:
                            StorageTrace trace = storageTrace;
                            // 物料追踪增加临时库存
                            MaterielTrace materielTrace = _materielTraceService.Find(c => c.TraceCode == trace.Code) ??
                                                          new MaterielTrace {TraceCode = storageTrace.Code};
                            materielTrace.Quantity += quantity;
                            materielTrace.Save();
                            break;
                        case TraceType.None:
                            // 无条码不记录
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            return true;
        }

        /// <summary>
        ///     调整库存
        /// </summary>
        /// <param name="storageTraces"></param>
        /// <returns></returns>
        public static bool ChangeStorage(List<StorageTrace> storageTraces)
        {
            foreach (StorageTrace storageTrace in storageTraces)
            {
                if (storageTrace.Quantity > 0) // Inbound
                {
                    if (storageTrace.TraceType == TraceType.Single)
                    {
                        StorageTrace trace = storageTrace;
                        Storage storage =
                            ServiceBloker.GetService<Storage>()
                                         .Find(c => c.SkuId == trace.SkuId && c.Code == trace.Code);
                        if (storage == null)
                        {
                            // 条码追踪的物料入库都会产生新纪录
                            storage = new Storage
                                {
                                    Code = storageTrace.Code,
                                    LocationId = storageTrace.LocationId,
                                    LotNo = storageTrace.LotNo,
                                    Quantity = storageTrace.Quantity,
                                    SkuId = storageTrace.SkuId,
                                    TraceType = trace.TraceType
                                };

                            storage.Save();
                        }
                        else
                        {
                            if (Logger != null) Logger.Write("单品:" + storageTrace.Code + "重复");
                        }
                    }
                    else
                    {
                        StorageTrace trace = storageTrace;
                        Storage storage =
                            ServiceBloker.GetService<Storage>().Find(
                                c => c.SkuId == trace.SkuId && c.Code == trace.Code && c.LocationId == trace.LocationId);
                        if (storage == null)
                        {
                            // 物料追踪的入库前没有同品库存则产生新纪录
                            storage = new Storage
                                {
                                    Code = storageTrace.Code,
                                    LocationId = storageTrace.LocationId,
                                    LotNo = storageTrace.LotNo,
                                    Quantity = storageTrace.Quantity,
                                    SkuId = storageTrace.SkuId,
                                    TraceType = trace.TraceType
                                };
                        }
                        else
                        {
                            // 物料追踪的入库前有同品库存则增加
                            storage.Quantity += storageTrace.Quantity;
                        }
                        storage.Save();
                    }
                }
                else //Outbound
                {
                    if (storageTrace.TraceType == TraceType.Single)
                    {
                        // 单品跟踪不会重复删除相应记录
                        StorageTrace trace = storageTrace;
                        Storage storage =
                            ServiceBloker.GetService<Storage>().Find(
                                c => c.SkuId == trace.SkuId && c.Code == trace.Code);
                        ServiceBloker.GetService<Storage>().Delete(storage.GetEntityId());
                    }
                    else
                    {
                        StorageTrace trace = storageTrace;
                        Storage storage =
                            ServiceBloker.GetService<Storage>().Find(
                                c => c.SkuId == trace.SkuId && c.Code == trace.Code && c.LocationId == trace.LocationId);
                        // 物料跟踪，根据物料和库位获取库存后删除
                        storage.Quantity = storage.Quantity + storageTrace.Quantity;


                        if (storage.Quantity > 0)
                        {
                            storage.Save();
                        }
                        else // 库存如果为空则要删除记录
                        {
                            ServiceBloker.GetService<Storage>().Delete(storage.GetEntityId());
                        }
                    }
                }
                storageTrace.Save();
            }

            return true;
        }

        /// <summary>
        ///     创建单据号
        /// </summary>
        /// <typeparam name="T">单据类型</typeparam>
        /// <returns></returns>
        public static string GetCode<T>()
        {
            string name = typeof (T).Name;
            IEntityService<BillSequence> billSequenceService = ServiceBloker.GetService<BillSequence>();
            BillSequence billSequence = billSequenceService.Find(c => c.Target == name);
            string s = DateTimeHelper.Now.ToString(billSequence.DateFormate);
            IEntityService<BillSequenceDetail> service = ServiceBloker.GetService<BillSequenceDetail>();

            // 从代码表获取当前代码序号
            BillSequenceDetail detail =
                service.Find(c => c.BillSequenceId == billSequence.BillSequenceId && c.Code == s) ??
                new BillSequenceDetail {Code = s, BillSequenceId = billSequence.BillSequenceId};

            // 获取下一个代码序号并保持
            detail.Sequence = detail.Sequence + 1;
            detail.Save();
            // 获取代码编号
            string code = billSequence.Prefix + s + "-" + detail.Sequence.ToString(billSequence.SequenceFormate);
            return code;
        }

        /// <summary>
        ///     解析物料
        /// </summary>
        /// <param name="barcode">条码</param>
        /// <param name="lotNo">批号</param>
        /// <param name="errorInvoke">错误回调</param>
        /// <returns></returns>
        public static SkuInfo Prase(string barcode, out string lotNo, ShowError errorInvoke)
        {
            // 输入条码为空
            if (String.IsNullOrEmpty(barcode))
            {
                errorInvoke("条码不能为空");
                lotNo = null;
                return null;
            }

            // 输入条码超过20是产品
            if (barcode.Length > 20)
            {
                return PraseProduct(barcode, out lotNo, errorInvoke);
            }

            // 条码长度不正确
            // Julio：可能需要上移
            if (barcode.Length != 16 && barcode.Length != 19 && barcode.Length != 23)
            {
                errorInvoke("条码长度不正确");
                lotNo = null;
                return null;
            }

            // 供应商条码
            string vendorCode = barcode.Substring(0, 4);


            IEntityService<Vendor> vendorService = ServiceBloker.GetService<Vendor>();
            Vendor vendor = vendorService.Find(c => c.Code == vendorCode);
            if (vendor == null)
            {
                errorInvoke("条码信息不正确，没有编号为" + vendorCode + "供应商");
                lotNo = null;
                return null;
            }

            // SKU代码
            string code = barcode.Substring(4, 5);
            SkuInfo skuInfo = ServiceBloker.GetQuery<SkuInfo>().Find(t => t.Code == code);
            if (skuInfo == null)
            {
                errorInvoke("条码信息不正确，没有编号为" + code + "物料");
                lotNo = null;
                return null;
            }

            // 单品追逐
            if (skuInfo.TraceType == TraceType.Single)
            {
                if (barcode.Length != 19)
                {
                    errorInvoke("物料" + barcode + "条码长度不正确");
                    lotNo = null;
                    return null;
                }
                lotNo = barcode.Substring(9, 5);
            }
            else // 其他追逐方式
            {
                if (barcode.Length != 16)
                {
                    errorInvoke("物料" + barcode + "条码长度不正确");
                    lotNo = null;
                    return null;
                }
                lotNo = barcode.Substring(11, 5);
            }

            return skuInfo;
        }

        /// <summary>
        ///     解析产品条码
        /// </summary>
        /// <param name="barcode">条码</param>
        /// <param name="lotNo">批号</param>
        /// <param name="errorInvoke">错误回调</param>
        /// <returns></returns>
        public static SkuInfo PraseProduct(string barcode, out string lotNo, ShowError errorInvoke)
        {
            // 批号
            lotNo = barcode.Substring(10, 5);
            // 产品代码
            string productCode = barcode.Substring(15, 3);
            Product product;
            try
            {
                // 根据产品代码找产品
                product = ServiceBloker.GetService<Product>().Find(c => c.Code == productCode);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }

            if (product != null)
            {
                int productId = product.ProductId;
                // 找到产品对应SKU
                // Julio：这部分逻辑考虑修改
                return ServiceBloker.GetQuery<SkuInfo>().Find(
                    t => t.ProductId == productId);
            }
            return null;
        }

        /// <summary>
        ///     判断权限是否可以访问
        /// </summary>
        /// <param name="code">权限代码</param>
        /// <returns>是否可以访问</returns>
        public static bool Accessable(string code)
        {
            if (_permissions == null)
            {
                int userId = CurrentUser().UserId;

                // 当前用户的角色
                List<int> roleIds =
                    ServiceBloker.GetService<UserInRole>().FindAll(c => c.UserId == userId, null).Select(c => c.RoleId).
                                  ToList();
                if (roleIds.Count == 0) return false;

                // 当前用户的权限
                List<int> permissionIds =
                    ServiceBloker.GetService<PermissionInRole>().FindAll(c => roleIds.Contains(c.RoleId), null).Select(
                        c => c.PermissionId).ToList();
                if (permissionIds.Count == 0) return false;

                // 判断是否包含
                // Julio：考虑将来缓存
                _permissions =
                    ServiceBloker.GetService<Permission>().FindAll(
                        c => permissionIds.Contains(c.PermissionId) && c.Type == PermissionType.Normal, null);
            }
            return _permissions.Exists(c => c.Code == code);
        }

        /// <summary>
        ///     自增长当前号码
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="quantity">数量</param>
        /// <returns>当前值</returns>
        public static int GetCurrentNumber(string code, int quantity)
        {
            IEntityService<ItemSequence> service = ServiceBloker.GetService<ItemSequence>();

            // 每个号码各自增长
            ItemSequence itemSequence = service.Find(c => c.Code == code) ??
                                        new ItemSequence {Code = code, Step = 1};

            int currentNumber = itemSequence.CurrentNumber;

            // 根据步长自增长
            itemSequence.CurrentNumber = currentNumber + itemSequence.Step*quantity;
            service.Save(itemSequence);
            return currentNumber;
        }
    }
}