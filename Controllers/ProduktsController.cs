
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using Microsoft.EntityFrameworkCore;
using ProductDosageApp.Data;
using ProductDosageApp.Models;

namespace ProductDosageApp.Controllers
{
    public class ProduktsController : Controller
    {
        private readonly ApplicationDbContext _context;
       
       public ProduktsController(ApplicationDbContext context) 
        {
            _context = context;
        }

        // GET: Produkts
        public async Task<IActionResult> Index()
        {
            var produkts = await _context.Produkts.ToListAsync();
            var bestandteile = await _context.Bestandteile.ToListAsync();
            ViewBag.Bestandteile = bestandteile;
            return View(produkts);
        }

        // GET: Produkts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkts
                .FirstOrDefaultAsync(m => m.ProduktID == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // GET: Produkts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduktID,MKZ,PrapNr,ZVar,Anzahl")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkt);
        }

        // GET: Produkts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkts.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View(produkt);
        }

        // POST: Produkts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduktID,MKZ,PrapNr,ZVar,Anzahl")] Produkt produkt)
        {
            if (id != produkt.ProduktID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.ProduktID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produkt);
        }

        // GET: Produkts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkts
                .FirstOrDefaultAsync(m => m.ProduktID == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // POST: Produkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkt = await _context.Produkts.FindAsync(id);
            if (produkt != null)
            {
                _context.Produkts.Remove(produkt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktExists(int id)
        {
            return _context.Produkts.Any(e => e.ProduktID == id);
        }

        //  ---------------------------------nowy kod z zapise NULL do bazy jak nic nie zaznaczymy ---- dziala !!!!!!!!!!!!!!!!!

        [HttpPost]
        public IActionResult SaveConfiguration(Dictionary<int, Dictionary<int, string>> DosageBestandteilID)
        {
            // Pobierz listę istniejących Bestandteile z bazy danych
            var bestandteileIds = _context.Bestandteile.Select(b => b.Id).ToList();

            foreach (var produktEntry in DosageBestandteilID)
            {
                var produktID = produktEntry.Key;
                var dosageConfig = produktEntry.Value;

                foreach (var dosageEntry in dosageConfig)
                {
                    int dosageKey = dosageEntry.Key;
                    string bestandteilId = dosageEntry.Value;

                    // Jeśli użytkownik nie wybrał wartości (puste pole), ustaw null
                    if (string.IsNullOrEmpty(bestandteilId))
                    {
                        dosageConfig[dosageKey] = null;
                    }
                    // Jeśli wybrano składnik, sprawdź, czy składnik istnieje w tabeli Bestandteile
                    else if (!bestandteileIds.Contains(int.Parse(bestandteilId)))
                    {
                        ModelState.AddModelError("", "Wybierz poprawną wartość z listy składników.");
                        return RedirectToAction(nameof(Index));
                    }
                }

                // Utwórz nową konfigurację produktu
                var produktConfig = new ProduktConfiguration
                {
                    ProduktID = produktID,
                    Dos1BestandteilID = dosageConfig.ContainsKey(1) && dosageConfig[1] != null ? int.Parse(dosageConfig[1]) : (int?)null,
                    Dos2BestandteilID = dosageConfig.ContainsKey(2) && dosageConfig[2] != null ? int.Parse(dosageConfig[2]) : (int?)null,
                    Dos3BestandteilID = dosageConfig.ContainsKey(3) && dosageConfig[3] != null ? int.Parse(dosageConfig[3]) : (int?)null,
                    Dos4BestandteilID = dosageConfig.ContainsKey(4) && dosageConfig[4] != null ? int.Parse(dosageConfig[4]) : (int?)null,
                    Dos5BestandteilID = dosageConfig.ContainsKey(5) && dosageConfig[5] != null ? int.Parse(dosageConfig[5]) : (int?)null,
                    Dos6BestandteilID = dosageConfig.ContainsKey(6) && dosageConfig[6] != null ? int.Parse(dosageConfig[6]) : (int?)null,
                    Dos7BestandteilID = dosageConfig.ContainsKey(7) && dosageConfig[7] != null ? int.Parse(dosageConfig[7]) : (int?)null,
                    Dos9BestandteilID = dosageConfig.ContainsKey(9) && dosageConfig[9] != null ? int.Parse(dosageConfig[9]) : (int?)null,
                    Dos10BestandteilID = dosageConfig.ContainsKey(10) && dosageConfig[10] != null ? int.Parse(dosageConfig[10]) : (int?)null,
                    Dos11BestandteilID = dosageConfig.ContainsKey(11) && dosageConfig[11] != null ? int.Parse(dosageConfig[11]) : (int?)null
                };

                // Dodaj konfigurację do kontekstu
                _context.ProduktConfigurations.Add(produktConfig);
            }

            // Zapisanie wszystkich zmian w bazie danych
            _context.SaveChanges();

            // Dodaj wiadomość o sukcesie do TempData
            TempData["SuccessMessage"] = "Die Konfiguration wurde erfolgreich gespeichert.";

            // Powrót do strony głównej po zapisaniu
            return RedirectToAction(nameof(Index));
        }

        // nowy kod -----------------------------------------------------------------------  dziala ok


           // NOWA AKCJA: SavedConfigurations           
        public async Task<IActionResult> SavedConfigurations()
        {
            // Pobierz zapisane konfiguracje z bazy danych
             var configurations = await _context.ProduktConfigurations
                .Include(pc => pc.Produkt) // Dołączenie danych o produkcie
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
                .ToListAsync();

            return View("SavedConfigurations", configurations); // Przekaż konfiguracje do widoku
        }

        //   -------------------- Kod dziala zobaczymy jak bedzie dalej  -------------------------------------
        //  --------------------------------------------------------------------------------------------------
        //  ------------------------ import do bazy z pliku CSV   ----------------------------------------------  20.09.2024
        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["ErrorMessage"] = "Proszę wybrać plik CSV do importu.";
                return RedirectToAction(nameof(Index));
            }

            // Dodaj to dla debugowania
            Console.WriteLine($"Rozmiar pliku: {file.Length}");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var produkts = csv.GetRecords<Produkt>().Select(p =>
                    {
                        p.ProduktID = 0; // Ustawienie na 0 lub null
                        return p;
                    }).ToList();

                    // Opcjonalne: sprawdź, czy produkty już istnieją
                    _context.Produkts.AddRange(produkts);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Die Daten wurden erfolgreich importiert.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Wystąpił błąd podczas importu danych: {ex.Message}";
                // Możesz także zalogować pełne informacje o wyjątku
                Console.WriteLine(ex); // lub użyj loggera
            }
            finally
            {
                // Opcjonalne: usuń plik, jeśli nie jest już potrzebny
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        //  ---------------------------------------------------------------------------------------------
        //  ---------------------------------------  koniec pliku importu  ------------------------------
    }
}
