using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;
public class readData{

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
                foreach (XmlNode transformNode in transformcontent)
                {
                    if (transformNode.Name == "centre")
                    {
                        foreach (XmlNode transformItems in transformNode)
                        {
                            if (transformItems.Name == "x")
                            {
                                batiment.getCentre().x = int.Parse(transformItems.InnerText);
                            }
                            if (transformItems.Name == "y")
                            {
                                batiment.getCentre().y = int.Parse(transformItems.InnerText);
                            }
                        }
                    }
                    else if (transformNode.Name == "longueur")
                    {
                        foreach (XmlNode transformItems in transformNode)
                        {
                            if (transformItems.Name == "x")
                            {
                                batiment.getCoordonnee().x = int.Parse(transformItems.InnerText);
                            }
                            else if (transformItems.Name == "y")
                            {
                                batiment.getCoordonnee().y = int.Parse(transformItems.InnerText);
                            }
                            else if (transformItems.Name == "z")
                            {
                                batiment.getCoordonnee().z = int.Parse(transformItems.InnerText);
                            }
                        }
                    }
                    else if (transformNode.Name == "nom")
                    {
                        batiment.setNom(transformNode.InnerText);
                    }
                    else if (transformNode.Name == "type")
                    {
                        if (transformNode.InnerText.Contains("metro"))
                        {
                            batiment.setType(Batiment.Type.metro);
                        }
                        else if (transformNode.InnerText.Contains("hotel"))
                        {
                            batiment.setType(Batiment.Type.hotel);
                        }
                        else if (transformNode.InnerText.Contains("magasin"))
                        {
                            batiment.setType(Batiment.Type.magasin);
                        }
                        else if (transformNode.InnerText.Contains("ecole"))
                        {
                            batiment.setType(Batiment.Type.ecole);
                        }
                    }
                }
                batiments.Add(batiment);
            }
        }
        return batiments;
    }

}
