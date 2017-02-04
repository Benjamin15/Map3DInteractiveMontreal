using UnityEngine;
using System.Collections;

public class Batiment {
    public enum Type { normal, metro, hotel, magasin, ecole };
    private Coordonnee coordonnee; // Contient les longues en x, y ,z
    private Coordonnee centre; // contient le point de centre
    private string nom;
    private Type type;
    private string adresse;

    /**
     * 
     * Constructeur et surcharge
     **/


    public Batiment()
    {
        coordonnee = new Coordonnee(0, 0, 0);
        centre = new Coordonnee(0, 0, 0);
        nom = "";
        adresse = "";
        type = Type.normal;
    }
    public Batiment(int x, int y, int z)
    {
        coordonnee = new Coordonnee(x, y, z);
        centre = new Coordonnee(0, 0, 0);
        nom = "";
        adresse = "";
        type = Type.normal;
    }
    public Batiment (int longueurX, int largeurY, int hauteurZ, int centreX, int centreY)
    {
        coordonnee = new Coordonnee(longueurX, hauteurZ, largeurY); // car unity inverse Y et Z
        centre = new Coordonnee(centreX, 0, centreY); // centre en 2D
        nom = "";
        adresse = "";
        type = Type.normal;
    }

    /**
     * 
     * Getter/Setter Centre
     **/

    public Coordonnee getCentre()
    {
        return centre;
    }
    public void setCentre(Coordonnee centre)
    {
        this.centre = centre;
    }
    public void setCentre(int x, int y)
    {
        centre = new Coordonnee(x, 0, y);
    }


    /**
     * 
     * Getter/Setter Coordonnées
     **/ 

    public Coordonnee getCoordonnee()
    {
        return this.coordonnee;
    }

    public void setCoordonnee(int x, int y, int z)
    {
        coordonnee = new Coordonnee(x, y, z);
    }
    public void setCoordonnee(Coordonnee coordonnee)
    {
        this.coordonnee = coordonnee;
    }

    /**
     * 
     * Getter/Setter Nom
     **/

    public string getNom()
    {
        return nom;
    }
    public void setNom(string nom)
    {
        this.nom = nom;
    }


    /**
     * 
     * Getter/Setter Type
     **/


    public Type getType()
    {
        return type;
    }

    public void setType(Type type)
    {
        this.type = type;
    }


    /**
     * 
     * Getter/Setter Adresse
     **/

    public string getAdresse()
    {
        return adresse;
    }
    public void setAdresse(string adresse)
    {
        this.adresse = adresse;
    }
}
