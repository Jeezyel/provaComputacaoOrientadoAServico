namespace provaComputacaoOrientadaAServico.Model
{
    public class Cor
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string codego { get; set; }

        public Cor(string nome, string codego)
        {
            this.nome = nome;
            this.codego = codego;
        }
        



    }
}
