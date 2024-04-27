using System.Xml;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Models.NFE.Classe;
using WebAPI.Domain.Models.NFE.Impostos;
using WebAPI.Domain.Models.NFE.Total;
using WebAPI.Domain.Models.NFE.Transporte;

namespace WebAPI.Application.Services.NfService;

public sealed class ReadNfXmlService : GenericNfService<NFE_Model>
{
    private string GetMatrizValue(int row, int column)
    {
        var matrizXml = new string[0, 0];
        matrizXml[0, 0] = "cUF";
        matrizXml[0, 1] = "cNF";
        matrizXml[0, 2] = "natOp";
        matrizXml[0, 3] = "indPag";
        matrizXml[0, 4] = "mod";
        matrizXml[0, 5] = "serie";
        matrizXml[0, 6] = "nNF";
        matrizXml[0, 7] = "dEmi";
        matrizXml[0, 8] = "dSaiEnt";
        matrizXml[0, 9] = "tpNF";
        matrizXml[0, 10] = "cMunFG";
        matrizXml[0, 11] = "tpImp";
        matrizXml[0, 12] = "tpEmis";
        matrizXml[0, 13] = "cDV";
        matrizXml[0, 14] = "tpAmb";
        matrizXml[0, 15] = "finNFe";
        matrizXml[0, 16] = "procEmi";
        matrizXml[0, 17] = "verProc";

        matrizXml[1, 0] = "CNPJ";
        matrizXml[1, 1] = "xNome";
        matrizXml[1, 2] = "xFant";
        matrizXml[1, 3] = "xLgr";
        matrizXml[1, 4] = "nro";
        matrizXml[1, 5] = "xCpl";
        matrizXml[1, 6] = "xBairro";
        matrizXml[1, 7] = "cMun";
        matrizXml[1, 8] = "xMun";
        matrizXml[1, 9] = "UF";
        matrizXml[1, 10] = "CEP";
        matrizXml[1, 11] = "cPais";
        matrizXml[1, 12] = "xPais";
        matrizXml[1, 13] = "fone";
        matrizXml[1, 14] = "IE";

        matrizXml[2, 0] = "CNPJ";
        matrizXml[2, 1] = "xNome";
        matrizXml[2, 2] = "xLgr";
        matrizXml[2, 3] = "nro";
        matrizXml[2, 4] = "xCpl";
        matrizXml[2, 5] = "xBairro";
        matrizXml[2, 6] = "cMun";
        matrizXml[2, 7] = "xMun";
        matrizXml[2, 8] = "UF";
        matrizXml[2, 9] = "CEP";
        matrizXml[2, 10] = "cPais";
        matrizXml[2, 11] = "xPais";
        matrizXml[2, 12] = "fone";
        matrizXml[2, 13] = "IE";

        matrizXml[3, 0] = "CNPJ";
        matrizXml[3, 1] = "xLgr";
        matrizXml[3, 2] = "nro";
        matrizXml[3, 3] = "xCpl";
        matrizXml[3, 4] = "xBairro";
        matrizXml[3, 5] = "cMun";
        matrizXml[3, 6] = "xMun";
        matrizXml[3, 7] = "UF";

        matrizXml[4, 0] = "CNPJ";
        matrizXml[4, 1] = "xLgr";
        matrizXml[4, 2] = "nro";
        matrizXml[4, 3] = "xCpl";
        matrizXml[4, 4] = "xBairro";
        matrizXml[4, 5] = "cMun";
        matrizXml[4, 6] = "xMun";
        matrizXml[4, 7] = "UF";

        matrizXml[5, 0] = "modFrete";
        matrizXml[5, 1] = "CNPJ";
        matrizXml[5, 2] = "xNome";
        matrizXml[5, 3] = "IE";
        matrizXml[5, 4] = "xEnder";
        matrizXml[5, 5] = "xMun";
        matrizXml[5, 6] = "UF";
        matrizXml[5, 7] = "placa";
        matrizXml[5, 8] = "RNTC";
        matrizXml[5, 9] = "qVol";
        matrizXml[5, 10] = "esp";
        matrizXml[5, 11] = "marca";
        matrizXml[5, 12] = "nVol";
        matrizXml[5, 13] = "pesoL";
        matrizXml[5, 14] = "pesoB";
        matrizXml[5, 15] = "nLacre";

        matrizXml[6, 0] = "infAdFisco";

        matrizXml[7, 0] = "cProd";
        matrizXml[7, 1] = "xProd";
        matrizXml[7, 2] = "CFOP";
        matrizXml[7, 3] = "uCom";
        matrizXml[7, 4] = "qCom";
        matrizXml[7, 5] = "vUnCom";
        matrizXml[7, 6] = "vProd";
        matrizXml[7, 7] = "uTrib";
        matrizXml[7, 8] = "qTrib";
        matrizXml[7, 9] = "vUnTrib";
        matrizXml[7, 10] = "orig";
        matrizXml[7, 11] = "CST";

        matrizXml[8, 0] = "vBC";
        matrizXml[8, 1] = "vICMS";
        matrizXml[8, 2] = "vBCST";
        matrizXml[8, 3] = "vST";
        matrizXml[8, 4] = "vProd";
        matrizXml[8, 5] = "vFrete";
        matrizXml[8, 6] = "vSeg";
        matrizXml[8, 7] = "vDesc";
        matrizXml[8, 8] = "vII";
        matrizXml[8, 9] = "vIPI";
        matrizXml[8, 10] = "vPIS";
        matrizXml[8, 11] = "vCOFINS";
        matrizXml[8, 12] = "vOutro";
        matrizXml[8, 13] = "vNF";

        return matrizXml[row, column];
    }

