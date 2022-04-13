using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib.DataValidations
{
    public static class PersonDataValidation
    {
        public static bool IsCpfValid(string cpf)
        {
            cpf = cpf.Length == 11 ? cpf.Trim() : cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            bool isAllNumber = false;
            cpf.ToList().ForEach(letter => isAllNumber = int.TryParse(letter.ToString(), out _));
            if (!isAllNumber) return false;

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = cpf[..9];
            var soma = 0;

            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            var digito = resto.ToString();

            tempCpf += digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool IsBithDateValid(DateTime birth) => birth < DateTime.Now;

    }
}
