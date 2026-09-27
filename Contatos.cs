using System.Collections.Generic;

namespace AgendaContatos
{
    public class Contatos
    {
        private readonly List<Contato> agenda;

        public List<Contato> Agenda => agenda;

        public Contatos()
        {
            agenda = new List<Contato>();
        }

        public bool Adicionar(Contato c)
        {
            if (Pesquisar(c) == null)
            {
                agenda.Add(c);
                return true;
            }
            return false; // Contato já existente (com o mesmo e-mail)
        }

        public Contato Pesquisar(Contato c)
        {
            return agenda.Find(item => item.Equals(c));
        }

        public bool Alterar(Contato c)
        {
            Contato encontrado = Pesquisar(c);
            if (encontrado != null)
            {
                encontrado.Nome = c.Nome;
                encontrado.DtNasc = c.DtNasc;
                encontrado.Telefones = c.Telefones;
                return true;
            }
            return false;
        }

        public bool Remover(Contato c)
        {
            Contato encontrado = Pesquisar(c);
            if (encontrado != null)
            {
                return agenda.Remove(encontrado);
            }
            return false;
        }
    }
}