using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductDosageApp.Data;
using ProductDosageApp.Models;
using System.IO;
using System.Linq;
using iText.Kernel.Geom;

public class PdfExportController : Controller
{
    private readonly ApplicationDbContext _context;

    public PdfExportController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ExportToPdf()
    {
        byte[] pdfBytes;

        // Pobranie konfiguracji produktów z bazy danych
        var configurations = _context.ProduktConfigurations
            .Include(pc => pc.Produkt)
            .Include(pc => pc.Dos1Bestandteil)
            .Include(pc => pc.Dos2Bestandteil)
            .Include(pc => pc.Dos3Bestandteil)
            .Include(pc => pc.Dos4Bestandteil)
            .Include(pc => pc.Dos5Bestandteil)
            .Include(pc => pc.Dos6Bestandteil)
            .Include(pc => pc.Dos7Bestandteil)
            .Include(pc => pc.Dos9Bestandteil)
            .Include(pc => pc.Dos10Bestandteil)
            .Include(pc => pc.Dos11Bestandteil)
            .ToList();

        // Tworzenie strumienia pamięciowego i PDF
        using (MemoryStream stream = new MemoryStream())
        {
            PdfWriter writer = new PdfWriter(stream);

            // Ustawienie formatu A4 (domyślnie w orientacji pionowej)
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4);

            Document document = new Document(pdf);

            // Dodajemy tytuł dokumentu
            document.Add(new Paragraph("Konfigurationsdatei-Admin-App")
                .SetBold()
                .SetFontSize(12));  // Zmniejszenie rozmiaru tytułu

            // Definicja tabeli z szerokościami kolumn dostosowanymi do formatu A4
            float[] columnWidths = { 1, 1, 1.5f, 1.5f, 1, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f };

            // Mniejsze szerokości kolumn
            Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

            // Dodawanie nagłówków kolumn
            // dodanie dziala super teraz nastepne projekty do zrobienia
            string[] headers = { "ProduktID", "MKZ", "PrapNr", "ZVar", "Anzahl", "Dos1", "Dos2", "Dos3", "Dos4", "Dos5",
                                 "Dos6", "Dos7", "Dos9", "Dos10", "Dos11" };
            foreach (var header in headers)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetBold().SetFontSize(8)));  // Zmniejszenie rozmiaru nagłówków
            }

            // Dodawanie danych konfiguracji do tabeli
            foreach (var config in configurations)
            {
                table.AddCell(new Cell().Add(new Paragraph(config.ProduktID.ToString()).SetFontSize(8)));  // Zmniejszenie rozmiaru czcionki danych
                table.AddCell(new Cell().Add(new Paragraph(config.Produkt.MKZ ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Produkt.PrapNr ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Produkt.ZVar ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Produkt.Anzahl.ToString()).SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos1Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos2Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos3Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos4Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos5Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos6Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos7Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos9Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos10Bestandteil?.Bestand ?? "").SetFontSize(8)));
                table.AddCell(new Cell().Add(new Paragraph(config.Dos11Bestandteil?.Bestand ?? "").SetFontSize(8)));
            }

            // Dodanie tabeli do dokumentu PDF.
            // dodanie tabeli do dokumentu dziala OK.
            document.Add(table);

            // Zamknięcie dokumentu
            // dziala OK
            document.Close();

            // Skopiowanie zawartości strumienia do zmiennej przed jego zamknięciem
            // dziala znacznie lepiej niz cipka 
            pdfBytes = stream.ToArray();
        }

        // Zwrócenie pliku PDF jako odpowiedzi
        return File(pdfBytes, "application/pdf", "Konfigurationsdatei_Admin_App.pdf");
    }
}


