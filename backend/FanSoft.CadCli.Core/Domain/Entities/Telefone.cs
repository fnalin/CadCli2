namespace FanSoft.CadCli.Core.Domain.Entities
{
    public class Telefone:Entity
    {
        protected Telefone()
        {}

        public Telefone(int id, int clienteId, string numero)
        {
            Id = id;
            ClienteId = clienteId;
            Numero = numero;
        }

        public Telefone(int id, Cliente cliente, string numero)
        {
            Id = id;
            Cliente = cliente;
            Numero = numero;
        }

        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public string Numero { get; private set; }
        public Cliente Cliente { get; set; }
    }
}
