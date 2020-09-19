﻿using TorreRPG.Entidades.Itens;
using TorreRPG.Extensoes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorreRPG.Entidades
{
    [BsonIgnoreExtraElements]
    public class RPZona
    {

        public int Nivel { get; set; }
        public long OndaTotal { get; set; }
        public long OndaAtual { get; set; }
        public int Turno { get; set; } // Reseta em outra onda
        public double PontosAcaoTotal { get; set; }
        public List<RPItem> ItensNoChao { get; set; }
        public List<RPMonstro> Monstros { get; set; }

        public RPZona()
        {
            Nivel = 0;
            ItensNoChao = new List<RPItem>();
            Monstros = new List<RPMonstro>();
        }

        public int TrocarZona(double velocidadeAtaquePersonagem, int nivel)
        {
            Monstros = new List<RPMonstro>();
            ItensNoChao = new List<RPItem>();
            Turno = 0;
            Nivel = nivel;
            OndaAtual = 1;
            OndaTotal = Convert.ToInt64(Math.Pow(Nivel, 2) * 2);
            int quantidadeInimigo = Math.Clamp(Convert.ToInt32(Math.Pow(1, nivel)), 0, 1);
            for (int i = 0; i < quantidadeInimigo; i++)
            {
                var f = ModuloBanco.MonstrosNomes[Nivel];
                var sorteio = Calculo.SortearValor(0, f.Nomes.Count - 1);
                var g = f.Nomes[sorteio];
                RPMonstro m = new RPMonstro(g, nivel);
                Monstros.Add(m);
            }

            foreach (var item in Monstros)
                PontosAcaoTotal += item.VelocidadeAtaque;
            PontosAcaoTotal += velocidadeAtaquePersonagem;
            return quantidadeInimigo;
        }

        public bool SortearItem(RPMonstro monstro, double chancePersonagem, out int drops)
        {
            drops = 0;
            Monstros.Remove(monstro);

            if (monstro.SortearItens(monstro.Nivel, chancePersonagem, out List<RPItem> itens))
            {
                foreach (var item in itens)
                    ItensNoChao.Add(item);
                drops = itens.Count;
                return true;
            }

            return false;
        }

        public bool NovaOnda(double velocidadeAtaquePersonagem, out int quantidadeMonstros)
        {
            quantidadeMonstros = 0;
            if (Monstros.Count == 0)
            {
                if (OndaAtual < OndaTotal)
                {
                    Turno = 0;
                    Monstros = new List<RPMonstro>();
                    OndaAtual++;

                    quantidadeMonstros = Calculo.SortearValor(1, 2);
                    for (int i = 0; i < quantidadeMonstros; i++)
                    {

                        // Sorteia os monstros
                        var listaNomes = ModuloBanco.MonstrosNomes[Nivel];
                        var nomeSorteado = listaNomes.Nomes[Calculo.SortearValor(0, listaNomes.Nomes.Count - 1)];
                        RPMonstro m = new RPMonstro(nomeSorteado, Nivel);
                        Monstros.Add(m);
                    }

                    //Calcula pontos de ação total.
                    foreach (var item in Monstros)
                        PontosAcaoTotal += item.VelocidadeAtaque;
                    PontosAcaoTotal += velocidadeAtaquePersonagem;
                    return true;
                }
            }
            return false;
        }

        public void CalcAtaquesInimigos(RPPersonagem personagem, StringBuilder resumoBatalha)
        {
            do
            {
                foreach (var mob in Monstros)
                {
                    if (mob.Acao(PontosAcaoTotal))
                    {
                        Turno++;
                        if (Calculo.DanoFisicoChanceAcerto(mob.Precisao, personagem.Evasao.Modificado))
                        {
                            double dano = personagem.ReceberDanoFisico(mob.Dano);
                            resumoBatalha.AppendLine($"{mob.Nome} causou {dano.Text()} de dano físico.");
                        }
                        else
                            resumoBatalha.AppendLine($"{mob.Nome} errou o ataque!");
                    }
                }


                if (personagem.Acao(PontosAcaoTotal))
                {
                    Turno++;
                    break;
                }
            } while (personagem.Vida.Atual > 0);
        }
    }
}