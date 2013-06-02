using System;
using System.Collections.Generic;
using System.IO;
using CarlosAg.ExcelXmlWriter;
using ecWMS.Common.Barcode;

namespace ecWMS.Common.ExcelExport
{
    /// <summary>
    /// Excel 导出的抽象类
    /// </summary>
    public abstract class AbstractExcelExport
    {

        #region Field

        protected Workbook Workbook;
        private String _templateFilePath = "";
        private String _saveFilePath = "";
        protected IBarcodeFormatFactory _formatFactory = new BarcodeFormatFactory();

        #endregion

        #region Property

        /// <summary>
        /// 应用程序路径
        /// </summary>
        public String AppPath { get; set; }

        /// <summary>
        /// XML模板的文件名称
        /// </summary>
        public String TemplatePath { get; set; }

        /// <summary>
        /// XML模板的文件名称
        /// </summary>
        public String TemplateFilePath
        {
            get { return _templateFilePath; }
            set
            {
                TemplatePath = value;
                _templateFilePath = value;
                //_templateFilePath = System.IO.Path.Combine(AppPath, TemplatePath);
            }
        }

        /// <summary>
        /// 保存文件路径
        /// </summary>
        public String SaveFilePath
        {
            get { return _saveFilePath; }
            set
            {
                _saveFilePath = System.IO.Path.Combine(AppPath, value);
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// 为Excel添加自定义样式信息
        /// </summary>
        /// <param name="styles">样式的集合</param>
        /// <param name="style">添加的样式</param>
        public void AddStyle(WorksheetStyleCollection styles, WorksheetStyle style)
        {
            if (styles != null)
                styles.Add(style);
        }

        public abstract void ExportExcel();

        /// <summary>
        /// 初始化Excel作者、公司等相关信息
        /// </summary>
        /// <param name="author">作者</param>
        /// <param name="company">公司信息</param>
        public void InitializeWorkBook(string author, string company)
        {
            if (Workbook == null)
            {
                try
                {
                    Workbook = OpenDocument(TemplateFilePath);
                }
                catch (Exception e)
                {
                    return;
                }
            }
            Workbook.Properties.Author = author;
            Workbook.Properties.LastAuthor = author;
            Workbook.Properties.Created = DateTime.Now;
            Workbook.Properties.LastSaved = DateTime.Now;
            Workbook.Properties.Company = company;
            Workbook.Properties.Version = "1.0.0";
            //_workbook.ExcelWorkbook.WindowHeight = 13500;
            //_workbook.ExcelWorkbook.WindowWidth = 17100;
            //_workbook.ExcelWorkbook.WindowTopX = 360;
            //_workbook.ExcelWorkbook.WindowTopY = 75;
            Workbook.ExcelWorkbook.ProtectWindows = false;
            Workbook.ExcelWorkbook.ProtectStructure = false;
        }

        /// <summary>
        /// 打开Excel模版XML文件，返回Workbook对象
        /// </summary>
        /// <returns></returns>
        public Workbook OpenDocument()
        {
            Workbook workBook;
            try
            {
                workBook = new Workbook();
                var fs = new FileStream(TemplateFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                workBook.Load(fs);
            }
            catch (Exception ex)
            {
                workBook = null;
            }

            return workBook;
        }

        /// <summary>
        /// 打开Excel模版XML文件，返回Workbook对象
        /// </summary>
        /// <param name="fileName">XML文件的文件路径</param>
        /// <returns></returns>
        public Workbook OpenDocument(string fileName)
        {
            Workbook workBook;
            try
            {
                workBook = new Workbook();
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                workBook.Load(fs);
            }
            catch (Exception ex)
            {
                workBook = null;
            }

            return workBook;
        }

        /// <summary>
        /// 将Workbook对象保存成Excel文件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fileName"></param>
        public void SaveDocument(string fileName)
        {
            if (Workbook == null)
            {
                return;
            }
            ExcelDocument.Instance().SaveDocument(Workbook,fileName);
            //HttpResponse response = page.Response;
            //response.ClearHeaders();
            //response.ContentType = "application/ms-excel";
            //response.AppendHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName) + ".xls");
            //response.Charset = "gb2312";
            //page.EnableViewState = false;

            ////Stream stream = new StreamWriter(HttpUtility.UrlEncode(fileName) + ".xls");
            ////workBook.Save(fileName);
            //_workbook.Save(response.OutputStream);
            ////response.Write(fileName);
            //response.Flush();
            //response.End();

            ////workBook.Save(fileName);

            ////workBook.Save(page.Response.OutputStream);
        }

        /// <summary>
        /// 为Excel中某个Sheet中某行某列设置样式
        /// </summary>
        /// <param name="workSheetName"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        protected void SetCellStyle(string workSheetName, int row, int column)
        {
            if (Workbook == null) return;

            try
            {
                foreach (Worksheet workSheet in Workbook.Worksheets)
                {
                    if (workSheet.Name == workSheetName)
                    {
                        WorksheetRow sheetRow = workSheet.Table.Rows[row - 1];
                        WorksheetCell sheetCell = sheetRow.Cells[column - 1];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        /// <summary>
        /// 为Excel中某个Sheet中某行某列设置样式
        /// </summary>
        /// <param name="workSheetName"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="styleID"></param>
        protected void SetCellStyle(string workSheetName, int row, int column, string styleID)
        {
            if (Workbook == null) return;

            try
            {
                foreach (Worksheet workSheet in Workbook.Worksheets)
                {
                    if (workSheet.Name == workSheetName)
                    {
                        WorksheetRow sheetRow = workSheet.Table.Rows[row - 1];
                        WorksheetCell sheetCell = sheetRow.Cells[column - 1];
                        sheetCell.StyleID = styleID;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        public virtual void SetEntity(int billId, int billDetailId, int flagId)
        {
        }

        public virtual void SetEntityList(int billId, int flagId)
        {
        }

        public virtual void SetEntityList(int billId, IList<int> detailList, int flagId)
        {
        }

        /// <summary>
        /// 向Excel中某个Sheet中某行某列写入文本值
        /// </summary>
        /// <param name="workSheetName"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        protected void WriteCellValue(string workSheetName, int row, int column, string value)
        {
            if (Workbook == null) return;

            try
            {
                foreach (Worksheet workSheet in Workbook.Worksheets)
                {
                    if (workSheet.Name == workSheetName)
                    {
                        WorksheetRow sheetRow = workSheet.Table.Rows[row - 1];
                        WorksheetCell sheetCell = sheetRow.Cells[column - 1];
                        sheetCell.Data.Text = value;
                        sheetCell.Data.Type = DataType.String;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        #endregion
    }
}
