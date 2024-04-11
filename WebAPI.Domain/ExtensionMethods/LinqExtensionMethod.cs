using WebAPI.Domain.Models;
using System.Collections.Generic;
using System;

namespace WebAPI.Domain.ExtensionMethods;

public sealed class LINQExtensionMethods
{
    #region Função de agregação do LINQ

    public string AgregateStrings(List<string> source)
    {
        return source.Aggregate((item, itemNext) => item + "," + itemNext);
    }

    public string JoinStrings(List<string> source)
    {
        return string.Join(",", source);
    }

    public int AgregateSum(List<int> source)
    {
        return source.Aggregate((item, itemNext) => item + itemNext);
    }

    public decimal AgregateAverage(List<int> source)
    {
        return source.Aggregate(
            seed: 0,
            func: (result, item) => result + item,
            resultSelector: result => (decimal)(result / source.Count)
        );
    }

    #endregion

    #region Funções de Quantificadores 

    public bool ValidateAllElements<T>(List<T> source, Func<T, bool> predicate)
    {
        // Se todos os Elementos Atender a condição predicate, será retornado TRUE. Senão FALSE
        return source.All(predicate); // predicate => x => x % 2 == 0
    }

    public bool ExistAnyElements<T>(List<T> source, Predicate<T> predicate)
    {
        // Se existir um Elemento que Atenda a condição predicate, será retornado TRUE. Senão FALSE
        return source.Exists(predicate); // predicate => x => x % 2 == 0
    }

    #endregion

    #region Remove os duplicados da lista source

    public List<DropDownList> GetDistinctBy(List<DropDownList> source)
    {
        return source.DistinctBy(p => p.Description, StringComparer.OrdinalIgnoreCase).ToList();
    }

    #endregion

    #region Retorna os elementos da lista source que não estão na lista itens

    public List<DropDownList> GetExceptBy(List<DropDownList> source, List<string> itens)
    {
        return source.ExceptBy(itens, p => p.Description, StringComparer.OrdinalIgnoreCase).ToList();
    }

    #endregion

    #region Retorna os elementos que são comuns em ambas as listas

    public List<DropDownList> GetIntersectBy(List<DropDownList> source, List<DropDownList> itens)
    {
        return source.IntersectBy(itens.Select(x => x.Description), p => p.Description, StringComparer.OrdinalIgnoreCase).ToList();
    }

    #endregion

    #region Faz a junção de ambos os conjuntos, sem geração de duplicidade

    public List<DropDownList> GetUnionBy(List<DropDownList> source, List<DropDownList> itens)
    {
        return source.UnionBy(itens, p => p.Description, StringComparer.OrdinalIgnoreCase).ToList();
    }

    #endregion

    public DropDownList GetMinValueFromList(List<DropDownList> list)
    {
        return list.MinBy(x => x.Id);
    }

    public DropDownList GetMaxValueFromList(List<DropDownList> list)
    {
        return list.MaxBy(x => x.Id);
    }

    public Dictionary<long, string> ConvertListToDictionary(List<DropDownList> list)
    {
        return list.ToDictionary(item => item.Id, item => item.Description);
    }

    public T GetFirstItemFromList<T>(List<T> list, Func<T, bool> predicate) where T : class
    {
        if (GuardClauses.ObjectIsNull(predicate))
            return list.FirstOrDefault();
        else
            return list.FirstOrDefault(predicate);
    }

    public T GetLastItemFromList<T>(List<T> list, Func<T, bool> predicate) where T : class
    {
        if (GuardClauses.ObjectIsNull(predicate))
            return list.LastOrDefault();
        else
            return list.LastOrDefault(predicate);
    }

    public int GetQtdItensFromList<T>(List<T> list, Func<T, bool> predicate) where T : class
    {
        if (GuardClauses.ObjectIsNull(predicate))
            return list.Count();
        else
            return list.Count(predicate);
    }

