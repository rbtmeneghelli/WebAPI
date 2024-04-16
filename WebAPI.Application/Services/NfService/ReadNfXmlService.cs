using System.Xml;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Models.NFE.Classe;
using WebAPI.Domain.Models.NFE.Outros;

namespace WebAPI.Application.Services.NfService;

public class maptest
{
    public string text { get; set; }
    public int number { get; set; }
}
public class ReadNfXmlService : GenericNfService<NFE_Model>
{
    protected override IEnumerable<NFE_Model> ReadNf()
    {
        XmlDocument xmlDocument = new();
        xmlDocument.Load("path");
        List<XmlNodeList> listXml = new List<XmlNodeList>();

        foreach (string nfeTag in Enum.GetNames(typeof(EnumNfeTag)))
        {
            if (xmlDocument.GetElementsByTagName(nfeTag).Count > 0)
            {
                listXml.Add(xmlDocument.GetElementsByTagName(nfeTag));
            }
        }

        return PrintXml(listXml);
    }

    private string GetTagFromXML((string nodoName, int nodoLevel) nodoData)
    {
        var matrizXml = new string[0, 0];
        matrizXml[0, 0] = "16"; // primeira linha, coluna um
        matrizXml[0, 1] = "52"; // primeira linha, coluna dois
        matrizXml[1, 0] = "91"; // segunda linha, coluna um
        matrizXml[1, 1] = "43"; // segunda linha, coluna dois
        matrizXml[2, 0] = "77"; // terceira linha, coluna um
        matrizXml[2, 1] = "28"; // terceira linha, coluna dois
        //"2", "cNF" ,
        //"3", "natOp" ,
        //"4", "indPag" ,
        //"5", "mod" ,
        //"6", "serie" ,
        //"7", "nNF" ,
        //"8", "dEmi" ,
        //"9", "dSaiEnt" ,
        //"1", "tpNF" ,
        //"1", "cMunFG" ,
        //"1", "tpImp" ,
        //"1", "tpEmis" ,
        //"1", "cDV" ,
        //"1", "tpAmb" ,
        //"1", "finNFe" ,
        //"1", "procEmi" ,
        //"1", "verProc" ,
    };

    dictionary.TryGetValue(nodoData, out var result);
        return result ?? string.Empty;
    }

private string GetValueFromXML(XmlElement nodo, string tagName)
{
    if (string.IsNullOrWhiteSpace(tagName))
        return "Vazio";

    string value = nodo.GetElementsByTagName(tagName)[0].InnerText.Trim();
    return string.IsNullOrEmpty(value) ? "Vazio" : value;
}


