using GestionCommande.controleur;
using GestionCommande.dao;
using GestionCommande.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.testTU
{
    [TestClass]

    public class Test
    {
        [TestMethod]

        public void TestAjoutClientOk()
        {
            Controleur c = new CommandeControleur();
            ClientDao client = new ClientDao();
            int unclient = client.Clients.Count();
            c.AjouterClient("Gaborit", "Joan", "joan.gaborit@gmail.com");
            Assert.AreEqual(c.GetClients().Last().Id, unclient + 1);  
            Assert.AreEqual(c.GetClients().Last().Nom, "Gaborit");
            Assert.AreEqual(c.GetClients().Last().Prenom, "Joan");
            Assert.AreEqual(c.GetClients().Last().Mail, "joan.gaborit@gmail.com");
            //J'ajoute un client avec un nom, un prénom et une adresse mail et je vérifie si le dernier client ajouté est bien égal aux informations
            //concernant l'ajout du client                                                                   
        }

        [TestMethod]

        public void TestAjoutProduitOk()
        {
            Controleur c1 = new CommandeControleur();
            ProduitDao produit = new ProduitDao();
            int unproduit = produit.Produits.Count();
            c1.CreerProduit("Iphone", "749");
            Assert.AreEqual(c1.GetProduits().Last().Id, unproduit + 1);                          
            Assert.AreEqual(c1.GetProduits().Last().Designation, "Iphone");
            Assert.AreEqual(c1.GetProduits().Last().Prix, "749");
            //J'ajoute un produit avec une désignation et un prix et je vérifie si le dernier produit ajouté est bien égal aux informations
            //concernant l'ajout du produit    
        }

        [TestMethod]

        public void TestAjoutCommandeOk()
        {
            Controleur c2 = new CommandeControleur();
            Client client = c2.GetClients().Last();
            ICollection<LigneCommande> lignesCommande = new Collection<LigneCommande>();
            LigneCommande ligneCmd = new LigneCommande() { Produit = c2.GetProduits().First(), Quantite = 2 };
            lignesCommande.Add(ligneCmd);
            c2.CreerCommande(client, lignesCommande);                      
            Assert.AreEqual(c2.GetCommandes().Last().Client, client);      
            Assert.AreEqual(c2.GetCommandes().Last().LignesCommande.Last().Quantite, 2);
            Assert.AreEqual(c2.GetProduits().First().Id, 1);
            //J'ajoute une commande qui contient un le dernier client de la liste, le premier produit de la liste et une quantité à 2
            //Je vérifie qu'il me retourne bien que le dernier client, commande bien le premier produit deux fois 
        }
     }
}
