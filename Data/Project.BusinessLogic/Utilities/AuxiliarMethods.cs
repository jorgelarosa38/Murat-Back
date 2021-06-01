using Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using static Project.BusinessLogic.Utilities.Constant;

namespace Project.BusinessLogic.Utilities
{
    public class AuxiliarMethods
    {
        public static void Base64ToImage(string directory, string binary, string ImagePath, string Category)
        {
            var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(binary)));
            var path = Path.Combine(directory, Category, ImagePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            img.Save(path);
        }

        public static string GenerarURL(string directory, string categoria, string ImageName)
        {
            string url = Path.Combine(directory, categoria, ImageName);
            return url;
        }

        public static object ValidateParameters(object obj, Type model)
        {
            PropertyInfo[] properties = model.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var Valor = property.GetValue(obj);
                if (Valor == null)
                {
                    var type = (property.Name).GetType().ToString();
                    switch (type)
                    {
                        case "System.int":

                            property.SetValue(obj, 0);
                            break;
                        case "System.String":
                            property.SetValue(obj, "");
                            break;
                    }
                }
            }
            return obj;
        }
        public static string StandardXML(List<XMLStructure> lstXML)
        {
            string xml = "";
            string nodo = "";

            foreach (var item in lstXML)
            {
                string tablas = "";
                string datos = "";

                if (nodo != item.Entidad)
                {
                    tablas = "</" + nodo + "><" + item.Entidad + ">";
                }
                datos = "<" + item.Etiqueta + ">" + item.Valor + "</" + item.Etiqueta + ">";

                nodo = item.Entidad;

                xml += tablas + datos;
            }
            xml = xml[3..^0];

            xml = "<PAXLST_Message >" + xml + "</" + nodo + "></PAXLST_Message >";

            return xml;
        }
    }
}
