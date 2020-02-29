using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Serialize_Json
{
    class MonJson
    {
        public static void printDictionary(Dictionary<String, Object> dictionary)
        {
            Console.WriteLine(formatDictionary(dictionary));
        }

        public static String Serialization(Object obj)
        {
            return formatDictionary(convertToDictionary(obj));
        }


        //Utilisation de la fonction récursive
        public static Dictionary<String, Object> convertToDictionary(object obj)
        {
            if (obj == null)
                return null;

            Dictionary<String, Object> dictionary = new Dictionary<String, Object>();

            Type objectType = obj.GetType();

            if (IsPrimitiveType(objectType))
            {
                dictionary.Add("_", obj);
                return dictionary;
            }
            if (IsArray(objectType))
            {
                List<Object> listDictionary = new List<Object>();
                foreach (var el in (IEnumerable<Object>)obj)
                {
                    listDictionary.Add(convertToDictionary(el));
                }
                dictionary.Add("_", listDictionary);
                return dictionary;
            }

            PropertyInfo[] properties = objectType.GetProperties((BindingFlags.NonPublic |
                                                                   BindingFlags.Instance | BindingFlags.Public
                                                                  | BindingFlags.FlattenHierarchy));
            foreach (PropertyInfo prop in properties)
            {
                if (IsArray(prop.PropertyType))
                {
                    if (prop.GetValue(obj) == null)
                        continue;

                    List<Object> listDictionary = new List<Object>();
                    foreach (var el in (IEnumerable<Object>)prop.GetValue(obj))
                    {
                        listDictionary.Add(convertToDictionary(el));
                    }
                    dictionary.Add(prop.Name, listDictionary);

                }
                else if (IsPrimitiveType(prop.PropertyType))
                    dictionary.Add(prop.Name, prop.GetValue(obj));
                else
                    dictionary.Add(prop.Name, convertToDictionary(prop.GetValue(obj)));
            }

            return dictionary;
        }
        private static bool IsPrimitiveType(Type type)
        {
            return type.IsValueType || IsString(type);
        }

        private static bool IsArray(Type type)
        {
            if (type == typeof(Dictionary<String, Object>))
                return false;
            foreach (Type interfaceType in type.GetInterfaces())
            {
                if (!IsString(type) && interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition()
                    == typeof(IEnumerable<>))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsString(Type type)
        {
            return type == typeof(string) || type == typeof(String);
        }


        private static string formatDictionary(Dictionary<String, Object> dictionary)
        {
            List<string> results = new List<string>();
            foreach (var element in dictionary)
            {
                if (element.Value == null)
                    continue;
                string value = "";

                if (IsArray(element.Value.GetType()))
                {
                    List<String> listValues = new List<String>();
                    foreach (var el in (IEnumerable<Object>)element.Value)
                    {
                        if (el.GetType() == typeof(Dictionary<String, Object>))
                            listValues.Add(formatDictionary((Dictionary<String, Object>)el));
                        else
                            listValues.Add("" + el);
                    }
                    value = "[ " + string.Join(",", listValues) + " ]"+"\n";
                }
                else if (element.Value.GetType() == typeof(Dictionary<String, Object>))
                    value = formatDictionary((Dictionary<String, Object>)element.Value );
                else if (IsPrimitiveType(element.Value.GetType()))
                    value = "\"" + element.Value + "\"";

                if ("_".Equals(element.Key))
                    results.Add(value);
                else
                    results.Add("\"" + element.Key + "\" : " + value);
            }
            if (results.Count > 1)
                return "{ " + string.Join(",", results) + " }";
            else
                return string.Join(",", results);
        }


    }
}

