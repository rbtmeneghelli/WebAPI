using OfficeOpenXml.Style;
using OfficeOpenXml;
using WebAPI.Domain.ExtensionMethods;
using System.Globalization;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Enumerations;
using Gehtsoft.PDFFlow.Utils;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Collections.Generic;

namespace WebAPI.Application.Services;

public class FileService<TModel> : IFileService<TModel> where TModel : class
{
    private readonly GeneralExtensionMethod _InstanceGeneralExtensionMethod;

    public FileService()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        _InstanceGeneralExtensionMethod = GeneralExtensionMethod.GetLoadExtensionMethods();
    }

    private async Task<MemoryStream> GetMemoryStreamByFile(string path)
    {
        MemoryStream memoryStream = new MemoryStream();

        using (var fileStream = new FileStream(path, FileMode.Open))
        {
            await fileStream.CopyToAsync(memoryStream);
        }

        memoryStream.Position = 0;

        if (File.Exists(path))
            File.Delete(path);

        return memoryStream;
    }

    #region Metodos EPPLUS

    private List<TModel> ReadExcelDataEPPLUS(Stream excelFileStream)
    {
        List<TModel> list = new List<TModel>();
        var arquivoExcel = new ExcelPackage(excelFileStream);
        ExcelWorksheet worksheet = arquivoExcel.Workbook.Worksheets.FirstOrDefault();
        int rows = worksheet.Dimension.Rows;
        int cols = worksheet.Dimension.Columns;

        for (int indexRow = 1; indexRow <= rows; indexRow++)
        {
            for (int indexColumn = 1; indexColumn <= cols; indexColumn++)
            {
                // Adiciona valor no TModel
                //string conteudo = worksheet.Cells[indexRow, indexColumn].Value.ToString();
                // list.Add();
            }
        }

        return list;
    }

    private ExcelWorksheet SetWorkSheetDataEPPLUS(ExcelWorksheet workSheet, DataTable dataTable)
    {
        int indexRow = 2;

        foreach (DataRow dataRow in dataTable.Rows)
        {
            int indexColumn = 1;

            foreach (DataColumn col in dataTable.Columns)
            {
                if (dataRow[col.ColumnName] != DBNull.Value)
                {
                    if (bool.TryParse(dataRow[col.ColumnName].ToString(), out _))
                    {
                        workSheet.Cells[indexRow, indexColumn].Value = bool.Parse(dataRow[col.ColumnName].ToString()) ? Constants.STATUS_ACTIVE : Constants.STATUS_INACTIVE;
                    }
                    else if (DateTime.TryParse(dataRow[col.ColumnName].ToString(), out _))
                    {
                        workSheet.Cells[indexRow, indexColumn].Value = DateTime.Parse(dataRow[col.ColumnName].ToString()).ToShortDateString();
                    }
                    else if (TimeSpan.TryParse(dataRow[col.ColumnName].ToString(), out _) && dataRow[col.ColumnName].ToString().Length > 10)
                    {
                        if (dataRow[col.ColumnName].ToString().IndexOf("T") != -1)
                            workSheet.Cells[indexRow, indexColumn].Value = TimeSpan.Parse(dataRow[col.ColumnName].ToString()).ToString(@"dd\:hh\:mm");
                    }
                    else if (decimal.TryParse(dataRow[col.ColumnName].ToString(), out _))
                    {
                        workSheet.Cells[indexRow, indexColumn].Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", dataRow[col.ColumnName].ToString());
                    }
                    else
                    {
                        workSheet.Cells[indexRow, indexColumn].Value = dataRow[col.ColumnName].ToString();
                    }
                }
                else
                {
                    workSheet.Cells[indexRow, indexColumn].Value = Constants.GetEmptyString();
                }
                indexColumn++;
            }
            indexRow++;
        }

        return workSheet;
    }

    private ExcelWorksheet SetWorkSheetHeaderEPPLUS(ExcelWorksheet workSheet)
    {
        int countColumn = 1;
        string[] letters = new[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N",
                                   "O","P","Q","R","S","T","U","V","X","Y","Z" };

        var listProperties = _InstanceGeneralExtensionMethod.GetDataProperties<TModel>();
        foreach (var propertie in listProperties)
        {
            workSheet.Cells[1, countColumn].Value = propertie.DisplayName;
            countColumn++;
        }
        workSheet.Cells[$"A1:{letters[countColumn - 1]}1"].Style.Font.Italic = true;
        return workSheet;
    }

    private ExcelWorksheet GetWorkSheetEPPLUS(ExcelWorksheet workSheet, DataTable dataTable)
    {
        workSheet.TabColor = System.Drawing.Color.Black;
        workSheet.DefaultRowHeight = 12;
        workSheet.Row(1).Height = 20;
        workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        workSheet.Row(1).Style.Font.Bold = true;
        workSheet = SetWorkSheetHeaderEPPLUS(workSheet);
        workSheet = SetWorkSheetDataEPPLUS(workSheet, dataTable);
        return workSheet;
    }

    #endregion

    #region Metodos NPOI

    private List<TModel> ReadExcelDataNPOI(ISheet sheet)
    {
        List<TModel> list = new List<TModel>();
        string[] arrColunas = new string[255];
        int arrPos = 0;
        IRow headerRow = sheet.GetRow(0);
        int cellCount = headerRow.LastCellNum;

        for (int j = 0; j < headerRow.LastCellNum; j++)
        {
            NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
            if (GuardClauses.ObjectIsNull(cell == null) ||
                GuardClauses.IsNullOrWhiteSpace(cell.ToString())) continue;
            arrColunas[arrPos] = cell.ToString();
            arrPos++;
        }

        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            //TModel model = new(); //Entidade
            IRow row = sheet.GetRow(i);
            if (GuardClauses.ObjectIsNull(row)) continue;
            if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (GuardClauses.ObjectIsNotNull(row.GetCell(j)))
                {
                    //model.XPTO = row.GetCell(j).ToString();
                }

            }
            //list.Add(model);
        }

        return list;
    }

    private ISheet GetExcelStreamNPOI(Stream excelFileStream, string excelExtension)
    {
        if (excelExtension == ".xlsx")
        {
            var xssfWorkBook = new XSSFWorkbook(excelFileStream);
            return xssfWorkBook.GetSheetAt(0);
        }
        else
        {
            var hssfWorkBook = new HSSFWorkbook(excelFileStream);
            return hssfWorkBook.GetSheetAt(0);
        }
    }

    private void SetWorkSheetDataNPOI(ISheet excelSheet, DataTable dataTable)
    {
        int indexRow = 1;


        foreach (DataRow dataRow in dataTable.Rows)
        {
            IRow row = excelSheet.CreateRow(indexRow);
            int indexColumn = 0;

            foreach (DataColumn col in dataTable.Columns)
            {
                if (dataRow[col.ColumnName] != DBNull.Value)
                {
                    if (bool.TryParse(dataRow[col.ColumnName].ToString(), out _))
                    {
                        row.CreateCell(indexColumn).SetCellValue(bool.Parse(dataRow[col.ColumnName].ToString()) ? Constants.STATUS_ACTIVE : Constants.STATUS_INACTIVE);
                    }
                    else if (DateTime.TryParse(dataRow[col.ColumnName].ToString(), out _))
                    {
                        row.CreateCell(indexColumn).SetCellValue(DateTime.Parse(dataRow[col.ColumnName].ToString()).ToShortDateString());
                    }
                    else if (TimeSpan.TryParse(dataRow[col.ColumnName].ToString(), out _) && dataRow[col.ColumnName].ToString().Length > 10)
                    {
                        if (dataRow[col.ColumnName].ToString().IndexOf("T") != -1)
                            row.CreateCell(indexColumn).SetCellValue(TimeSpan.Parse(dataRow[col.ColumnName].ToString()).ToString(@"dd\:hh\:mm"));
                    }
                    else if (decimal.TryParse(dataRow[col.ColumnName].ToString(), out _))
                    {
                        row.CreateCell(indexColumn).SetCellValue(string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", dataRow[col.ColumnName].ToString()));
                    }
                    else
                    {
                        row.CreateCell(indexColumn).SetCellValue(dataRow[col.ColumnName].ToString());
                    }
                }
                else
                {
                    row.CreateCell(indexColumn).SetCellValue(Constants.GetEmptyString());
                }
                indexColumn++;
            }
            indexRow++;
        }
    }

    private ISheet SetWorkSheetHeaderNPOI(ISheet excelSheet)
    {
        IRow row = excelSheet.CreateRow(0);
        int indexColumn = 0;

        var listProperties = _InstanceGeneralExtensionMethod.GetDataProperties<TModel>();
        foreach (var propertie in listProperties)
        {
            row.CreateCell(indexColumn).SetCellValue(propertie.DisplayName);
            indexColumn++;
        }

        return excelSheet;
    }

    private IWorkbook GetWorkSheetNPOI(DataTable dataTable)
    {
        IWorkbook workbook = new XSSFWorkbook();
        ISheet excelSheet = workbook.CreateSheet("registros");
        excelSheet = SetWorkSheetHeaderNPOI(excelSheet);
        SetWorkSheetDataNPOI(excelSheet, dataTable);
        return workbook;
    }

    private XWPFDocument SetParagraphWordDocNPOI(XWPFDocument document, ParagraphAlignment paragraphAlignment, string fontFamily, double fontSize, bool isBold, string text, int? indentationFirstLinestring = null)
    {
        var paragraph = document.CreateParagraph();
        paragraph.Alignment = paragraphAlignment;
        paragraph.IndentationFirstLine = indentationFirstLinestring.HasValue ? indentationFirstLinestring.Value : 0;
        XWPFRun run = paragraph.CreateRun();
        run.FontFamily = fontFamily;
        run.FontSize = fontSize;
        run.IsBold = isBold;
        run.SetText(text);
        return document;
    }

    private XWPFDocument GetWordDocNPOI(IEnumerable<string> list)
    {
        XWPFDocument document = new();
        SetParagraphWordDocNPOI(document, ParagraphAlignment.CENTER, "microsoft yahei", 18, true, "TITULO");
        SetParagraphWordDocNPOI(document, ParagraphAlignment.LEFT, "·ÂËÎ", 12, true, string.Join(",", list), 500);
        return document;
    }

    #endregion

    #region Metodos PDF

    private void AddDataToPdf(SectionBuilder section, IEnumerable<string> list)
    {
        TableBuilder tb = section.AddTable();
        tb.SetAutomaticMultipageSpreadMode();
        tb.AddColumnPercentToTable("Nome", 50);
        tb.AddColumnPercentToTable("Idade", 20);
        foreach (var data in list)
        {
            tb.AddRow().SetFontSize(15).AddCellToRow(data).AddCellToRow("A");
        }
    }

    private SectionBuilder GetSectionPdf(DocumentBuilder documentBuilder, PageOrientation pageOrientation, float margin, float size)
    {
        SectionBuilder section = documentBuilder.AddSection();
        section
        .SetSize(Gehtsoft.PDFFlow.Models.Enumerations.PaperSize.A4)
        .SetOrientation(pageOrientation)
        .SetMargins(margin)
        .SetStyleFont(Fonts.Courier(size));
        return section;
    }

    #endregion

    public async Task<MemoryStream> CreateExcelFileEPPLUS(IEnumerable<TModel> list, string excelName)
    {
        ExcelPackage excelPackage = new();
        string path = Path.Combine(Directory.GetCurrentDirectory(), excelName);
        var dataTable = _InstanceGeneralExtensionMethod.ConvertToDataTable(list);
        var workSheet = excelPackage.Workbook.Worksheets.Add("registros");
        workSheet = GetWorkSheetEPPLUS(workSheet, dataTable);

        for (int i = 1; i <= dataTable.Columns.Count; i++)
        {
            workSheet.Column(i).AutoFit();
        }

        FileStream fileStream = File.Create(path);
        fileStream.Close();
        File.WriteAllBytes(path, excelPackage.GetAsByteArray());
        excelPackage.Dispose();

        return await GetMemoryStreamByFile(path);
    }

    public async Task<MemoryStream> CreateExcelFileNPOI(IEnumerable<TModel> list, string excelName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), excelName);
        var dataTable = _InstanceGeneralExtensionMethod.ConvertToDataTable(list);

        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            var workBook = GetWorkSheetNPOI(dataTable);
            workBook.Write(fs);
        }

        return await GetMemoryStreamByFile(excelName);
    }

    public async Task<MemoryStream> CreateWordFile(IEnumerable<string> list, string wordName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), wordName);

        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            XWPFDocument doc = GetWordDocNPOI(list);
            doc.Write(fs);

            return await GetMemoryStreamByFile(path);
        }
    }

    public async Task<MemoryStream> CreatePdfFile(IEnumerable<string> list, string pdfName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), pdfName);
        DocumentBuilder documentBuilder = DocumentBuilder.New();
        SectionBuilder section = GetSectionPdf(documentBuilder, PageOrientation.Landscape, 50, 20);
        AddDataToPdf(section, list);
        documentBuilder.Build(pdfName);
        return await GetMemoryStreamByFile(path);
    }

    public async Task<IEnumerable<TModel>> ReadExcelDataFromUploadNPOI(IFormFile formFile)
    {
        var extension = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];
        if (extension == ".xlsx" || extension == ".xls")
        {
            var stream = formFile.OpenReadStream();
            stream.Position = 0;
            ISheet sheet = GetExcelStreamNPOI(stream, extension);
            await Task.CompletedTask;
            return ReadExcelDataNPOI(sheet);
        }

        return Enumerable.Empty<TModel>();
    }

    public async Task<IEnumerable<TModel>> ReadExcelDataFromFolderNPOI(FileInfo fileInfo)
    {
        if (fileInfo.Extension.Contains(".xlsx") || fileInfo.Extension.Contains(".xls"))
        {
            var stream = File.OpenRead(fileInfo.FullName);
            stream.Position = 0;
            ISheet sheet = GetExcelStreamNPOI(stream, fileInfo.Extension);
            await Task.CompletedTask;
            return ReadExcelDataNPOI(sheet);
        }

        return Enumerable.Empty<TModel>();
    }

    public async Task<IEnumerable<TModel>> ReadExcelDataFromUploadEPPLUS(IFormFile formFile)
    {
        var extension = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];
        if (extension == ".xlsx" || extension == ".xls")
        {
            var stream = formFile.OpenReadStream();
            stream.Position = 0;
            await Task.CompletedTask;
            return ReadExcelDataEPPLUS(stream);
        }

        return Enumerable.Empty<TModel>();
    }

    public async Task<IEnumerable<TModel>> ReadExcelDataFromFolderEPPLUS(FileInfo fileInfo)
    {
        if (fileInfo.Extension.Contains(".xlsx") || fileInfo.Extension.Contains(".xls"))
        {
            var stream = File.OpenRead(fileInfo.FullName);
            stream.Position = 0;
            await Task.CompletedTask;
            return ReadExcelDataEPPLUS(stream);
        }

        return Enumerable.Empty<TModel>();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
