﻿using WafclastRPG.Game.Enuns;
using MongoDB.Bson.Serialization.Attributes;

namespace WafclastRPG.Game.Entidades.Itens
{
    [BsonIgnoreExtraElements]
    [BsonKnownTypes(typeof(RPArmaAdaga), typeof(RPArmaArco), typeof(RPBaseItemArma), typeof(RPBaseItemEquipavel), typeof(RPArmaCetro),
       typeof(RPArmaEspada), typeof(RPBaseFrasco), typeof(RPFrascoVida), typeof(RPArmaMacaUmaMao), typeof(RPArmaMachadoUmaMao),
        typeof(RPArmaVarinha), typeof(RPMoedaEmpilhavel))]
    public class WafclastItem
    {
        public int DropLevel { get; set; } // Nível que começa a cair
        public int ILevel { get; set; } // Zona de onde caiu, tudo baseado nisso
        public string TipoBase { get; private set; } // Nome base
        public string TipoBaseModificado { get; set; } // Nome base + prefixos
        public RPClasse Classe { get; set; }
        public RPRaridade Raridade { get; set; }

        // Ocupa
        public int Espaco { get; set; }

        public WafclastItem(int dropLevel, string tipoBase, RPClasse classe, int espaco)
        {
            DropLevel = dropLevel;
            TipoBase = tipoBase;
            TipoBaseModificado = tipoBase;
            Classe = classe;
            Espaco = espaco;
            Raridade = RPRaridade.Normal;
        }
    }
}