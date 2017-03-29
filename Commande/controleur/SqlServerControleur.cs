using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCommande.model;
using GestionCommande.dao;

namespace GestionCommande.controleur
{
    public class SqlServerControleur : Controleur
    {
        private GestionCommandeContext ctx;

        public object AjouterProduit
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public SqlServerControleur()
        {
            ctx = new GestionCommandeContext();
        }
        public void CreerCommande(Client client, ICollection<LigneCommande> ligneCmd)
        {
            Commande cmd = new Commande { Id = ctx.Commandes.Count() + 1, Client = client, LignesCommande = ligneCmd };
            foreach (LigneCommande ligne in ligneCmd)
            {
                ligne.Commande = cmd;
            }
            client.Commandes.Add(cmd);
            ctx.Commandes.Add(cmd);
            ctx.Entry(client).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void AjouterClient(string Nom, string Prenom, string Mail)
        {

        }

        public void CreerProduit(string Designation, int Prix)
        {

        }

        public ICollection<Client> GetClients()
        {
            return ctx.Clients.ToList();
        }

        public ICollection<Commande> GetCommandes()
        {
            return ctx.Commandes.ToList();
        }

        public ICollection<Produit> GetProduits()
        {
            return ctx.Produits.ToList();
        }

        public void CreerProduit(string Designation, string Prix)
        {
            throw new NotImplementedException();
        }

        public void AjouterClient(Client client, ICollection<Client> client1)
        {
            throw new NotImplementedException();
        }
    }
}
