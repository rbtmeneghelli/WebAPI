using WebAPI.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.ExtensionMethods
{
    public class SqlExtensionMethod
    {
        #region Metodos Privados para criar Script de Insert/Update de forma customizada

        /// <summary>
        /// procura nos atributos do tipo ex: typeof(Pessoa)
        /// um atributo do tipo "TabelaAtributo"
        /// retorna o nome da tabela se achar
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private string GetTable(Type type)
        {
            TbAttribute table;
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            if (attributes is not null)
            {
                if (attributes.Any(x => x is TbAttribute))
                {
                    table = (TbAttribute)attributes.FirstOrDefault(x => x is TbAttribute);
                    return table.Name;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// método que recebe um tipo
        /// pega os membros desse tipo e lê atributos custom
        /// para retornar o nome do campo (retorna num list de campo)
        /// </summary>

        private List<AuxFieldsAttribute> GetFields(Type type)
        {
            List<AuxFieldsAttribute> auxFieldsAttributesList = new List<AuxFieldsAttribute>();
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo member in members)
            {
                object[] attributes = member.GetCustomAttributes(true);
                if (member.MemberType == MemberTypes.Property)
                {
                    if (attributes.Length != 0)
                    {
                        foreach (object attribute in attributes)
                        {
                            if (attribute is FieldAttribute)
                            {
                                FieldAttribute fieldAttribute = (FieldAttribute)attribute;
                                AuxFieldsAttribute auxFieldsAttribute =
                                new AuxFieldsAttribute(fieldAttribute.Key, fieldAttribute.Name, fieldAttribute.Name.ToString());
                                auxFieldsAttributesList.Add(auxFieldsAttribute);
                            }
                        }
                    }

                }

            }
            return auxFieldsAttributesList;
        }

        // este método aceita como parâmetro Generics
        // ele pega as propriedades do objeto t e as percorre
        // pra cada propriedade, ele procura na list passada como parâmetro
        // um campo com mesma "Propriedade" (que é o nome do campo)
        // se achou, adiciona o valor na propria list que é ref e cai fora

        private void GetProperties<TEntity>(TEntity objectFromClassT, ref List<AuxFieldsAttribute> auxFieldsAttributesList)
        {
            Type type = typeof(TEntity);
            var properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                for (int i = 0; i < auxFieldsAttributesList.Count; i++)
                {
                    if (auxFieldsAttributesList[i].Property.Equals(property.Name))
                    {
                        auxFieldsAttributesList[i].Value = property.GetValue(objectFromClassT, null).ToString();
                        break;
                    }
                }
            }
        }

        #endregion

        #region Metodos para criar Script de Insert/Update/Delete de forma customizada e Gerador de chave aleatoria

        public string CreateSQLInsertScript<TEntity>(TEntity objectFromClassT, Type type)
        {
            StringBuilder valuesStr = new StringBuilder();
            StringBuilder fieldStr = new StringBuilder();
            List<AuxFieldsAttribute> fields = GetFields(type);
            GetProperties(objectFromClassT, ref fields);

            foreach (AuxFieldsAttribute field in fields)
            {
                fieldStr.Append(field.Name + ",");
                valuesStr.Append(field.Value + ",");
            }

            valuesStr.Remove(valuesStr.Length - 1, 1);
            fieldStr.Remove(fieldStr.Length - 1, 1);

            return $"insert into {GetTable(type)} ({fieldStr.ToString()}) values({valuesStr.ToString()})";
        }

        public string CreateSQLUpdateScript<TEntity>(TEntity objectFromClassT, Type type)
        {
            StringBuilder keyStr = new StringBuilder();
            StringBuilder fieldStr = new StringBuilder();
            List<AuxFieldsAttribute> fields = GetFields(type);
            GetProperties(objectFromClassT, ref fields);

            foreach (AuxFieldsAttribute field in fields)
            {
                if (field.Key)
                    keyStr.Append(field.Name + "=" + field.Value + " and ");
                else
                    fieldStr.Append(field.Name + "=" + field.Value + ",");
            }

            keyStr.Remove(keyStr.Length - 5, 5);
            fieldStr.Remove(fieldStr.Length - 1, 1);
            return $"update {GetTable(type)} set {fieldStr.ToString()} where {keyStr.ToString()}";
        }

        public string CreateSQLDeleteScript<TEntity>(TEntity objectFromClassT, Type type)
        {
            StringBuilder keyStr = new StringBuilder();
            List<AuxFieldsAttribute> fields = GetFields(type);
            GetProperties(objectFromClassT, ref fields);

            foreach (AuxFieldsAttribute field in fields)
            {
                if (field.Key)
                    keyStr.Append(field.Name + "=" + field.Value + " and ");
            }

            keyStr.Remove(keyStr.Length - 5, 5);
            return $"delete from {GetTable(type)} where {keyStr.ToString()}";
        }

        private string CreateRandomKey(int maxKeyLength = 10)
        {
            string sql = $"select substring(TRIM(REPLACE(CONVERT(VARCHAR(50),NEWID()),'-','')),1,{maxKeyLength})";
            return sql;
        }

        #endregion
    }
}
