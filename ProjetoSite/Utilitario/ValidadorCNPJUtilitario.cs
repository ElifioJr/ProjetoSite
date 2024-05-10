using System.Text;

namespace ProjetoSite.Utilitario {
    public class ValidadorCNPJUtilitario {

        public static bool ValidarCNPJ(string cnpj) {
            // Remove caracteres não numéricos do CNPJ
            cnpj = LimparCNPJ(cnpj);

            // Verifica se o CNPJ tem 14 dígitos
            if(cnpj.Length != 14)
                return false;

            // Calcula os dígitos verificadores
            int[] multiplicadoresPrimeiroDigito = { 5,4,3,2,9,8,7,6,5,4,3,2 };
            int[] multiplicadoresSegundoDigito = { 6,5,4,3,2,9,8,7,6,5,4,3,2 };

            int primeiroDigitoVerificador = CalcularDigitoVerificador(cnpj,multiplicadoresPrimeiroDigito);
            int segundoDigitoVerificador = CalcularDigitoVerificador(cnpj,multiplicadoresSegundoDigito);

            // Verifica os dígitos verificadores calculados com os dígitos reais do CNPJ
            return cnpj[12] == (char)(primeiroDigitoVerificador + '0') && cnpj[13] == (char)(segundoDigitoVerificador + '0');
        }

        private static string LimparCNPJ(string cnpj) {
            // Remove caracteres não numéricos do CNPJ
            StringBuilder sb = new StringBuilder();
            foreach(char c in cnpj) {
                if(char.IsDigit(c)) {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private static int CalcularDigitoVerificador(string cnpj,int[] multiplicadores) {
            int soma = 0;
            for(int i = 0;i < multiplicadores.Length;i++) {
                soma += (cnpj[i] - '0') * multiplicadores[i];
            }

            int resto = soma % 11;
            if(resto < 2)
                return 0;
            else
                return 11 - resto;

        }
    }


}