    public long GetQtdItensFromBigList<T>(List<T> list, Func<T, bool> predicate) where T : class
    {
        if (GuardClauses.ObjectIsNull(predicate))
            return list.LongCount();
        else
            return list.LongCount(predicate);
    }

    public decimal GetTotalItensFromList<T>(List<T> list, Func<T, decimal> predicate) where T : class
    {
        return list.Sum(predicate);
    }

    public List<T> GetFirstItensFromList<T>(List<T> list, int qtyItens) where T : class
    {
        return list.Take(qtyItens) as List<T>;
    }

    public List<T> GetLastItensFromList<T>(List<T> list, int qtyItens) where T : class
    {
        return list.TakeLast(qtyItens) as List<T>;
    }

    public List<T> RemoveItemFromList<T>(List<T> list, T item) where T : class
    {
        list.Remove(item);
        return list;
    }

    public List<T> RemoveAtItemFromList<T>(List<T> list, Predicate<T> predicate) where T : class
    {
        list.RemoveAll(predicate);
        return list;
    }

    public T GetElementFromListByIndex<T>(List<T> list, int index)
    {
        return list.ElementAtOrDefault(index);
    }

    public List<T> AddItemOnFirstPlaceOfList<T>(List<T> source, T item)
    {
        var newSource = source.Prepend<T>(item).ToList();
        return newSource;
    }

    public List<T> AddItemOnLastPlaceOfList<T>(List<T> source, T item)
    {
        var newSource = source.Append<T>(item).ToList();
        return newSource;
    }

    public List<string> ZipList(List<int> sourceId, List<string> sourceText)
    {
        // Se tiver a mesma quantidade de itens uma lista e a outra, vai combinar um resultado final numa nova lista
        var newSource = sourceId.Zip(sourceText, (Id, Text) => Id + " - " + Text).ToList();
        return newSource;
    }

    #region Lista do tipo IEnumerable é para somente leitura, onde não é possivel alterar os valores originais

    public IEnumerable<T> ConvertArrInIEnumerable<T>(T[] array) => array.AsEnumerable();

    public IEnumerable<T> ConvertListInIEnumerable<T>(List<T> list) => list.AsEnumerable();

    /// <summary>
    /// Metodo disponivel no NET 9
    /// </summary>
    //public (string resultado, int total) GetCountBy(List<DropDownList> list)
    //{
    //    var result = list.CountBy(p => p.Description);
    //    return (result.Key, result.Value);
    //}

    /// <summary>
    /// Metodo disponivel no NET 9
    /// </summary>
    //public (string resultado, int total) GetIndexFromList(List<DropDownList> list)
    //{
    //    var result = list.Index();
    //    return result;
    //}

    #endregion


    #region Função de ordenação do LINQ

    public List<T> GetListOrderAsc<T>(List<T> list)
    {
        return list.Order().ToList();
    }

    public List<DropDownList> GetListOrderByAsc(List<DropDownList> list)
    {
        return list.OrderBy(x => x.Id).ToList();
    }

    public List<DropDownList> GetListOrderByDesc(List<DropDownList> list)
    {
        return list.OrderByDescending(x => x.Id).ToList();
    }

    public List<T> GetListReverse<T>(List<T> list)
    {
        list.Reverse(); // Faz a inversão da ordem dos valores de uma lista
        return list;
    }

    public List<T> GetListSortAsc<T>(List<T> list)
    {
        list.Sort(); // Faz a ordenação da lista em ordem crescente, seguindo o algoritmo de quicksort
        return list.ToList();
    }

    #endregion

    public bool ListItensIsAllOk(List<DropDownList> source, Func<DropDownList, bool> predicate)
    {
        return source.TrueForAll(x => x.Id > 0);
    }

    public IEnumerable<DropDownList> GetChunkList(List<DropDownList> list, int pageIndex, int pageSize = 10)
    {
        return list.Chunk(pageSize).ElementAt(pageIndex).AsEnumerable();
    }
}


