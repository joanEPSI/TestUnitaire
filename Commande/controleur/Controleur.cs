using GestionCommande.controleur;
using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.controleur
{
    public interface Controleur
    {
        object AjouterProduit { get; set; }

        void CreerCommande(Client client, ICollection<LigneCommande> ligneCmd);

        void AjouterClient(string Nom, string Prenom, string Mail);

        void CreerProduit(string Designation, string Prix);

        ICollection<Client> GetClients();

        ICollection<Produit> GetProduits();
        ICollection<Commande> GetCommandes();
    }
}
