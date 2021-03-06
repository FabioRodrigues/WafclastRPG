﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace WafclastRPG.Bot.Config
{
    public class BotInfo
    {
        [JsonIgnore]
        public int Membros;

        [JsonIgnore]
        public int Guildas;

        [JsonIgnore]
        public DateTime TempoAtivo { get; set; } = DateTime.Now;

        [JsonProperty("versaoMaior")]
        public int VersaoMaior { get; set; } = 1;

        [JsonProperty("versaoMinor")]
        public int VersaoMinor { get; set; } = 1;

        [JsonProperty("versaoRevisao")]
        public int VersaoRevisao { get; set; } = 0;

        /// <summary>
        /// Carrega a config de um arquivo JSON.
        /// </summary>
        /// <param name="path">Caminho para o arquivo config.</param>
        /// <returns></returns>
        public static BotInfo LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                BotInfo botinfo = new BotInfo();
                botinfo.SaveToFile(path);
                return botinfo;
            }

            using (var sr = new StreamReader(path))
                return JsonConvert.DeserializeObject<BotInfo>(sr.ReadToEnd());
        }

        /// <summary>
        /// Salva as config para um arquivo JSON.
        /// </summary>
        /// <param name="path">Caminho para o arquivo config.</param>
        public void SaveToFile(string path)
        {
            using (var sw = new StreamWriter(path))
                sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
