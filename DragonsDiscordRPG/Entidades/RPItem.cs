﻿using DragonsDiscordRPG.Enuns;
using MongoDB.Bson.Serialization.Attributes;

namespace DragonsDiscordRPG.Entidades
{
    [BsonIgnoreExtraElements]
    public class RPItem
    {
        public RPItem(RPItemTipo tipo, string nome, int nivel, int espaco)
        {
            Tipo = tipo;
            Nome = nome;
            Nivel = nivel;
            Espaco = espaco;
            Quantidade = 1;
        }

        public RPItemTipo Tipo { get; set; }
        public string Nome { get; set; }
        public int Nivel { get; set; }

        public int Inteligencia { get; set; }
        public int Destreza { get; set; }
        public int Forca { get; set; }
        public int Espaco { get; set; }
        public int Pilha { get; set; }
        public int Quantidade { get; set; }

        #region Poção

        public double LifeRegen { get; set; }
        public double ManaRegen { get; set; }
        public double Tempo { get; set; }
        public double CargasMax { get; set; }
        public double CargasAtual { get; set; }
        public double CargasUso { get; set; }

        public void AddCarga(double valor)
        {
            CargasAtual += valor;
            if (CargasAtual > CargasMax) CargasAtual = CargasMax;
        }

        public bool RemoverCarga(double valor)
        {
            if (CargasAtual >= valor)
            {
                CargasAtual -= valor;
                return true;
            }
            return false;
        }


        #endregion

        #region Arma

        public RPDano DanoFisico { get; set; }
        public double ChanceCritico { get; set; }
        public double VelocidadeAtaque { get; set; }

        #endregion
    }
}
