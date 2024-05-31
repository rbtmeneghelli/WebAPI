using WebAPI.Domain.Enums;
using WebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.ExtensionMethods
{
    public class ListExtensionMethod
    {
        public Queue<T> ConvertListToQueue<T>(IEnumerable<T> list) => new Queue<T>(list);

        /// <summary>
        /// Faz a combinação dos itens da list1 e list2, em uma unica lista
        /// Esse procedimento a partir do NET 12 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public IEnumerable<T> CombineLists<T>(IEnumerable<T> list1, IEnumerable<T> list2) => [.. list1, .. list2];

        public T[] GetAllElements<T>(T[] list) => list[Range.All];

        public T[] GetAllElementsNFirsts<T>(T[] list, int numberOfElements) => list[..numberOfElements];

        public T[] GetAllElementsNLasts<T>(T[] list, int numberOfElements) => list[..^numberOfElements];

        public T[] GetAllElementsAfterNFirst<T>(T[] list, int numberOfElements) => list[numberOfElements..];

        public T[] GetAllElementsAfterNLast<T>(T[] list, int numberOfElements) => list[^numberOfElements..];

        public T[] GetReverseArray<T>(T[] array)
        {
            Array.Reverse(array);
            return array;
        }

        public IEnumerable<T> GetReverseList<T>(IEnumerable<T> list) => Enumerable.Reverse(list);

        public IEnumerable<T> ReturnListOrEmptyList<T>(IEnumerable<T> source) => source is not null ? source : Enumerable.Empty<T>();

        public IEnumerable<DropDownList> ConvertEnumToList<T>() where T : Enum
        {
            IEnumerable<DropDownList> list = Enum.GetValues(typeof(EnumSystem))
              .Cast<EnumSystem>()
              .Select(x => new DropDownList
              {
                  Id = ((long)x),
                  Description = x.ToString()
              });

            return list;
        }

        public IEnumerable<string> CloneList(List<string> list)
        {
            return list.GetRange(0, list.Count);
        }

        public IEnumerable<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex)
                        { throw new Exception(ex.Message, ex.InnerException); }
                    }
                }
                return objT;
            }).ToList();
        }

        public bool CompareLists(IEnumerable<int> listNumber, IEnumerable<int> listNumbers)
        {
            return listNumber.Except(listNumbers).Any() &&
            listNumbers.Except(listNumber).Any();
        }

        public bool CompareAllLinq(IEnumerable<int> numeros1, IEnumerable<int> numeros2)
        {
            bool isEqual = numeros1.All(numeros2.Contains)
                           && numeros2.All(numeros1.Contains);

            return isEqual;
        }
    }
}
