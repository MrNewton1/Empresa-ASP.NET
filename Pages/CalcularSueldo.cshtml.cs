// Importación de los espacios de nombres necesarios para Razor Pages y validaciones.
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Empresa.Pages
{
    // Modelo de página para el cálculo de sueldo.
    public class CalcularSueldoModel : PageModel
    {
        // Propiedad enlazada al formulario para capturar las horas trabajadas.
        // Requiere un valor entre 0 y 168 (máximo de horas en una semana).
        [BindProperty, Required, Range(0, 168)]
        public decimal HorasTrabajadas { get; set; }

        // Propiedad enlazada al formulario para capturar la tarifa por hora.
        // Requiere un valor entre 0.01 y 1000.
        [BindProperty, Required, Range(0.01, 1000)]
        public decimal TarifaHora { get; set; }

        // Salidas del cálculo
        // Indica si se deben mostrar los resultados en la vista.
        public bool MostrarResultados { get; private set; }
        // Cantidad de horas extra trabajadas.
        public decimal HorasExtra { get; private set; }
        // Tarifa aplicada a las horas extra.
        public decimal TarifaExtra { get; private set; }
        // Sueldo bruto calculado.
        public decimal SueldoBruto { get; private set; }

        // Propiedades de solo lectura para mostrar los resultados con formato de moneda.
        public string TarifaExtraString => TarifaExtra.ToString("C2");
        public string SueldoBrutoString => SueldoBruto.ToString("C2");

        // Método que se ejecuta al enviar el formulario (POST).
        public void OnPost()
        {
            // Si el modelo no es válido, no se muestran resultados.
            if (!ModelState.IsValid)
            {
                MostrarResultados = false;
                return;
            }

            // Si el modelo es válido, se procede al cálculo.
            MostrarResultados = true;

            // Lógica para calcular sueldo y horas extra.
            if (HorasTrabajadas <= 40)
            {
                HorasExtra = 0;
                TarifaExtra = 0;
                SueldoBruto = HorasTrabajadas * TarifaHora;
            }
            else
            {
                // Si hay horas extra, se calcula la tarifa extra y el sueldo correspondiente.
                HorasExtra = HorasTrabajadas - 40;
                TarifaExtra = TarifaHora * 1.10m;
                var sueldoBase = 40 * TarifaHora;
                var sueldoExtra = HorasExtra * TarifaExtra;
                SueldoBruto = sueldoBase + sueldoExtra;
            }
        }
    }
}
