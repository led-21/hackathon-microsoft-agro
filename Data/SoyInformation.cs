using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace hackaton_microsoft_agro.Data
{
    public static class SoyInformation
    {

        public static string TEMPLATE = """
                                    Example template:
                                        Data Platio: 12/11/2025
                                        Sistema de semeadura: Plantio Direto
                                        Tecnologia de semeadura: Semeadora com sistema de distribuição de sementes a vácuo
                                        Cultura anterior: Braquiária
                                        Espaçamento entre linhas: 0.45 cm 
                                        Área útil: 100 ha
                                        Delineamento e Número de repetições: Blocos casualizados com três repetições
                                        Adubação de Manutenção: 340 kg ha-1 NPK (02-20-20)
                                        Tratamento de sementes: Standak Top (100ml/50 kg sementes-1) 
                                        Coinoculação de sementes: Inoculante líquido, via sulco - Bradyrhizobium (4 doses) + 
                                        Azospirillum (1 dose)
                                        Pragas: Tamanduá-da-soja, lagartas e percevejos
                                        Fungicidas: 
                                            1ª – Picoxistrobina + ciproconazol (0,35 L ha-1 p.c.) 
                                            2ª – Epoxiconazol + fluxapiroxade + piraclostrobina (0,8 L ha-1 p.c.)
                                            3ª – Fluxapiroxade + piraclostrobina (0,3 L ha-1 p.c.)
                                            4ª – Picoxistrobina + ciproconazol (0,35 L ha-1 p.c.) 
                                            5ª – Picoxistrobina + ciproconazol (0,35 L ha-1 p.c.) + mancozebe (1,2 kg ha-1 p.c.)
                                            6ª – Picoxistrobina + ciproconazol (0,35 L ha-1 p.c.)
                                         Data de Colheita: 100 a 120 do platio
                                         Sistema de colheita: Mecânica
                                    """;

        public static string SOIL_FERTILITY = """
                    Calagem: A quantidade de calcário a ser utilizada pode ser calculada pelo critério do Al 3+ e do Ca2+ + Mg2+ , levando em consideração o valor de Y, variável em função da capacidade tampão da acidez do solo, X = 2 e mt = 20 % ou pelo critério da saturação por bases, para elevá-la a 45 a 50 %. 

                    A adubação nitrogenada pode ser eliminada, desde que se faça uma inoculação adequada das sementes. 

                    Recomenda dose Fosforo:
                        Disponibilidade Fosforo: 
                              Baixa 120 kg/ha
                              Média 80 kg/ha
                              Boa 40 kg/ha
                    
                    Recomenda dose Potassio:
                        Disponibilidade Potassio: 
                              Baixa 120 kg/ha
                              Média 80 kg/ha
                              Boa 40 kg/ha

                    Enxofre: a resposta ao enxofre tem ocorrido com freqüência, embora com pequena magnitude, em áreas de cerrado que têm sido cultivadas com soja, por diversos anos, apenas com a utilização de fórmulas concentradas do tipo 0-30-15, que não têm S em sua composição. Resultados experimentais têm mostrado que a aplicação de 30 kg/ha de S, no sulco de plantio, é bastante para a correção da deficiência, quando esta ocorre. A análise de rotina para este elemento é feita apenas quando.
            """;

        public static string SEEDS = """
                            BMX-COMPACTA-IPRO 88,3 sc/ha
                            SYN15640-IPRO 87,3 sc/ha
                            DM66i68RSF-IPRO 84,3 sc/ha
                            HO-TERERÊ-IPRO 83,9 sc/ha
                            AS3590-IPRO 83,9 sc/ha
                            NS7709-IPRO 83,7 sc/ha
                            TEC6702-IPRO 78,1 sc/ha
                            96R20-IPRO 78,1 sc/ha
                            AS3680-IPRO 78,1 sc/ha
                            M5947-IPRO 78,0 sc/ha
                            M6210-IPRO 77,9 sc/ha
                            TEC7849-IPRO 77,9 sc/ha
            """;


        public static string HERBICIDES = """
                      [
            {
              "id": 11,
              "registrationNumber": "1215",
              "commercialBrand": "2,4-D 806 RN",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Euphorbia heterophylla",
              "pestCommonName": "\"amendoim-bravo"
            },
            {
              "id": 23,
              "registrationNumber": "1215",
              "commercialBrand": "2,4-D 806 RN",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Sonchus oleraceus",
              "pestCommonName": "\"chicaria-brava"
            },
            {
              "id": 27,
              "registrationNumber": "315",
              "commercialBrand": "2,4-D 806 SL AGCN",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Euphorbia heterophylla",
              "pestCommonName": "\"amendoim-bravo"
            },
            {
              "id": 35,
              "registrationNumber": "6715",
              "commercialBrand": "2,4-D 806 SL Alamos",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Euphorbia heterophylla",
              "pestCommonName": "\"amendoim-bravo"
            },
            {
              "id": 45,
              "registrationNumber": "6715",
              "commercialBrand": "2,4-D 806 SL Alamos",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Sonchus oleraceus",
              "pestCommonName": "\"chicaria-brava"
            },
            {
              "id": 50,
              "registrationNumber": "19524",
              "commercialBrand": "2,4-D 806 SL CHDS",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Euphorbia heterophylla",
              "pestCommonName": "\"amendoim-bravo"
            },
            {
              "id": 67,
              "registrationNumber": "41418",
              "commercialBrand": "2,4-D Agroimport",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Amaranthus spinosus",
              "pestCommonName": "\"bredo-branco"
            },
            {
              "id": 74,
              "registrationNumber": "41418",
              "commercialBrand": "2,4-D Agroimport",
              "class": "Herbicida",
              "crop": "Soja",
              "pestScientificName": "Euphorbia heterophylla",
              "pestCommonName": "\"amendoim-bravo"
            },
            ]
            """;

        public static string INSETICIDES = """
            [
            {
              "id": 254,
              "registrationNumber": "5221",
              "commercialBrand": "Abamex Maxx",
              "class": "Acaricida/Inseticida",
              "crop": "Soja",
              "pestScientificName": "Helicoverpa armigera",
              "pestCommonName": "Lagarta-do-algodao"
            },
            {
              "id": 276,
              "registrationNumber": "5124",
              "commercialBrand": "Acedemar",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Anticarsia gemmatalis",
              "pestCommonName": "\"Lagarta-da-soja"
            },
            {
              "id": 278,
              "registrationNumber": "5124",
              "commercialBrand": "Acedemar",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Helicoverpa armigera",
              "pestCommonName": "Lagarta-do-algodao"
            },
            {
              "id": 279,
              "registrationNumber": "38618",
              "commercialBrand": "Acefato CCAB 750 SP",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Anticarsia gemmatalis",
              "pestCommonName": "\"Lagarta-da-soja"
            },
            {
              "id": 285,
              "registrationNumber": "38618",
              "commercialBrand": "Acefato CCAB 750 SP",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Hedylepta indicata",
              "pestCommonName": "\"Lagarta-do-feijao"
            },
            {
              "id": 289,
              "registrationNumber": "26024",
              "commercialBrand": "Acefato CCAB 950 SG",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Anticarsia gemmatalis",
              "pestCommonName": "\"Lagarta-da-soja"
            },
            {
              "id": 291,
              "registrationNumber": "26024",
              "commercialBrand": "Acefato CCAB 950 SG",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Helicoverpa armigera",
              "pestCommonName": "Lagarta-do-algodao"
            },
            {
              "id": 304,
              "registrationNumber": "16024",
              "commercialBrand": "Acefato Max Nortox",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Anticarsia gemmatalis",
              "pestCommonName": "\"Lagarta-da-soja"
            },
            {
              "id": 306,
              "registrationNumber": "16024",
              "commercialBrand": "Acefato Max Nortox",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Helicoverpa armigera",
              "pestCommonName": "Lagarta-do-algodao"
            },
            {
              "id": 307,
              "registrationNumber": "16907",
              "commercialBrand": "Acefato Nortox",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Anticarsia gemmatalis",
              "pestCommonName": "\"Lagarta-da-soja"
            },
            {
              "id": 312,
              "registrationNumber": "16907",
              "commercialBrand": "Acefato Nortox",
              "class": "Inseticida",
              "crop": "Soja",
              "pestScientificName": "Helicoverpa armigera",
              "pestCommonName": "Lagarta-do-algodao"
            },
            ]
            """;

        public static string FUNGICIDES = """
            [{
              "id": 388,
              "registrationNumber": "14822",
              "commercialBrand": "Adetus",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 493,
              "registrationNumber": "7521",
              "commercialBrand": "Alade",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Corynespora cassiicola",
              "pestCommonName": "Mancha-alvo"
            },
            {
              "id": 501,
              "registrationNumber": "7521",
              "commercialBrand": "Alade",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 575,
              "registrationNumber": "7609",
              "commercialBrand": "Alterne",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 580,
              "registrationNumber": "26623",
              "commercialBrand": "Alto Elite",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 709,
              "registrationNumber": "11516",
              "commercialBrand": "Approve",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Corynespora cassiicola",
              "pestCommonName": "Mancha-alvo"
            },
            {
              "id": 726,
              "registrationNumber": "13420",
              "commercialBrand": "Aproach Power",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 730,
              "registrationNumber": "23820",
              "commercialBrand": "Aproach Power BR",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 735,
              "registrationNumber": "3124",
              "commercialBrand": "Aproach Premium",
              "class": "Bactericida/Fungicida",
              "crop": "Soja",
              "pestScientificName": "Corynespora cassiicola",
              "pestCommonName": "Mancha-alvo"
            },
            {
              "id": 744,
              "registrationNumber": "3124",
              "commercialBrand": "Aproach Premium",
              "class": "Bactericida/Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 748,
              "registrationNumber": "9107",
              "commercialBrand": "Aproach Prima",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            },
            {
              "id": 831,
              "registrationNumber": "8511",
              "commercialBrand": "Arcadia",
              "class": "Fungicida",
              "crop": "Soja",
              "pestScientificName": "Septoria glycines",
              "pestCommonName": "\"Mancha-parda"
            }]
            """;



    }
}
