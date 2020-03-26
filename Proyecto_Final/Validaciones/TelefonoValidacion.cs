﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace Proyecto_Final.Validaciones
{
    public class TelefonoValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                if (cadena.Length <= 0)
                    return new ValidationResult(false, "Debes poner un teléfono");

                cadena = cadena.Replace("-", "");

                foreach (var caracter in cadena)
                {
                    if (!char.IsDigit(caracter))
                        return new ValidationResult(false, "El teléfono solo puede tener numeros o guion");
                }

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner un teléfono");
        }
    }
}