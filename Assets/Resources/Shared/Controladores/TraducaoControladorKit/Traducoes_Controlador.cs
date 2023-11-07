using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.InputSystem;


    public class Traducoes_Controlador : MonoBehaviour
    {
        //nomeIdioma_PAIS ex: pt-BR ou en-US
        public static Traducoes_Controlador Self;
        internal string Idioma = "pt-BR";
        internal string CaminhoIdioma = "./Assets/Shared/Idiomas";
        internal Dictionary<string, string> Traducoes;

        private void Awake()
        {
            Self = this;
        }

        public void CarregarIdioma(string idioma)
        {
            Idioma = idioma;
            Traducoes = CarregarArquivo();
        }

        public string Traduzir(string fraseTraduzir)
        {
            var palavras = fraseTraduzir.Split(' ');
            var retorno = new StringBuilder();

            foreach (var item in palavras)
            {
                var palavra = item;

                var temPonto = palavra.Contains('.');
                var temVirgula = palavra.Contains('.');
                palavra = palavra.Replace(".", "").Replace(",", "");

                var traducao = Traducoes.Where(p => p.Key == palavra.ToUpper()).FirstOrDefault().Value;

                if (traducao == null)
                {

                    retorno.Append($" _NÃO CONSTA NO DICIONARIO_ ");
                }
                else
                {
                    if (temPonto) traducao += ".";
                    if (temVirgula) traducao += ",";

                    retorno.Append($"{traducao} ");
                }
            }

            return retorno.ToString();
        }

        public void CadastrarKey(string key, string valor, string idioma)
        {
            if (string.IsNullOrEmpty(key)) Debug.Log("Key esta vazia");
            if (string.IsNullOrEmpty(valor)) Debug.Log("valor esta vazia");
            if (string.IsNullOrEmpty(idioma)) Debug.Log("idioma esta vazia");

            var chave = key.ToUpper();
            var internalTraducoes = CarregarArquivo(idioma);
            var traducao = internalTraducoes.FirstOrDefault(p => p.Key == chave);

            if (!string.IsNullOrEmpty(traducao.Key))
            {
                internalTraducoes[chave] = valor;
            }
            else
            {
                internalTraducoes.Add(chave, valor);
            }

            File.WriteAllText($"{Path.Combine(CaminhoIdioma, Idioma)}.json", JsonConvert.SerializeObject(internalTraducoes));
            Debug.Log($"Key '{chave}:{valor}' cadastrada para o idioma {idioma}");
        }

        public string TraduzirByKey(string Key)
        {
            var traducao = Traducoes.Where(p => p.Key == Key.ToUpper()).FirstOrDefault().Value;
            if (traducao == null)
            {
                return " _NÃO CONSTA NO DICIONARIO_ ";
            }
            else
            {
                return traducao;
            }
        }

        private Dictionary<string, string> CarregarArquivo(string idioma = null)
        {
            var caminhoCompleto = $"{Path.Combine(CaminhoIdioma, idioma != null ? idioma : this.Idioma)}.json";

            if (!File.Exists(caminhoCompleto))
            {
                //Cria arquivo
                if (!Directory.Exists(CaminhoIdioma)) Directory.CreateDirectory(CaminhoIdioma);
                File.WriteAllText(caminhoCompleto, "{}");
            }

            var jsonTraducao = File.ReadAllText(caminhoCompleto);

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonTraducao);
        }
    }