    private string GetValueFromXML(XmlElement nodo, string tagName)
    {
        if (string.IsNullOrWhiteSpace(tagName))
            return "Vazio";

        string value = nodo.GetElementsByTagName(tagName)[0].InnerText.Trim();
        return string.IsNullOrEmpty(value) ? "Vazio" : value;
    }

    private NFE_Transp GetDataTransportadoraFromXML(XmlElement nodo)
    {
        NFE_Transp dadosTransportadora = new();

        //Conta a quantidade de tags filhos dentro do pai
        int countXmlNodes = nodo.ChildNodes.Count;

        for (int i = 0; i < countXmlNodes; i++)
        {
            switch (nodo.ChildNodes[i].Name)
            {
                case "modFrete":
                    dadosTransportadora.ModFrete = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 0));
                    break;
                case "transporta":
                    dadosTransportadora.Transporta = new NFE_Transporta()
                    {
                        Cnpj = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 1)),
                        Nome = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 2)),
                        IE = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 3)),
                        Endereco = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 4)),
                        Municipio = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 5)),
                        UF = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 6))
                    };
                    break;
                case "veicTransp":
                    dadosTransportadora.VeicTransp = new NFE_VeicTransp()
                    {
                        Placa = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 7)),
                        RNTC = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 8)),
                        UF = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 6))
                    };
                    break;
                case "reboque":
                    dadosTransportadora.Reboque = new NFE_Reboque
                    {
                        Placa = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 7)),
                        RNTC = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 8)),
                        UF = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 6))
                    };
                    break;
                case "vol":
                    dadosTransportadora.Vol = new NFE_Vol()
                    {
                        Qvol = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 9)),
                        Esp = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 10)),
                        Marca = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 11)),
                        Nvol = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 12)),
                        PesoL = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 13)),
                        PesoB = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 14)),
                        Lacre = new NFE_Lacre()
                        {
                            Nlacre = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.transp, 15)),
                        }
                    };
                    break;
            }
        }

        return dadosTransportadora;
    }

    private NFE_Imposto GetDataImpostoFromXML(XmlElement nodo)
    {
        NFE_Imposto dadosImposto = new();
        dadosImposto.Produto = new();
        dadosImposto.ICMS = new();
        dadosImposto.PIS = new();
        dadosImposto.COFINS = new();

        List<NFE_Produto> produtos = new();
        List<NFE_ICMS> listaICMS = new();
        List<NFE_PIS> listaPIS = new();
        List<NFE_COFINS> listaCOFINS = new();

        NFE_ICMS imposto_ICMS = new();
        NFE_PIS imposto_PIS = new();
        NFE_COFINS imposto_COFINS = new();

        //Conta a quantidade de tags filhos dentro do pai
        int countXmlNodes = nodo.ChildNodes.Count;

        for (int i = 0; i < countXmlNodes; i++)
        {
            switch (nodo.ChildNodes[i].Name)
            {
                case "prod":
                    produtos.Add(new NFE_Produto()
                    {
                        Produto_Cprod = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 0)),
                        Produto_Xprod = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 1)),
                        Produto_Cfop = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 2)),
                        Produto_Ucom = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 3)),
                        Produto_Qcom = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 4)),
                        Produto_Vuncom = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 5)),
                        Produto_Vprod = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 6)),
                        Produto_Utrib = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 7)),
                        Produto_Qtrib = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 8)),
                        Produto_Vuntrib = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.det, 9))
                    });
                    break;
                case "imposto":
                    var xmlNode = nodo.ChildNodes[i];

                    foreach (XmlElement novoNodo in xmlNode)
                    {
                        foreach (XmlElement nodoImposto in novoNodo)
                        {
                            switch (nodoImposto.Name)
                            {
                                case "ICMS00":
                                case "ICMS40":
                                case "ICMS50":
                                case "ICMS60":
                                    imposto_ICMS.Icms_Orig = GetValueFromXML(nodoImposto, GetMatrizValue((int)EnumNfeTag.det, 10));
                                    listaICMS.Add(new NFE_ICMS() { Icms_Tipo = nodoImposto.Name, Icms_Orig = imposto_ICMS.Icms_Orig });
                                    imposto_ICMS = new();
                                    break;
                                case "PISAliq":
                                    imposto_PIS.Pis_CST = GetValueFromXML(nodoImposto, GetMatrizValue((int)EnumNfeTag.det, 11));
                                    listaPIS.Add(new NFE_PIS() { Pis_Tipo = nodoImposto.Name, Pis_CST = imposto_ICMS.Icms_Cst });
                                    imposto_PIS = new();
                                    break;
                                case "COFINSAliq":
                                    imposto_COFINS.Cofins_Cst = GetValueFromXML(nodoImposto, GetMatrizValue((int)EnumNfeTag.det, 11));
                                    listaCOFINS.Add(new NFE_COFINS() { Cofins_Tipo = nodoImposto.Name, Cofins_Cst = imposto_COFINS.Cofins_Cst });
                                    imposto_COFINS = new();
                                    break;
                            }
                        }
                    }

                    break;
            }
        }

        dadosImposto.Produto = produtos;
        dadosImposto.ICMS = listaICMS;
        dadosImposto.PIS = listaPIS;
        dadosImposto.COFINS = listaCOFINS;

        return dadosImposto;
    }

    private NFE_IcmsTot GetDataICMSTotFromXML(XmlElement nodo)
    {
        NFE_IcmsTot dadosIcmsTot = new();

        //Conta a quantidade de tags filhos dentro do pai
        int countXmlNodes = nodo.ChildNodes.Count;

        for (int i = 0; i < countXmlNodes; i++)
        {
            switch (nodo.ChildNodes[i].Name)
            {
                case "ICMSTot":
                    dadosIcmsTot = new NFE_IcmsTot()
                    {
                        Vbc = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 0)),
                        Vicms = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 1)),
                        Vbcst = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 2)),
                        Vst = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 3)),
                        Vprod = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 4)),
                        Vfrete = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 5)),
                        Vseg = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 6)),
                        Vdesc = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 7)),
                        Vii = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 8)),
                        Vipi = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 9)),
                        Vpis = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 10)),
                        Vcofins = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 11)),
                        Voutro = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 12)),
                        Vnf = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.total, 13)),
                    };
                    break;
            }
        }

        return dadosIcmsTot;
    }

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

    private IEnumerable<NFE_Model> PrintXml(List<XmlNodeList> listXml)
    {
        string valueIde = FixConstants.GetEmptyString();
        string valueEmit = FixConstants.GetEmptyString();
        string valueDest = FixConstants.GetEmptyString();
        string valueRetirada = FixConstants.GetEmptyString();
        string valueEntrega = FixConstants.GetEmptyString();
        string valueInfAdic = FixConstants.GetEmptyString();

        NFE_Transp dadosTransportadora;
        NFE_Imposto dadosImposto;
        NFE_IcmsTot dadosIcmsTot;
        NFE_Model nFE_Model = new();

        foreach (XmlNodeList xnl in listXml)
        {
            foreach (XmlElement nodo in xnl)
            {
                if (nodo.Name.Equals(EnumNfeTag.ide.GetDisplayName()))
                {
                    valueIde = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.ide, 0));
                }
                else if (nodo.Name.Equals(EnumNfeTag.emit.GetDisplayName()))
                {
                    valueEmit = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.emit, 0));
                }
                else if (nodo.Name.Equals(EnumNfeTag.dest.GetDisplayName()))
                {
                    valueDest = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.dest, 0));
                }
                else if (nodo.Name.Equals(EnumNfeTag.retirada.GetDisplayName()))
                {
                    valueRetirada = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.retirada, 0));
                }
                else if (nodo.Name.Equals(EnumNfeTag.entrega.GetDisplayName()))
                {
                    valueEntrega = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.entrega, 0));
                }
                else if (nodo.Name.Equals(EnumNfeTag.transp.GetDisplayName()))
                {
                    dadosTransportadora = GetDataTransportadoraFromXML(nodo);
                }
                else if (nodo.Name.Equals(EnumNfeTag.infAdic.GetDisplayName()))
                {
                    valueInfAdic = GetValueFromXML(nodo, GetMatrizValue((int)EnumNfeTag.infAdic, 0));
                }
                else if (nodo.Name.Equals(EnumNfeTag.det.GetDisplayName()))
                {
                    dadosImposto = GetDataImpostoFromXML(nodo);
                }
                else if (nodo.Name.Equals(EnumNfeTag.total.GetDisplayName()))
                {
                    dadosIcmsTot = GetDataICMSTotFromXML(nodo);
                }
            }
        }

        //Montagem da NFE
        return Enumerable.Empty<NFE_Model>();
    }
}
