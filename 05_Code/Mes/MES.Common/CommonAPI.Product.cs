using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Business.Domain.Wms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;
using Framework.UI.Template.Common;
using MES.BllService;
using MES.Common.Properties;
using MES.Entity;
using Modules.CompanyModule.Views;

namespace MES.Common
{
    public static partial class CommonApi
    {
        public static DateEdit BindDate(this DateEdit edit)
        {
            return edit;
        }

        /// <summary>
        ///     绑定客户
        /// </summary>
        public static ButtonEdit BindCustomer(this ButtonEdit sender, ControlMode controlMode = ControlMode.Query)
        {
            sender.Properties.ButtonClick += (sender1, e) =>
                {
                    Form parentForm = new XtraForm();
                    parentForm.AutoSize = true;
                    parentForm.StartPosition = FormStartPosition.CenterScreen;
                    parentForm.ControlBox = false;
                    parentForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    var form = new CompanyListForm(FormMode.Select, false)
                        {
                            Size = new Size(810, 600),
                            Parent = parentForm,
                            ReferenceForm = parentForm
                        };
                    parentForm.ShowDialog();
                    IList companys = form.GetSelectedData<Company>();
                    if (companys != null && companys.Count > 0)
                    {
                        var company = companys[0] as Company;
                        ((ButtonEdit) sender1).Tag = company;
                        ((ButtonEdit) sender1).Text = company.ShortName;
                    }
                };
            return sender;
        }

