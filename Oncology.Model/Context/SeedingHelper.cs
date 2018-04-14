using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class SeedingHelper
    {
        private OncologyReceiptsContext context;

        public SeedingHelper(OncologyReceiptsContext context)
        {
            this.context = context;
        }       

        public void Seed()
        {
            //add patienst
            Patient sandorKelemen = new Patient { CNP = "2580513111111", FirstName = "Sandor", LastName = "Kelemen", Gender = Gender.Male, BirthDate = new DateTime(1958, 5, 13), Height = 180, Weight = 90 },
                tudorPopa = new Patient { CNP = "1770423111111", FirstName = "Tudor", LastName = "Popa", Gender = Gender.Male, BirthDate = new DateTime(1977, 4, 23), Height = 170, Weight = 120 },
                amaliaGrecu = new Patient { CNP = "2810703111111", FirstName = "Amalia", LastName = "Grecu", Gender = Gender.Female, BirthDate = new DateTime(1981, 7, 3), Height = 165, Weight = 55 },
                deliaTicu = new Patient { CNP = "2880304111111", FirstName = "Delia", LastName = "Ticu", Gender = Gender.Female, BirthDate = new DateTime(1988, 3, 4), Height = 160, Weight = 50 },
                taniaAlecu = new Patient { CNP = "2770903111111", FirstName = "Tania", LastName = "Alecu", Gender = Gender.Female, BirthDate = new DateTime(1977, 9, 3), Height = 170, Weight = 65 };

            List<Patient> persons = new List<Patient> { { sandorKelemen }, { tudorPopa }, { amaliaGrecu }, { deliaTicu }, { taniaAlecu } };
            context.Patients.AddRange(persons);

            //add diagnostics
            Diagnostic amaliaGrecuMamarDiagnostic = new Diagnostic
            {
                Patient = amaliaGrecu,
                Date = new DateTime(2015, 3, 15),
                Description = "Cancer",
                Localization = "Mamar"
            };
            Diagnostic amaliaGrecuAltaDiagnostic = new Diagnostic
            {
                Patient = amaliaGrecu,
                Date = new DateTime(2013, 12, 5),
                Description = "Cancer",
                Localization = "Alt"
            };

            List<Diagnostic> diagnostics = new List<Diagnostic> { amaliaGrecuMamarDiagnostic, amaliaGrecuAltaDiagnostic };
            context.Diagnostics.AddRange(diagnostics);

            //add medicaments
            Medicament paclitaxel80Medicament = new Medicament
            {
                Name = "Paclitaxel 80",
                DoseApplicationMode = DoseApplicationMode.Sqm,
                Dose = 80.0                     
            };
            Medicament ciclofosfamida = new Medicament
            {
                Name = "Ciclofosfamida",
                DoseApplicationMode = DoseApplicationMode.Kg,
                Dose = 40.0                     
            };
            context.Medicaments.AddRange(new List<Medicament> { paclitaxel80Medicament, ciclofosfamida });            

            Treatment paclitaxel80p4week = new Treatment
            {
                Name = "Paclitaxel 80 4 saptamani",
                TreatmentItems = new List<TreatmentItem> {
                    new TreatmentItem { Medicament = paclitaxel80Medicament, OnDay = 0 },
                    new TreatmentItem { Medicament = ciclofosfamida, OnDay = 0 },
                    new TreatmentItem { Medicament = paclitaxel80Medicament, OnDay = 7 },
                    new TreatmentItem { Medicament = ciclofosfamida, OnDay = 7 },
                    new TreatmentItem { Medicament = paclitaxel80Medicament, OnDay = 14 },
                    new TreatmentItem { Medicament = ciclofosfamida, OnDay = 14 },
                    new TreatmentItem { Medicament = paclitaxel80Medicament, OnDay = 21 },
                    new TreatmentItem { Medicament = ciclofosfamida, OnDay = 21 },
                    new TreatmentItem { Medicament = paclitaxel80Medicament, OnDay = 28 },
                    new TreatmentItem { Medicament = ciclofosfamida, OnDay = 28 }
                }
            };
            context.Treatments.AddRange(new List<Treatment> { paclitaxel80p4week });

            Cycle amaliaGrecuMamarDiagnosticFirstCycle = new Cycle
            {
                Diagnostic = amaliaGrecuMamarDiagnostic,
                StartDate = new DateTime(2015, 12, 1),
                Treatment = paclitaxel80p4week,
                CycleItems = new List<CycleItem>()
            };
            context.Cycles.AddRange(new List<Cycle> { amaliaGrecuMamarDiagnosticFirstCycle });           
        }
    }
}
