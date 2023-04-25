using System.Xml.Linq;
using xdocument;

var doc = XDocument.Load("fichier.xml");
var personne = new Personne();

/// PEUT UTILISE .descendance (voir doc)

///PERMET DE LIRE LE DOCUMENT SANS CONNAITRE LA STRUCTURE EXACTE COMPARE A WML READER
if(doc.Root is not null)
{
    foreach(var el in doc.Root.Elements())
    {
        if(el.Name == "Nom")
        {
            personne.Nom = el.Value;
        }
        else if(el.Name == "Prenom")
        {
            personne.Prenom = el.Value;
        }
        else if(el.Name == "DateDeNaissance")
        {
            personne.DateDeNaissance = DateTime.Parse(el.Value);
        }
        else if(el.Name == "Taille")
        {
            personne.Taille = int.Parse(el.Value);
        }
    }
}
System.Console.WriteLine($"{personne.Prenom} {personne.Nom} né le {personne.DateDeNaissance:dd/MM/yyyy} mesure {personne.Taille}cm");

var adresse = new XElement("Adresse", "1 rue Jeanne d'Arc, 76000 Rouen");

/// AJOUTE DIRECTEMENT A LA FIN DU DOC
// doc.Root.Add

if(doc.Root is not null)
{

    ///RENVOIE LE PREMIER NOEUD QUI CORRESPOND
    var elementTaille = doc.Root.Element("Taille");
    if(elementTaille is not null)
    {
        ///BIEN LIRE LA DOC POUR CONNAITRE LES METHODES
        elementTaille.AddAfterSelf(adresse);
    }
}

///CONVERTIT EN CHAINE DE CARACTERE POUR TOUT IMPLEMENTER DANS LE DOC
System.Console.WriteLine(doc.ToString());