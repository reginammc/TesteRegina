using System;

namespace TesteRegina.Model
{
    public class HistoricoModel
    {
        public DateTime Data { get; set; }
        public string Assessor { get; set; }
        public int Conta { get; set; }
        public string Ativo { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public int QtdAparente { get; set; }
        public int QtdDisp { get; set; }
        public int QtdCanc { get; set; }
        public int QtdExec { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorDisp { get; set; }
        public string Objetivo { get; set; }
        public string ObjDisp { get; set; }
        public string Reducao { get; set; }
    }
}