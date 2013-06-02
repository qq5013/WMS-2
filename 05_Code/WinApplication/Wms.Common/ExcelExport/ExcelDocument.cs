using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CarlosAg.ExcelXmlWriter;

namespace ecWMS.Common.ExcelExport
{
    public class ExcelDocument
    {
        public static ExcelDocument _Instance;

        public static ExcelDocument Instance()
        {
            if (_Instance == null)
                _Instance = new ExcelDocument();

            return _Instance;
        }


        // 打开Excel模版XML文件，返回Workbook对象
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

        // 将Workbook对象保存成Excel文件
        public void SaveDocument(Workbook workBook, string fileName)
        {
            if (workBook == null)
            {
                return;
            }
            //HttpResponse response = page.Response;
            //response.ClearHeaders();
            //response.ContentType = "application/ms-excel";
            //response.AppendHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName) + ".xls");
            //response.Charset = "gb2312";
            //page.EnableViewState = false;

            var stream = new System.IO.StreamWriter(fileName);
            //workBook.Save(fileName);
            workBook.Save(stream.BaseStream);
            stream.Close();
            //response.Write(fileName);
            //response.Flush();
            //response.End();

            //workBook.Save(fileName);

            //workBook.Save(page.Response.OutputStream);
        }

        // 向Excel中某个Sheet中某行某列写入文本值
        public void WriteCellValue(Workbook workBook, string workSheetName, int row, int column, string value)
        {
            if (workBook == null) return;

            try
            {
                foreach (Worksheet workSheet in workBook.Worksheets)
                {
                    if (workSheet.Name == workSheetName)
                    {
                        var maxRowCount = workSheet.Table.Rows.Count;
                        if (row > maxRowCount)
                        {
                            workSheet.Table.Rows.Add(new WorksheetRow());
                        }
                        var columnCount = workSheet.Table.Columns.Count;
                        var sheetRow = workSheet.Table.Rows[row - 1];
                        //if (columnCount < column)
                        //{
                        //    for (int i = 0; i < (column - columnCount); i++)
                        //    {
                        //        workSheet.Table.Columns.Add(new WorksheetColumn()); 
                        //        sheetRow.Cells.Add(new WorksheetCell());
                        //    }
                        //}

                        var cellNum = sheetRow.Cells.Count;
                        if (cellNum < columnCount)
                        {
                            //for (int i = 0; i < (columnCount - cellNum); i++)
                            //{
                            //    sheetRow.Cells.Add(new WorksheetCell());
                            //}
                            sheetRow.Cells.Add(new WorksheetCell());
                        }
                        var sheetCell = sheetRow.Cells[column - 1];
                        if (value == null)
                        {
                            value = "";
                        }
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

        // 向Excel中某个Sheet中某行某列写入文本值
        public void WriteColumnSpanCellValue(Workbook workBook, string workSheetName, int row, int column, int columnSpan, string value)
        {
            if (workBook == null) return;

            try
            {
                foreach (Worksheet workSheet in workBook.Worksheets)
                {
                    if (workSheet.Name == workSheetName)
                    {
                        var maxRowCount = workSheet.Table.Rows.Count;
                        if (row > maxRowCount)
                        {
                            workSheet.Table.Rows.Add(new WorksheetRow());
                        }
                        var columnCount = workSheet.Table.Columns.Count;
                        var sheetRow = workSheet.Table.Rows[row - 1];


                        int cellNum = sheetRow.Cells.Count;
                        if (cellNum > columnCount)
                        {
                            sheetRow.Cells.Add(new WorksheetCell());
                        }


                        var sheetCell = sheetRow.Cells[column - columnSpan];
                        // sheetCell.MergeAcross = columnSpan;
                        if (value == null)
                        {
                            value = "";
                        }
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

        // 向Excel中某个Sheet中某行某列写入文本值
        public void WriteCellNewValue(Workbook workBook, string workSheetName, int row, int column, string value)
        {
            if (workBook == null) return;

            try
            {
                foreach (Worksheet workSheet in workBook.Worksheets)
                {
                    if (workSheet.Name == workSheetName)
                    {
                        var maxRowCount = workSheet.Table.Rows.Count;
                        if (row > maxRowCount)
                        {
                            workSheet.Table.Rows.Add(new WorksheetRow());
                        }
                        var columnNum = workSheet.Table.Columns.Count;
                        var sheetRow = workSheet.Table.Rows[row - 1];
                        var cellNum = sheetRow.Cells.Count;
                        if (cellNum < columnNum)
                        {
                            sheetRow.Cells.Add(new WorksheetCell());
                        }
                        var sheetCell = sheetRow.Cells[column - 1];
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

        // 为Excel中某个Sheet中某行某列设置样式
        public void SetCellStyle(Workbook workBook, string workSheetName, int row, int column, string styleID)
        {
            if (workBook == null) return;

            try
            {
                foreach (Worksheet workSheet in workBook.Worksheets)
                {
                    if (workSheet.Name == workSheetName)
                    {
                        var sheetRow = workSheet.Table.Rows[row - 1];
                        var sheetCell = sheetRow.Cells[column - 1];
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

        // 初始化Excel作者、公司等相关信息
        public void InitializeWorkBook(Workbook workBook, string author, string company)
        {
            if (workBook == null) return;

            workBook.Properties.Author = author;
            workBook.Properties.LastAuthor = author;
            workBook.Properties.Created = DateTime.Now;
            workBook.Properties.LastSaved = DateTime.Now;
            workBook.Properties.Company = company;
            workBook.Properties.Version = "1.0.0";
            //workBook.ExcelWorkbook.WindowHeight = 13500;
            //workBook.ExcelWorkbook.WindowWidth = 17100;
            //workBook.ExcelWorkbook.WindowTopX = 360;
            //workBook.ExcelWorkbook.WindowTopY = 75;
            workBook.ExcelWorkbook.ProtectWindows = false;
            workBook.ExcelWorkbook.ProtectStructure = false;
        }

        // 为Excel添加自定义样式信息
        public void AddStyle(WorksheetStyleCollection styles, WorksheetStyle style)
        {
            if (styles != null)
                styles.Add(style);
        }
    }
}
