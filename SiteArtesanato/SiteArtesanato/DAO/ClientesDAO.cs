using SiteArtesanato.Data;
using SiteArtesanato.Models;

namespace SiteArtesanato.DAO
{
    public class ClientesDAO
    {
        private readonly ApplicationDbContext _context;
        public ClientesDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
