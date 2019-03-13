
using System;
using System.Linq;

namespace Hasici.Web
{
    public static class DbInit
    {
        public static void FillDb (ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
           
            

           


            var articles = new Article[]
            {
                new Article {Title="Súťaž v nižnej",Content="17.6 sa konala okresná súťaž v Nižnej. Zúčastnili sa jej aj naše dve mužstvá. Tomu v kategórii Muži sa príliš nedarilo. Po schopne rozbehnutom útoku to ukončila chyba na rozdeľovači a tak na ľavo 19:31 nebolo nič platné keďže napravo to bolo až 33:06. Štafeta sa niesla v podobnom duchu. Celé to však vynahradili muži v kat. nad 35 rokov. Tí súťaž v ich kategórii vyhrali a s prehľadom tak schovali do vrecka aj svojich mladších kolegov. Gratulujeme :D",Publised=true, Date=DateTime.Parse("2005-09-01") },
                new Article {Title="Konečné výsledky HOHL 2018",Content="Poslednou súťažou v Štefanove tento víkend skončil ročník 2018. Štvrtý krát po sebe zvíťazila Trstená B. Tento rok to už však nebolo také jednoznačné. Po ich nepodarenom útoku v poslednom kole si určite vydýchli, keď sa dozvedeli že skončili na šiestom mieste. Stačilo by totiž aby boli o 76 stotín sekundy pomalší, a radovali by sa muži zo Štefanova. To však nestalo a Trstená B tak dominuje naďalej. Na treťom mieste skončil Zuberec s rovnakým počtom bodov ako druhý Štefanov avšak s horším časom. Mužom zo Zuberca sa tak stalo osudným zaváhanie v treťom kole kde dostali N. Inak však predvádzali skvelé výkony keď až 5 krát skončili druhý a raz vyhrali.  Dosiahli aj druhý najlepší čas sezóny keď v v Babíne dokončili za 14,22. Predbehlo ich len Trstenské  ktoré si taktiež v Babíne zapísalo 14,03.",Publised=true, Date=DateTime.Parse("2005-09-01")},
                new Article {Title="HOHL 2018",Content="Medzi ženami bolo rozhodnuté už kolo predtým a v Štefanove sa na konečnom poradí už nedalo nič zmeniť. Minuloročné víťazky skončili tentokrát až tretie a z víťazstva sa radovali baby aj z Vasiľova. Tie si to svojimi výkonmi určite zaslužili. Druhé skončili Suchohorky a štvrté napokon dievčatá z Hladovky ktoré však určite nemajú za čo hanbiť. Najlepšie časy celej sezóny zaznamenali práve víťazky, keď svoj najlepší pokus dokončili 19,24. Na pravo dokonca 18,15. ",Publised=true, Date=DateTime.Parse("2005-09-01") },
                new Article {Title="Štvrté kolo v Hruštíne",Content="V sobotu sme sa videli na druhej nočnej súťaži a celkovo štvrtom kole HOHL v Hruštíne.  A veru (ne)bolo sa na čo pozerať. Tímy nepredviedli bohvieaké výkony, aj tak to však určite bola zaujímavá súťaž. ",Publised=true },

            };

            foreach ( Article s in articles)
            {
                context.Add(s);
            }

            context.SaveChanges();
        }
         

    }
}
