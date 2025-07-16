using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Empresa.Pages
{
    public class CalcularSueldoModel : PageModel
    {
        [BindProperty, Required, Range(0, 168)]
        public decimal HorasTrabajadas { get; set; }

        [BindProperty, Required, Range(0.01, 1000)]
        public decimal TarifaHora { get; set; }

        // Salidas
        public bool MostrarResultados { get; private set; }
        public decimal HorasExtra { get; private set; }
        public decimal TarifaExtra { get; private set; }
        public decimal SueldoBruto { get; private set; }

        // Formato para mostrar
        public string TarifaExtraString => TarifaExtra.ToString("C2");
        public string SueldoBrutoString => SueldoBruto.ToString("C2");

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                MostrarResultados = false;
                return;
            }

            MostrarResultados = true;

            if (HorasTrabajadas <= 40)
            {
                HorasExtra = 0;
                TarifaExtra = 0;
                SueldoBruto = HorasTrabajadas * TarifaHora;
            }
            else
            {
                HorasExtra = HorasTrabajadas - 40;
                TarifaExtra = TarifaHora * 1.10m;
                var sueldoBase = 40 * TarifaHora;
                var sueldoExtra = HorasExtra * TarifaExtra;
                SueldoBruto = sueldoBase + sueldoExtra;
            }
        }
    }
}