protected IEnumerable<NFE_Model> PrintXml(List<XmlNodeList> listXml)
{
    foreach (XmlNodeList xnl in listXml)
    {
        foreach (XmlElement nodo in xnl)
        {
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),
            //EnumNfeTag.ide.GetDisplayShortName(),

            string value = GetValueFromXML(nodo, GetData_IDE_FromXML(nodo.Name));

            if (nodo.Name == "emit")
            {
                objEmit.CNPJ = nodo.GetElementsByTagName("CNPJ")[0].InnerText.Trim();
                objEmit.xNome = nodo.GetElementsByTagName("xNome")[0].InnerText.Trim();
                objEmit.xFant = nodo.GetElementsByTagName("xFant")[0].InnerText.Trim();
                objEmit.xLgr = nodo.GetElementsByTagName("xLgr")[0].InnerText.Trim();
                objEmit.nro = nodo.GetElementsByTagName("nro")[0].InnerText.Trim();
                objEmit.xCpl = nodo.GetElementsByTagName("xCpl")[0].InnerText.Trim();
                objEmit.xBairro = nodo.GetElementsByTagName("xBairro")[0].InnerText.Trim();
                objEmit.cMun = nodo.GetElementsByTagName("cMun")[0].InnerText.Trim();
                objEmit.xMun = nodo.GetElementsByTagName("xMun")[0].InnerText.Trim();
                objEmit.UF = nodo.GetElementsByTagName("UF")[0].InnerText.Trim();
                objEmit.CEP = nodo.GetElementsByTagName("CEP")[0].InnerText.Trim();
                objEmit.cPais = nodo.GetElementsByTagName("cPais")[0].InnerText.Trim();
                objEmit.xPais = nodo.GetElementsByTagName("xPais")[0].InnerText.Trim();
                objEmit.fone = nodo.GetElementsByTagName("fone")[0].InnerText.Trim();
                objEmit.IE = nodo.GetElementsByTagName("IE")[0].InnerText.Trim();
            }

            else if (nodo.Name == "dest")
            {
                objDest.CNPJ = nodo.GetElementsByTagName("CNPJ")[0].InnerText.Trim();
                objDest.xNome = nodo.GetElementsByTagName("xNome")[0].InnerText.Trim();
                objDest.xLgr = nodo.GetElementsByTagName("xLgr")[0].InnerText.Trim();
                objDest.nro = nodo.GetElementsByTagName("nro")[0].InnerText.Trim();
                objDest.xCpl = nodo.GetElementsByTagName("xCpl")[0].InnerText.Trim();
                objDest.xBairro = nodo.GetElementsByTagName("xBairro")[0].InnerText.Trim();
                objDest.cMun = nodo.GetElementsByTagName("cMun")[0].InnerText.Trim();
                objDest.xMun = nodo.GetElementsByTagName("xMun")[0].InnerText.Trim();
                objDest.UF = nodo.GetElementsByTagName("UF")[0].InnerText.Trim();
                objDest.CEP = nodo.GetElementsByTagName("CEP")[0].InnerText.Trim();
                objDest.cPais = nodo.GetElementsByTagName("cPais")[0].InnerText.Trim();
                objDest.xPais = nodo.GetElementsByTagName("xPais")[0].InnerText.Trim();
                objDest.fone = nodo.GetElementsByTagName("fone")[0].InnerText.Trim();
                objDest.IE = nodo.GetElementsByTagName("IE")[0].InnerText.Trim();
            }

            else if (nodo.Name == "retirada")
            {
                objRet.CNPJ = nodo.GetElementsByTagName("CNPJ")[0].InnerText.Trim();
                objRet.xLgr = nodo.GetElementsByTagName("xLgr")[0].InnerText.Trim();
                objRet.nro = nodo.GetElementsByTagName("nro")[0].InnerText.Trim();
                objRet.xCpl = nodo.GetElementsByTagName("xCpl")[0].InnerText.Trim();
                objRet.xBairro = nodo.GetElementsByTagName("xBairro")[0].InnerText.Trim();
                objRet.cMun = nodo.GetElementsByTagName("cMun")[0].InnerText.Trim();
                objRet.xMun = nodo.GetElementsByTagName("xMun")[0].InnerText.Trim();
                objRet.UF = nodo.GetElementsByTagName("UF")[0].InnerText.Trim();
            }

            else if (nodo.Name == "entrega")
            {
                objEntr.CNPJ = nodo.GetElementsByTagName("CNPJ")[0].InnerText.Trim();
                objEntr.xLgr = nodo.GetElementsByTagName("xLgr")[0].InnerText.Trim();
                objEntr.nro = nodo.GetElementsByTagName("nro")[0].InnerText.Trim();
                objEntr.xCpl = nodo.GetElementsByTagName("xCpl")[0].InnerText.Trim();
                objEntr.xBairro = nodo.GetElementsByTagName("xBairro")[0].InnerText.Trim();
                objEntr.cMun = nodo.GetElementsByTagName("cMun")[0].InnerText.Trim();
                objEntr.xMun = nodo.GetElementsByTagName("xMun")[0].InnerText.Trim();
                objEntr.UF = nodo.GetElementsByTagName("UF")[0].InnerText.Trim();
            }

            else if (nodo.Name == "transp")
            {
                //Conta a quantidade de tags filhos dentro do pai
                countXmlNodes = nodo.ChildNodes.Count;

                for (int i = 0; i < countXmlNodes; i++)
                {
                    switch (nodo.ChildNodes[i].Name)
                    {
                        case "modFrete":
                            objTransp.modFrete = nodo.GetElementsByTagName("modFrete")[0].InnerText.Trim();
                            break;

                        case "transporta":
                            objTransp.transporta = new Transporte.Transporta()
                            {
                                CNPJ = nodo.GetElementsByTagName("placa")[0].InnerText.Trim(),
                                xNome = nodo.GetElementsByTagName("xNome")[0].InnerText.Trim(),
                                IE = nodo.GetElementsByTagName("IE")[0].InnerText.Trim(),
                                xEnder = nodo.GetElementsByTagName("xEnder")[0].InnerText.Trim(),
                                xMun = nodo.GetElementsByTagName("xMun")[0].InnerText.Trim(),
                                UF = nodo.GetElementsByTagName("UF")[0].InnerText.Trim()
                            };
                            break;

                        case "veicTransp":
                            objTransp.veicTransp = new Transporte.VeicTransp()
                            {
                                placa = nodo.GetElementsByTagName("placa")[0].InnerText.Trim(),
                                RNTC = nodo.GetElementsByTagName("RNTC")[0].InnerText.Trim(),
                                UF = nodo.GetElementsByTagName("UF")[0].InnerText.Trim()
                            };
                            break;

                        case "reboque":
                            objTransp.reboque = new Transporte.Reboque()
                            {
                                placa = nodo.GetElementsByTagName("placa")[0].InnerText.Trim(),
                                RNTC = nodo.GetElementsByTagName("RNTC")[0].InnerText.Trim(),
                                UF = nodo.GetElementsByTagName("UF")[0].InnerText.Trim()
                            };
                            break;

                        case "vol":
                            objTransp.vol = new Transporte.Vol()
                            {
                                qVol = nodo.GetElementsByTagName("qVol")[0].InnerText.Trim(),
                                esp = nodo.GetElementsByTagName("esp")[0].InnerText.Trim(),
                                marca = nodo.GetElementsByTagName("marca")[0].InnerText.Trim(),
                                nVol = nodo.GetElementsByTagName("nVol")[0].InnerText.Trim(),
                                pesoL = nodo.GetElementsByTagName("pesoL")[0].InnerText.Trim(),
                                pesoB = nodo.GetElementsByTagName("pesoB")[0].InnerText.Trim(),
                                lacre = new Transporte.Lacres()
                                {
                                    nLacre = nodo.GetElementsByTagName("nLacre")[0].InnerText.Trim()
                                }
                            };
                            break;
                    }
                }
            }

            else if (nodo.Name == "infAdic")
            {
                objInfAdic.infAdFisco = nodo.GetElementsByTagName("infAdFisco")[0].InnerText.Trim();
            }

            else if (nodo.Name == "det")
            {

                //Conta a quantidade de tags filhos dentro do pai
                countXmlNodes = nodo.ChildNodes.Count;

                for (int i = 0; i < countXmlNodes; i++)
                {
                    switch (nodo.ChildNodes[i].Name)
                    {
                        case "prod":
                            listaProd.Add(new Prod()
                            {
                                cProd = nodo.GetElementsByTagName("cProd")[0].InnerText.Trim(),
                                xProd = nodo.GetElementsByTagName("xProd")[0].InnerText.Trim(),
                                CFOP = nodo.GetElementsByTagName("CFOP")[0].InnerText.Trim(),
                                uCom = nodo.GetElementsByTagName("uCom")[0].InnerText.Trim(),
                                qCom = nodo.GetElementsByTagName("qCom")[0].InnerText.Trim(),
                                vUnCom = nodo.GetElementsByTagName("vUnCom")[0].InnerText.Trim(),
                                vProd = nodo.GetElementsByTagName("vProd")[0].InnerText.Trim(),
                                uTrib = nodo.GetElementsByTagName("uTrib")[0].InnerText.Trim(),
                                qTrib = nodo.GetElementsByTagName("qTrib")[0].InnerText.Trim(),
                                vUnTrib = nodo.GetElementsByTagName("vUnTrib")[0].InnerText.Trim()
                            });
                            break;
                        case "imposto":
                            xmlNode = nodo.ChildNodes[i];

                            foreach (XmlElement novoNodo in xmlNode)
                            {
                                if (novoNodo.Name == "ICMS")
                                    listaICMS.AddRange(objTributo.TribICMS(novoNodo));

                                else if (novoNodo.Name == "PIS")
                                    listaPIS.AddRange(objTributo.TribPIS(novoNodo));

                                else if (novoNodo.Name == "COFINS")
                                    listaCOFINS.AddRange(objTributo.TribCOFINS(novoNodo));
                            }

                            break;
                    }
                }
            }

            else if (nodo.Name == "total")
            {
                //Conta a quantidade de tags filhos dentro do pai
                countXmlNodes = nodo.ChildNodes.Count;

                for (int i = 0; i < countXmlNodes; i++)
                {
                    switch (nodo.ChildNodes[i].Name)
                    {

                        case "ICMSTot":

                            objTotal.TotalICMS = new Total.ICMSTot()
                            {
                                vBC = nodo.GetElementsByTagName("vBC")[0].InnerText.Trim(),
                                vICMS = nodo.GetElementsByTagName("vICMS")[0].InnerText.Trim(),
                                vBCST = nodo.GetElementsByTagName("vBCST")[0].InnerText.Trim(),
                                vST = nodo.GetElementsByTagName("vST")[0].InnerText.Trim(),
                                vProd = nodo.GetElementsByTagName("vProd")[0].InnerText.Trim(),
                                vFrete = nodo.GetElementsByTagName("vFrete")[0].InnerText.Trim(),
                                vSeg = nodo.GetElementsByTagName("vSeg")[0].InnerText.Trim(),
                                vDesc = nodo.GetElementsByTagName("vDesc")[0].InnerText.Trim(),
                                vII = nodo.GetElementsByTagName("vII")[0].InnerText.Trim(),
                                vIPI = nodo.GetElementsByTagName("vIPI")[0].InnerText.Trim(),
                                vPIS = nodo.GetElementsByTagName("vPIS")[0].InnerText.Trim(),
                                vCOFINS = nodo.GetElementsByTagName("vCOFINS")[0].InnerText.Trim(),
                                vOutro = nodo.GetElementsByTagName("vOutro")[0].InnerText.Trim(),
                                vNF = nodo.GetElementsByTagName("vNF")[0].InnerText.Trim()
                            };

                            break;
                    }
                }
            }

        } //Fim do foreach
    } //Fim do foreach

    //Montagem da NFE
    return Enumerable.Empty<NFE_Model>();
}
}