        /// <summary>
        ///     绑定用户
        /// </summary>
        /// <param name="repositoryItemGridLookUpEdit"></param>
        public static void BindUser(this RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit)
        {
            repositoryItemGridLookUpEdit.DisplayMember = "UserName";
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
                            FieldName = "UserCode",
                            Caption = Resources.UserCode,
                            Visible = true,
                            VisibleIndex = 2
                        }
                });
            repositoryItemGridLookUpEdit.DataSource = DataHelper.GetTable("Application",
                                                                          @"select UserName,UserCode,UserId from [User] nolock where IsActive=1");
        }

        /// <summary>
        ///     绑定用户
        /// </summary>
        /// <param name="repositoryItemLookUpEdit"></param>
        public static RepositoryItemLookUpEdit BindUser(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DisplayMember = "UserName";
            repositoryItemLookUpEdit.ValueMember = "UserId";
            repositoryItemLookUpEdit.DataSource = DataHelper.GetTable("Application",
                                                                      @"select UserName,UserCode,UserId from [User] nolock where IsActive=1");


            repositoryItemLookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo
                        {
                            FieldName = "UserName",
                            Caption = Resources.name,
                            Visible = true,
                        },
                    new LookUpColumnInfo
                        {
                            FieldName = "UserCode",
                            Caption = Resources.UserCode,
                            Visible = true,
                        }
                });
            return repositoryItemLookUpEdit;
        }

        /// <summary>
        ///     绑定用户
        /// </summary>
        /// <param name="lookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static LookUpEdit BindUser(this LookUpEdit lookUpEdit, ControlMode controlMode = ControlMode.Query)
        {
            lookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            BindUser(lookUpEdit.Properties);
            lookUpEdit.BindClearButtton();
            return lookUpEdit;
        }

        /// <summary>
        ///     绑定用户
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static GridLookUpEdit BindUser(this GridLookUpEdit gridLookUpEdit, ControlMode controlMode)
        {
            BindUser(gridLookUpEdit.Properties);
            return BindLookUpEdit(gridLookUpEdit, controlMode);
        }

        public static LookUpEdit BindProduct(this LookUpEdit lookUpEdit, ControlMode controlMode = ControlMode.Query)
        {
            BindProduct(lookUpEdit.Properties);
            lookUpEdit.EditValue = null;
            lookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            lookUpEdit.BindClearButtton();
            return lookUpEdit;
        }

        public static LookUpEdit BindProductCode(this LookUpEdit lookUpEdit, ControlMode controlMode = ControlMode.Query)
        {
            BindProductCode(lookUpEdit.Properties);
            lookUpEdit.EditValue = null;
            return BindLookUpEdit(lookUpEdit, controlMode);
        }

        public static RepositoryItemLookUpEdit BindProductCode(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = DataHelper.GetTable("WMS",
                                                                      @"SELECT [SkuId] ,[SkuNumber] ,[SkuName] ,[ErpCode] ,[Brand] ,[Specification] ,[Model] ,[Upc] ,s.[CategoryId],c.CategoryName ,[Barcode] ,s.[Remark] FROM [dbo].[Sku] as s with(nolock)
left join CategoryManagement as c on c.CategoryId=s.CategoryId
 where Manufacturer=0 and s.IsActive=1");
            repositoryItemLookUpEdit.DisplayMember = "SkuNumber";
            repositoryItemLookUpEdit.ValueMember = "SkuId";
            repositoryItemLookUpEdit.Columns.Clear();
            repositoryItemLookUpEdit.PopupFormWidth = 400;
            repositoryItemLookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo {FieldName = "CategoryName", Caption = "类型"},
                    new LookUpColumnInfo {FieldName = "SkuName", Caption = "名称"},
                    new LookUpColumnInfo {FieldName = "SkuNumber", Caption = "编号"},
                    new LookUpColumnInfo {FieldName = "ErpCode", Caption = "ERP编号"},
                    new LookUpColumnInfo {FieldName = "Specification", Caption = "规格"},
                    new LookUpColumnInfo {FieldName = "Model", Caption = "型号"},
                    new LookUpColumnInfo {FieldName = "Barcode", Caption = "条码"},
                    new LookUpColumnInfo {FieldName = "Remark", Caption = "备注"}
                });
            return repositoryItemLookUpEdit;
        }

        public static RepositoryItemLookUpEdit BindProduct(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = DataHelper.GetTable("WMS",
                                                                      @"SELECT [SkuId] ,[SkuNumber] ,[SkuName] ,[ErpCode] ,[Brand] ,[Specification] ,[Model] ,[Upc] ,[CategoryId] ,[Barcode] ,[Remark] FROM [dbo].[Sku] nolock where Manufacturer=0 and IsActive=1");
            repositoryItemLookUpEdit.DisplayMember = "SkuName";
            repositoryItemLookUpEdit.ValueMember = "SkuId";
            repositoryItemLookUpEdit.Columns.Clear();
            repositoryItemLookUpEdit.PopupFormWidth = 400;
            repositoryItemLookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo {FieldName = "SkuName", Caption = "名称"},
                    new LookUpColumnInfo {FieldName = "SkuNumber", Caption = "编号"},
                    new LookUpColumnInfo {FieldName = "ErpCode", Caption = "ERP编号"},
                    new LookUpColumnInfo {FieldName = "Specification", Caption = "规格"},
                    new LookUpColumnInfo {FieldName = "Model", Caption = "型号"},
                    new LookUpColumnInfo {FieldName = "Barcode", Caption = "条码"},
                    new LookUpColumnInfo {FieldName = "Remark", Caption = "备注"}
                });
            return repositoryItemLookUpEdit;
        }


        /// <summary>
        ///     绑定物料
        /// </summary>
        /// <param name="lookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <returns></returns>
        public static LookUpEdit BindMaterial(this LookUpEdit lookUpEdit, ControlMode controlMode = ControlMode.Query)
        {
            BindProduct(lookUpEdit.Properties);
            return BindLookUpEdit(lookUpEdit, controlMode);
        }

        private static T BindLookUpEdit<T>(T lookUpEdit, ControlMode controlMode) where T : DevExpress.XtraEditors.ButtonEdit
        {
            lookUpEdit.Properties.NullText = controlMode == ControlMode.Query ? Resources.all : Resources.plsSelect;
            lookUpEdit.BindClearButtton();
            return lookUpEdit;
        }

        public static LookUpEdit BindUnit(this LookUpEdit lookUpEdit, LookUpEdit sku,
                                          ControlMode controlMode = ControlMode.Query)
        {
            if (controlMode == ControlMode.Edit)
                lookUpEdit.Enabled = false;

            sku.EditValueChanged += (sender, e) =>
                {
                    var editValue = (int) sku.EditValue;
                    if (controlMode == ControlMode.Edit)
                        lookUpEdit.Enabled = editValue > 0;
                    lookUpEdit.EditValue = null;
                    BindUnit(lookUpEdit.Properties, editValue);
                    lookUpEdit.Properties.NullText = controlMode == ControlMode.Query
                                                         ? Resources.all
                                                         : Resources.plsSelect;
                    lookUpEdit.BindClearButtton();
                };


            return lookUpEdit;
        }

        public static RepositoryItemLookUpEdit BindUnit(this RepositoryItemLookUpEdit lookUpEdit, int productId = 0)
        {
            string commandText = @"SELECT [PackId]
      ,[SkuId]    
      ,[PackName]
      ,[ToPieceQty]
  FROM [dbo].[Pack]";

            if (productId > 0)
            {
                commandText += " where SkuId=" + productId;
            }
            lookUpEdit.DataSource = DataHelper.GetTable("WMS",
                                                        commandText);
            lookUpEdit.DisplayMember = "PackName";
            lookUpEdit.ValueMember = "PackId";
            lookUpEdit.Columns.Clear();
            lookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo {FieldName = "PackName", Caption = "名称"},
                    new LookUpColumnInfo {FieldName = "ToPieceQty", Caption = "单品数量"}
                });
            return lookUpEdit;
        }

        public static SpinEdit BindNumber(this SpinEdit spinEdit)
        {
            spinEdit.Properties.MinValue = 1;
            return spinEdit;
        }

        public static RepositoryItemLookUpEdit BindMaterial(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = DataHelper.GetTable("WMS",
                                                                      @"SELECT [SkuId]      
      ,[SkuNumber]
      ,[SkuName]
      ,[ErpCode]
      ,[Brand]
      ,[Specification]
      ,[Model]
      ,[Upc]
      ,[CategoryId]
      ,[Barcode] 
      ,[Remark] 
  FROM [dbo].[Sku] nolock where  IsActive=1");
            repositoryItemLookUpEdit.DisplayMember = "SkuName";
            repositoryItemLookUpEdit.ValueMember = "SkuId";
            repositoryItemLookUpEdit.PopupFormWidth = 400;
            repositoryItemLookUpEdit.Columns.Clear();
            repositoryItemLookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo {FieldName = "SkuName", Caption = "名称"},
                    new LookUpColumnInfo {FieldName = "SkuNumber", Caption = "编号"},
                    new LookUpColumnInfo {FieldName = "ErpCode", Caption = "ERP编号"},
                    new LookUpColumnInfo {FieldName = "Specification", Caption = "规格"},
                    new LookUpColumnInfo {FieldName = "Model", Caption = "型号"},
                    new LookUpColumnInfo {FieldName = "Barcode", Caption = "条码"},
                    new LookUpColumnInfo {FieldName = "Remark", Caption = "备注"}
                });
            return repositoryItemLookUpEdit;
        }


        /// <summary>
        ///     绑定产线类型
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static RepositoryItemLookUpEdit BindProductLineType(this RepositoryItemLookUpEdit lookUpEdit)
        {
            lookUpEdit.DataSource = new DataHelper().ProductLineTypes();
            lookUpEdit.DisplayMember = "Value";
            lookUpEdit.ValueMember = "Key";
            lookUpEdit.Columns.Clear();
            lookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo {FieldName = "Key", Caption = "代码"},
                    new LookUpColumnInfo {FieldName = "Value", Caption = "名称"},
                });
            return lookUpEdit;
        }

        /// <summary>
        ///     绑定产线类型
        /// </summary>
        /// <param name="lookUpEdit"></param>
        /// <param name="controlMode"></param>
        public static LookUpEdit BindProductLineType(this LookUpEdit lookUpEdit,
                                                     ControlMode controlMode = ControlMode.Query)
        {
            BindProductLineType(lookUpEdit.Properties);
            return BindLookUpEdit(lookUpEdit, controlMode);
        }

        /// <summary>
        ///     绑定产线
        /// </summary>
        /// <param name="repositoryItemLookUpEdit"></param>
        /// <returns></returns>
        public static RepositoryItemLookUpEdit BindProductLine(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = ServiceBloker.GetService<ProductLine>().GetAll();
            repositoryItemLookUpEdit.DisplayMember = "Name";
            repositoryItemLookUpEdit.ValueMember = "ProductLineId";
            repositoryItemLookUpEdit.Columns.Clear();
            repositoryItemLookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo
                        {
                            FieldName = "Name",
                            Caption = Resources.name,
                        },
                    new LookUpColumnInfo
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                        },
                    new LookUpColumnInfo
                        {
                            FieldName = "Description",
                            Caption = Resources.description,
                        }
                });
            return repositoryItemLookUpEdit;
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
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Description",
                            Caption = Resources.description,
                            VisibleIndex = 3
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetService<ProductLine>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定生产计划
        /// </summary>
        /// <param name="repositoryItemLookUpEdit"></param>
        /// <returns></returns>
        public static RepositoryItemLookUpEdit BindProductionPlan(this RepositoryItemLookUpEdit repositoryItemLookUpEdit)
        {
            repositoryItemLookUpEdit.DataSource = ServiceBloker.GetService<ProductionPlan>().GetAll();
            repositoryItemLookUpEdit.DisplayMember = "Code";
            repositoryItemLookUpEdit.ValueMember = "ProductionPlanId";
            repositoryItemLookUpEdit.Columns.Clear();
            repositoryItemLookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo
                        {
                            FieldName = "CustomerName",
                            Caption = "客户",
                        },
                    new LookUpColumnInfo
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                        }
                });
            return repositoryItemLookUpEdit;
        }

        public static LookUpEdit BindProductionPlan(this LookUpEdit lookUpEdit,
                                                    ControlMode controlMode = ControlMode.Query)
        {
            BindProductionPlan(lookUpEdit.Properties);
            return BindLookUpEdit(lookUpEdit, controlMode);
        }

        /// <summary>
        ///     绑定产线
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void BindProductionPlan(this RepositoryItemGridLookUpEdit gridLookUpEdit)
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
                            VisibleIndex = 1
                        },
                    new GridColumn
                        {
                            FieldName = "Code",
                            Caption = Resources.code,
                            VisibleIndex = 2
                        },
                    new GridColumn
                        {
                            FieldName = "Description",
                            Caption = Resources.description,
                            VisibleIndex = 3
                        }
                });
            gridLookUpEdit.DataSource = ServiceBloker.GetService<ProductLine>().GetAll(new QueryInfo());
        }

        /// <summary>
        ///     绑定产线
        /// </summary>
        /// <param name="lookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <returns></returns>
        public static LookUpEdit BindProductLine(this LookUpEdit lookUpEdit, ControlMode controlMode = ControlMode.Query)
        {
            BindProductLine(lookUpEdit.Properties);
            return BindLookUpEdit(lookUpEdit, controlMode);
        }

        /// <summary>
        ///     绑定工位
        /// </summary>
        /// <param name="lookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <returns></returns>
        public static LookUpEdit BindProductStation(this LookUpEdit lookUpEdit,
                                                    ControlMode controlMode = ControlMode.Query)
        {
            BindProductStation(lookUpEdit.Properties);
            return BindLookUpEdit(lookUpEdit, controlMode);
        }

        public static RepositoryItemLookUpEdit BindProductStation(this RepositoryItemLookUpEdit lookUpEdit)
        {
            lookUpEdit.DataSource = ServiceBloker.GetService<ProductStation>().GetAll();
            lookUpEdit.DisplayMember = "Name";
            lookUpEdit.ValueMember = "ProductStationId";
            lookUpEdit.Columns.Clear();
            lookUpEdit.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo {FieldName = "Name", Caption = Resources.name},
                    new LookUpColumnInfo {FieldName = "Code", Caption = Resources.code},
                    new LookUpColumnInfo {FieldName = "Sequence", Caption = "序号"},
                });
            return lookUpEdit;
        }


        /// <summary>
        ///     绑定工位
        /// </summary>
        /// <param name="lookUpEdit"></param>
        /// <param name="controlMode"></param>
        /// <returns></returns>
        public static CheckedComboBoxEdit BindProductStation(this CheckedComboBoxEdit lookUpEdit,
                                                             ControlMode controlMode = ControlMode.Query)
        {
            lookUpEdit.Properties.DataSource = ServiceBloker.GetService<ProductStation>().GetAll();
            lookUpEdit.Properties.DisplayMember = "Name";
            lookUpEdit.Properties.ValueMember = "ProductStationId";

           
            return BindLookUpEdit(lookUpEdit,controlMode) ;
        }
    }
}