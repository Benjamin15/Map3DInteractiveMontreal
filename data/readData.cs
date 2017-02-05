using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;
public class readData : MonoBehaviour{

    public List<Batiment> LoadFromXml()
    {
        string filepath = Application.dataPath + @"/data/data.xml";
        XmlDocument xmlDoc = new XmlDocument();
        List<Batiment> batiments = new List<Batiment>();
        if (File.Exists(filepath))
        {
            xmlDoc.Load(filepath);
            XmlNodeList transformList = xmlDoc.GetElementsByTagName("batiment");

            foreach (XmlNode transformInfo in transformList)
            {
                XmlNodeList transformcontent = transformInfo.ChildNodes;
                Batiment batiment = new Batiment();
                foreach (XmlNode transformItems in transformcontent)
                {
                        if (transformItems.Name == "x")
                        {
                            print(batiment.getCentre().x);
                            batiment.getCentre().x = float.Parse(transformItems.InnerText);
                            print(batiment.getCentre().x);
                        }
                        else if (transformItems.Name == "y")
                        {
                            batiment.getCentre().y = float.Parse(transformItems.InnerText);
                        }
                        if (transformItems.Name == "deltaX")
                        {
                            batiment.getCoordonnee().x = float.Parse(transformItems.InnerText);
                            print(batiment.getCoordonnee().x + " aaa");
                        }
                        else if (transformItems.Name == "deltaY")
                        {
                            batiment.getCoordonnee().y = float.Parse(transformItems.InnerText);
                        }
                        else if (transformItems.Name == "deltaZ")
                        {
                            batiment.getCoordonnee().z = float.Parse(transformItems.InnerText);
                        }
                    else if (transformItems.Name == "nom")
                    {
                        batiment.setNom(transformItems.InnerText);
                    }
                    else if (transformItems.Name == "type")
                    {
                        if (transformItems.InnerText.Contains("metro"))
                        {
                            batiment.setType(Batiment.Type.metro);
                        }
                        else if (transformItems.InnerText.Contains("hotel"))
                        {
                            batiment.setType(Batiment.Type.hotel);
                        }
                        else if (transformItems.InnerText.Contains("magasin"))
                        {
                            batiment.setType(Batiment.Type.magasin);
                        }
                        else if (transformItems.InnerText.Contains("ecole"))
                        {
                            batiment.setType(Batiment.Type.ecole);
                        }
                        else if (transformItems.InnerText.Contains("parc"))
                        {
                            batiment.setType(Batiment.Type.parc);
                        }
                        else if (transformItems.InnerText.Contains("passagePieton"))
                        {
                            batiment.setType(Batiment.Type.passagePieton);
                        }
                        else if (transformItems.InnerText.Contains("restaurant"))
                        {
                            batiment.setType(Batiment.Type.restaurant);
                        }
                        else if (transformItems.InnerText.Contains("coiffeur"))
                        {
                            batiment.setType(Batiment.Type.restaurant);
                        }
                        else if (transformItems.InnerText.Contains("eglise"))
                        {
                            batiment.setType(Batiment.Type.restaurant);
                        }
                    }
                    else if (transformItems.Name == "adresse")
                    {
                        batiment.setAdresse(transformItems.InnerText);
                    }
                }

                batiment.getCoordonnee().updateCoord();
                batiment.getCentre().updateCoord();
                batiments.Add(batiment);
            }
        }
        return batiments;
    }
    
    public void WriteToXml(List<Batiment> batiments)
    {
        string filepath = Application.dataPath + @"/data/data.xml";
        XmlDocument xmlDoc = new XmlDocument();

        if (File.Exists(filepath))
        {
            xmlDoc.Load(filepath);
            XmlElement elmRoot = xmlDoc.DocumentElement;
            elmRoot.RemoveAll();
            XmlElement donnee = xmlDoc.CreateElement("donnee");
            elmRoot.AppendChild(donnee);
            foreach (Batiment batiment in batiments)
            {
                XmlElement elmNew = xmlDoc.CreateElement("batiment");

                SetValuesBeforeXmlSave(xmlDoc, elmNew, batiment);

                donnee.AppendChild(elmNew);
            }
            xmlDoc.Save(filepath);
        }
    }


    private void SetValuesBeforeXmlSave(XmlDocument xmlDoc, XmlElement elmNew, Batiment batiment)
    {

        XmlElement x = xmlDoc.CreateElement("x");
        x.InnerText = "" + batiment.getCentre().x;
        XmlElement y = xmlDoc.CreateElement("y");
        y.InnerText = "" + batiment.getCentre().y;

        XmlElement deltaX = xmlDoc.CreateElement("deltaX");
        deltaX.InnerText = "" + batiment.getCoordonnee().x + " " ;
        XmlElement deltaY = xmlDoc.CreateElement("deltaY");
        deltaY.InnerText = "" + batiment.getCoordonnee().y + " ";
        XmlElement deltaZ = xmlDoc.CreateElement("deltaZ");
        deltaZ.InnerText = "" + batiment.getCoordonnee().z + " ";

        XmlElement nom = xmlDoc.CreateElement("nom");
        nom.InnerText = "" + batiment.getNom();
        XmlElement type = xmlDoc.CreateElement("type");
        type.InnerText = "" + batiment.getType();
        XmlElement adresse = xmlDoc.CreateElement("adresse");
        adresse.InnerText = "" + batiment.getAdresse();

        elmNew.AppendChild(x);
        elmNew.AppendChild(y);

        elmNew.AppendChild(deltaX);
        elmNew.AppendChild(deltaY);
        elmNew.AppendChild(deltaZ);

        elmNew.AppendChild(nom);
        elmNew.AppendChild(type);
        elmNew.AppendChild(adresse);
    }
}
